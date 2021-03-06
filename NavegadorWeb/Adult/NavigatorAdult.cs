﻿using NavegadorWeb.Controller;
using NavegadorWeb.Models;
using NavegadorWeb.UI;
using System;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using System.Windows;
using System.IO;
using System.Linq;
using NavegadorWeb.Extra;
using NavegadorWeb.GeneralDisplay;

namespace NavegadorWeb.Adult
{
    public partial class NavigatorAdult : NavigatorForm
    {
        AsistimeTourBar tourBar;
        private Tour tourLoad;
        public int countLoad;
        private string actualURL, lastCorrectURL;
        private int posActual;
        private bool volverAPasoCorrecto;
        private LoadingForm loadingForm;
        public Tour actualTour;

        public NavigatorAdult()
        {
            InitializeComponent();
            asistimeAppBar = new AdultAppBar() { Parent = this };
            asistimeAppBar.Width = this.Width;
            this.Controls.Add(asistimeAppBar);
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
        }

        public void PlayTour(Tour tour)
        {
            //Mostrar la barra de tour
            this.actualTour = tour;
            this.Show();
            tourBar = new AsistimeTourBar() { Parent = this };
            tourBar.Location = new System.Drawing.Point(0, 0);
            tourBar.StepCount = 0;
            this.Controls.Add(tourBar);
            tourBar.Show();
            this.asistimeAppBar.Hide();

            loadingForm = new LoadingForm();
            loadingForm.Show();

            //Instanciar el controller para el tour
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

            loadingForm.Close();

            //Reproducir el paso 0 
            var firstStep = tour.steps[0];
            webBrowser.Navigate(firstStep.url);
            actualURL = "";


            //Mostrar mensaje de confirmación
            new PopupNotification("Inicio Tour", "Comienza el tour");
        }

        public void playStep(Tour tour, int positionStep, bool flag = false)
        {
            var actualStep = tour.steps.Find(s => s.order == positionStep);

            if (actualStep != null)
            {
                var nextStep = nextDiferentUrlStep(actualStep);
                var audioPath = "";

                if (!tourBar.isLastStepInUrl && !flag)
                    actualStep = nextStep;

                if (actualStep != null)
                {
                    actualURL = actualStep.url;
                    if (actualStep.audio != null)
                        audioPath = Constants.audioPath + "/Audio " + tour._id + actualStep._id + ".wav";

                    if (webBrowser.Url.ToString() == actualStep.url || volverAPasoCorrecto)
                    {
                        volverAPasoCorrecto = false;
                        lastCorrectURL = actualStep.url;
                        tourBar.SetStep(actualStep.order);
                        if (positionStep != 0)
                        {
                            new PopupNotification("Excelente!", "Realizaste el paso " + positionStep + " con éxito!");
                        }

                        var doc = initDocument(actualStep, actualStep.order);
                        doc.InvokeScript("init" + actualStep.order);

                        playAudio(audioPath);
                    }
                }
                if (actualStep == tour.steps.Last())
                {
                    new PopupNotification("Fin del Tour!", "Completaste el tour con éxito!");
                }

            }
        }

        public HtmlDocument initDocument (Step step, int positionStep)
        {
            var i = 1;
            int firstElementY = 100000;

            HtmlDocument doc = webBrowser.Document;
            HtmlElement head = doc.GetElementsByTagName("head")[0];

            HtmlElement style = doc.CreateElement("link");
            style.SetAttribute("rel", "stylesheet");
            style.SetAttribute("href", "https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css");
            head.AppendChild(style);

            HtmlElement script = doc.CreateElement("script");

            script.SetAttribute("type", "text/javascript");
            script.InnerText = "";
            script.InnerText += "var id = '';";
            script.InnerText += "var habilitado = false;";
            script.InnerText += "var x_min = 0;";
            script.InnerText += "var x_max = 0;";
            script.InnerText += "var y_min = 0;";
            script.InnerText += "var y_max = 0;";
            script.InnerText += "document.addEventListener('mousemove',onMouseUpdate, false);";
            script.InnerText += "document.addEventListener('mouseenter',onMouseUpdate, false);";
            script.InnerText += "document.body.style['pointer-events']='none';";
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

            foreach (Element elem in step.elements)
            {
                if (elem.y < firstElementY)
                {
                    firstElementY = elem.y;
                }

                if (elem.type == 9)
                {
                    script.InnerText += initDiv(elem);
                }
                else
                {
                    script.InnerText += initElement(positionStep, i, elem);
                    i++;
                }
            }

            int pos;

            if (firstElementY != 100000)
            {

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

            }

            script.InnerText += "}";
            head.AppendChild(script);

            return doc;
        }

