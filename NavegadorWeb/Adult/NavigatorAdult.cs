using NavegadorWeb.Controller;
using NavegadorWeb.Models;
using NavegadorWeb.UI;
using System;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using System.Windows;
using System.IO;

namespace NavegadorWeb.Adult
{
    public partial class NavigatorAdult : NavigatorForm
    {
        AsistimeTourBar tourBar;
        private Tour tourLoad;
        private int countLoad;
        private string actualURL, lastCorrectURL;
        private int posActual;

        public NavigatorAdult()
        {
            InitializeComponent();
            webBrowser.Navigated += webBrowser_Navigated;
        }

        public void PlayTour(Tour tour)
        {
            this.Show();
            tourBar = new AsistimeTourBar() { Parent = this };
            tourBar.Location = new System.Drawing.Point(0, 0);
            this.Controls.Add(tourBar);
            tourBar.Show();
            this.asistimeAppBar.Hide();

            var tourController = new TourController();
            tour = tourController.GetTourAsync(tour._id).Result;

            // GET AUDIO 

            var audioResult = true;
            createDirectory();
            for (int i = 0; i < tour.steps.Count; i++)
            {
                if (tour.steps[i].audio != null)
                    audioResult = audioResult && tourController.GetAudio(tour._id, tour.steps[i]._id).Result;
            }

            tourLoad = tour;
            countLoad = 0;
            tourBar.TourInititated(tour);

            ConfirmationMessage m = new ConfirmationMessage("Iniciaste el tour!");
            m.Location = new System.Drawing.Point(Constants.AppBarWidth - 410, Constants.AppBarHeight + 50);
            m.Show();
        }