        private string initElement(int positionStep, int positionElement, Element element)
        {
            try
            {
                var js = "";
                js += "var canvas" + positionStep + positionElement + " = document.createElement('canvas');";
                js += "canvas" + positionStep + positionElement + ".id='canvas" + positionStep + positionElement + "';";
                js += "canvas" + positionStep + positionElement + ".style.cssText = 'position:absolute;z-index: 9999;left:" + 
                    element.x + "px;top:" + element.y + "px;';";
                js += "canvas" + positionStep + positionElement + ".style.transform = 'rotate(" + element.inclination + "deg)';";
                js += "canvas" + positionStep + positionElement + ".style['pointer-events'] = 'auto';";
                js += "canvas" + positionStep + positionElement + ".width=" + element.width + ";";
                js += "canvas" + positionStep + positionElement + ".height=" + element.width + ";";
                js += "canvas" + positionStep + positionElement + ".className = 'asistime';"; 
                js += "canvas" + positionStep + positionElement + ".onmouseover = function() {ocultar('canvas" + positionStep +
                    positionElement + "','" + element.x + "','" + element.width + "','" + element.y + "','" + element.width + "')};";                
                js += "document.body.appendChild(canvas" + positionStep + positionElement + ");";
                if (element.type == 1) // cuadrado
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.rect(0,0," + element.width + "," + element.width + ");";
                }
                if (element.type == 2) // circulo
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.arc((" + element.width + "-2)/2,(" + element.width + "-2)/2,(" + element.width + "-2)/2,0,2*Math.PI);";
                }
                if (element.type == 3) // texto
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.font = '20px Arial';";
                    js += "context.fillText('" + element.text + "', 10, 40);";
                }
                if (element.type == 4) // icono
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.font = '100px FontAwesome';";
                    js += "context.fillText('\uf0f3',60,140);";
                }
                if (element.type == 5) // icono
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.font = '100px FontAwesome';";
                    js += "context.fillText('\uf05e',60,140);";
                }
                if (element.type == 6) // icono
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.font = '100px FontAwesome';";
                    js += "context.fillText('\uf00c',60,140);";
                }
                if (element.type == 7) // icono
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.font = '100px FontAwesome';";
                    js += "context.fillText('\uf075',60,140);";
                }
                if (element.type == 8) // icono
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.font = '100px FontAwesome';";
                    js += "context.fillText('\uf119',60,140);";
                }
                if (element.type == 15) // icono
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.font = '100px FontAwesome';";
                    js += "context.fillText('\uf118',60,140);";
                }
                if (element.type == 10) // icono
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.font = '100px FontAwesome';";
                    js += "context.fillText('\uf256',60,140);";
                }
                if (element.type == 11) // icono
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.font = '100px FontAwesome';";
                    js += "context.fillText('\uf0a6',60,140);";
                }
                if (element.type == 13) // icono
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.font = '100px FontAwesome';";
                    js += "context.fillText('\uf07a',60,140);";
                }
                if (element.type == 14) // icono
                {
                    js += "var element=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = element.getContext('2d');";
                    js += "context.font = '100px FontAwesome';";
                    js += "context.fillText('\uf164',60,140);";
                }
                js += "context.strokeStyle = '" + element.color + "'" + ";";
                js += "context.lineWidth =" + element.weight + ";";
                js += "context.stroke();";

                return js;
            }
            catch
            {
                throw new Exception("No se pudo crear el documento.");
            }
        }

        private string initDiv(Element element)
        {
            try
            {
                var js = "";
                js += "var div = document.createElement('div');";
                js += "div.style.cssText = 'position:absolute;z-index:9999;background-color:" + element.color + ";width:100%;height:" + element.y + "px;top:0px;left:0px;opacity:" + element.inclination + ";';";
                js += "div.className = 'asistime';";
                js += "document.body.appendChild(div);";
                js += "var div = document.createElement('div');";
                js += "div.style.cssText = 'position:absolute;z-index:9999;background-color:" + element.color + ";width:100%;height:100%;top:" + element.height + "px;left:0px;opacity:" + element.inclination + ";';";
                js += "div.className = 'asistime';";
                js += "document.body.appendChild(div);";
                js += "var div = document.createElement('div');";
                js += "div.style.cssText = 'position:absolute;z-index:9999;background-color:" + element.color + ";width:" + element.x + "px;height:" + (element.height - element.y) + "px;top:" + element.y + "px;left:0px;opacity:" + element.inclination + ";';";
                js += "div.className = 'asistime';";
                js += "document.body.appendChild(div);";
                js += "var div = document.createElement('div');";
                js += "div.style.cssText = 'position:absolute;z-index:9999;background-color:" + element.color + ";width:100%;height:" + (element.height - element.y) + "px;top:" + element.y + "px;left:" + element.width + "px;opacity:" + element.inclination + ";';";
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
            //MenuAdult menu = new MenuAdult(Constants.tours, this);
            MenuForm2 menu = new MenuForm2(Constants.tours, this);

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
                new PopupNotification("Error", "Error al crear el directorio para los audios.");
            }
        }
        public void playAudio(string audioPath)
        {
            if (File.Exists(audioPath))
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(audioPath);
                player.Play();
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (actualURL != webBrowser.Url.ToString() || actualURL != lastCorrectURL)
            {
                asistimeAppBar.Navigated(webBrowser.Url.ToString());

                if (tourLoad != null)
                {
                    actualURL = webBrowser.Url.ToString();
                    playStep(tourLoad, countLoad, true);
                    countLoad++;
                }
            } 
        }

        private Step nextDiferentUrlStep (Step step)
        {
            var steps = this.tourLoad.steps.FindAll(s => s.order > step.order);
            return steps.FirstOrDefault(s => s.url != step.url);

        }

        //Envio de notificacion de ayuda
        public void Asistime() 
        {
            var notificationController = new NotificationController();
            var notificacion = new Notification();
            notificacion.evento = "Ayuda con una pagina web";
            notificacion.message = Constants.user.name + " necesita ayuda para acceder a la pagina " + webBrowser.Url.ToString() +
                                    ". Ponete en contacto lo antes posible.";
            var urlToSend = webBrowser.Url.ToString();
            notificacion.data = urlToSend.Split('/')[2];

            var result = notificationController.PostNotification(notificacion).Result;

            if (result)
                new PopupNotification("Pedido de ayuda!", "La ayuda viene en camino.");
            
        }
    }
    
}