        public void playStep(Tour tour, int positionStep)
        {
            var step = tour.steps.Find(s => s.order == positionStep);
            var i = 1;
            int firstElementY = 100000;
            if (step != null)
            {
                var audioPath = "";
                if (step.audio != null)
                    audioPath = Constants.audioPath + "/Audio " + tour._id + step._id + ".wav";

                if (positionStep == 0)
                {
                    if (webBrowser.Url.ToString() != step.url)
                    {
                        webBrowser.Navigate(step.url);
                        actualURL = step.url;
                        lastCorrectURL = step.url;
                    }
                    //MessageBox.Show("Comienza la reproducción del Tutorial " + tour.name, "Inicio de Tour", MessageBoxButton.OK, MessageBoxImage.Information);
                    playAudio(audioPath);
                }


                if (webBrowser.Url.ToString() == step.url || step.url == lastCorrectURL)
                {
                    lastCorrectURL = step.url;
                    /*if (positionStep != 0)
                    {
                        ConfirmationMessage m = new ConfirmationMessage("Completaste el paso " + (step.order) + "!");
                        m.Location = new System.Drawing.Point(Constants.AppBarWidth - 410, Constants.AppBarHeight + 50);
                        m.BringToFront();
                        m.Show();
                    }*/


                    HtmlDocument doc = webBrowser.Document;
                    HtmlElement head = doc.GetElementsByTagName("head")[0];
                    HtmlElement script = doc.CreateElement("script");

                    script.SetAttribute("type", "text/javascript");
                    script.InnerText = "";
                    script.InnerText += "var id = '';";
                    script.InnerText += "var habilitado = false;";
                    script.InnerText += "var x_min = 0;";
                    script.InnerText += "var x_max = 0;";
                    script.InnerText += "var y_min = 0;";
                    script.InnerText += "var y_max = 0;";
                    script.InnerText += "document.body.style['pointer-events']='none';";
                    script.InnerText += "document.addEventListener('mousemove',onMouseUpdate, false);";
                    script.InnerText += "document.addEventListener('mouseenter',onMouseUpdate, false);";
                    script.InnerText += "function onMouseUpdate(e) {  ";
                    script.InnerText += "if(habilitado&&(e.pageX<x_min||e.pageX>x_max||e.pageY<y_min||e.pageY>y_max)) {";
                    script.InnerText += "document.body.style['pointer-events']='none';";
                    script.InnerText += "}";
                    script.InnerText += "}";
                    script.InnerText += "function ocultar(id,x1,x2,y1,y2) {";
                    script.InnerText += "x_min=parseInt(x1);";
                    script.InnerText += "x_max=parseInt(x1)+parseInt(x2);";
                    script.InnerText += "y_min=parseInt(y1);";
                    script.InnerText += "y_max=parseInt(y1)+parseInt(y2);";
                    script.InnerText += "habilitado=true;";
                    script.InnerText += "document.body.style['pointer-events']='auto';";
                    script.InnerText += "var element = document.getElementById(id);";
                    script.InnerText += "element.style.display = 'none';";
                    script.InnerText += "setTimeout(function(){ mostrar(id); }, 2000);";
                    script.InnerText += "}";
                    script.InnerText += "function mostrar(id) {";
                    script.InnerText += "var element = document.getElementById(id);";
                    script.InnerText += "element.style.display = 'block';";
                    script.InnerText += "}";
                    script.InnerText += "function init" + step.order + "() {";
                    script.InnerText += "var elements = document.getElementsByClassName('asistime');";
                    script.InnerText += "while(elements.length > 0) {";
                    script.InnerText += "elements[0].parentNode.removeChild(elements[0]);";
                    script.InnerText += "}";

                    foreach (Element e in step.elements)
                    {
                        if (e.y < firstElementY)
                        {
                            firstElementY = e.y;
                        }

                        if (e.type == 9)
                        {
                            script.InnerText += initDiv(e.x, e.y, e.width, e.height, e.color, e.inclination);
                        }
                        else
                        {
                            script.InnerText += initElement(positionStep, i, e.x, e.y, e.width, e.weight, e.type, e.color, e.inclination, e.text);
                            i++;
                        }
                    }

                    int pos;

                    if (posActual + 100 < firstElementY)
                    {
                        for (pos = posActual; pos <= firstElementY - 100; pos++)
                        {
                            webBrowser.Document.Window.ScrollTo(0, pos - 100);
                            pos = pos + 9;
                        }
                        posActual = pos - 100;
                    }

                    else if (posActual + 100 > firstElementY)
                    {
                        for (pos = posActual; pos >= firstElementY - 100; pos--)
                        {
                            webBrowser.Document.Window.ScrollTo(0, pos - 100);
                            pos = pos - 9;
                        }
                        posActual = pos - 100;
                    }

                    script.InnerText += "}";
                    head.AppendChild(script);
                    /*do
                    {
                        var hardcode = true;
                    } while (webBrowser.ReadyState != WebBrowserReadyState.Complete);*/
                    doc.InvokeScript("init" + step.order);
                    playAudio(audioPath);
                }
                else
                { 
                    var result = MessageBox.Show("Paso erroneo, ¿quiere volver al último paso correcto?", "Paso equivocado", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result.ToString() == "Yes")
                    {
                        countLoad--;
                        actualURL = lastCorrectURL;
                        webBrowser.Navigate(lastCorrectURL);
                        playStep(tourLoad, countLoad);
                    }
                    else
                    {
                        this.tourBar.Hide();
                        this.asistimeAppBar.Show();
                        tourLoad = null;
                    }
                }
                
            }
            else
            {
                ConfirmationMessage m = new ConfirmationMessage("Completaste el tour!");
                m.Location = new System.Drawing.Point(Constants.AppBarWidth - 410, Constants.AppBarHeight + 50);
                m.Show(); 
                //MessageBox.Show("Completaste el Tour!", "Fin del tutorial", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private string initElement(int positionStep, int positionElement, int x, int y, int width, int weight, int type, string color, string inclination, string text)
        {
            try
            {
                var js = "";
                js += "var canvas" + positionStep + positionElement + " = document.createElement('canvas');";
                js += "canvas" + positionStep + positionElement + ".id='canvas" + positionStep + positionElement + "';";
                js += "canvas" + positionStep + positionElement + ".style.cssText = 'position:absolute;z-index: 9999;left:" + x + "px;top:" + y + "px;';";
                js += "canvas" + positionStep + positionElement + ".style.transform = 'rotate(" + inclination + "deg)';";
                js += "canvas" + positionStep + positionElement + ".style['pointer-events'] = 'auto';";
                js += "canvas" + positionStep + positionElement + ".width=" + width + ";";
                js += "canvas" + positionStep + positionElement + ".height=" + width + ";";
                js += "canvas" + positionStep + positionElement + ".className = 'asistime';"; 
                js += "canvas" + positionStep + positionElement + ".onmouseover = function() {ocultar('canvas" + positionStep + positionElement + "','" + x + "','" + width + "','" + y + "','" + width + "')};";
                js += "document.body.appendChild(canvas" + positionStep + positionElement + ");";
                if (type == 1) // cuadrado
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.rect(0,0," + width + "," + width + ");";
                }
                if (type == 2) // circulo
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.arc((" + width + "-2)/2,(" + width + "-2)/2,(" + width + "-2)/2,0,2*Math.PI);";
                }
                if (type == 3) // texto
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.font = '20px Arial';";
                    js += "context.fillText('" + text + "', 250, 250);";
                }
                if (type == 4) // dialogo
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.beginPath();";
                    js += "context.moveTo(75/200*" + width + ",25/200*" + width + ");";
                    js += "context.quadraticCurveTo(25/200*" + width + ",25/200*" + width + ",25/200*" + width + ",62.5/200*" + width + ");";
                    js += "context.quadraticCurveTo(25/200*" + width + ",100/200*" + width + ",50/200*" + width + ",100/200*" + width + ");";
                    js += "context.quadraticCurveTo(50/200*" + width + ",120/200*" + width + ",30/200*" + width + ",125/200*" + width + ");";
                    js += "context.quadraticCurveTo(60/200*" + width + ",120/200*" + width + ",65/200*" + width + ",100/200*" + width + ");";
                    js += "context.quadraticCurveTo(125/200*" + width + ",100/200*" + width + ",125/200*" + width + ",62.5/200*" + width + ");";
                    js += "context.quadraticCurveTo(125/200*" + width + ",25/200*" + width + ",75/200*" + width + ",25/200*" + width + ");";
                }
                js += "context.strokeStyle = '#" + color + "'" + ";";
                js += "context.lineWidth =" + weight + ";";
                js += "context.stroke();";

                return js;
            }
            catch
            {
                throw new Exception("No se pudo crear el documento.");
            }
        }

        private string initDiv(int x, int y, int width, int height, string color, string opacity)
        {
            try
            {
                var js = "";
                js += "var div = document.createElement('div');";
                js += "div.style.cssText = 'position:absolute;z-index:9999;background-color:#" + color + ";width:100%;height:" + y + "px;top:0px;left:0px;opacity:" + opacity + ";';";
                js += "div.className = 'asistime';";
                js += "document.body.appendChild(div);";
                js += "var div = document.createElement('div');";
                js += "div.style.cssText = 'position:absolute;z-index:9999;background-color:#" + color + ";width:100%;height:100%;top:" + height + "px;left:0px;opacity:" + opacity + ";';";
                js += "div.className = 'asistime';";
                js += "document.body.appendChild(div);";
                js += "var div = document.createElement('div');";
                js += "div.style.cssText = 'position:absolute;z-index:9999;background-color:#" + color + ";width:" + x + "px;height:" + (height - y) + "px;top:" + y + "px;left:0px;opacity:" + opacity + ";';";
                js += "div.className = 'asistime';";
                js += "document.body.appendChild(div);";
                js += "var div = document.createElement('div');";
                js += "div.style.cssText = 'position:absolute;z-index:9999;background-color:#" + color + ";width:100%;height:" + (height - y) + "px;top:" + y + "px;left:" + width + "px;opacity:" + opacity + ";';";
                js += "div.className = 'asistime';";
                js += "document.body.appendChild(div);";

                return js;
            }
            catch
            {
                throw new Exception("No se pudo crear el documento.");
            }
        }

        public override void ShowMenu()
        {
            // esta instanciacion deberia ir después del login
            var userController = new TourController();
            var tours = userController.GetAllToursAsync("5f0907dd5d988f31d515dc72").Result;
            MenuAdult menu = new MenuAdult(tours, this);

            this.Hide();
            menu.Show();
        }

        public void CloseTour()
        {
            tourBar.Hide();
            tourLoad = null;
            asistimeAppBar.Show();
            webBrowser.Refresh();
        }
        private void createDirectory()
        {
            var path = Constants.audioPath;
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch
            {
                MessageBox.Show("Error al crear el directorio para los audios", "Error");
            }
        }
        private void playAudio(string audioPath)
        {
            if (File.Exists(audioPath))
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(audioPath);
                player.Play();
            }
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (actualURL != webBrowser.Url.ToString() || actualURL != lastCorrectURL)
            {
                asistimeAppBar.Navigated(webBrowser.Url.ToString());

                if (tourLoad != null)
                {
                    actualURL = webBrowser.Url.ToString();
                    countLoad++;
                    playStep(tourLoad, countLoad);
                }

            }
        }

    }
}
