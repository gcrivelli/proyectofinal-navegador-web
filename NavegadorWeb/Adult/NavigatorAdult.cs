using NavegadorWeb.Controller;
using NavegadorWeb.Models;
using NavegadorWeb.UI;
using System;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using System.Windows;
using Newtonsoft.Json;

namespace NavegadorWeb.Adult
{
    public partial class NavigatorAdult : NavigatorForm
    {
        AsistimeTourBar tourBar;
        public NavigatorAdult()
        {
            InitializeComponent();
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
            MessageBox.Show("Comienza la reproducción del Tutorial " + tour.name, "Inicio de Tour", MessageBoxButton.OK, MessageBoxImage.Information);

            tourBar.TourInititated(tour);
            playStep(tour, 0);
        }

        public void playStep(Tour tour, int positionStep)
        {
            //var step = tour.steps.Find(s => s.order == StepCount);
            var step = tour.steps.Find(s => s.order == positionStep);
            var i = 1;
            if (step != null)
            {
                //webBrowser.Navigate(step.url);

                HtmlDocument doc = webBrowser.Document;
                HtmlElement head = doc.GetElementsByTagName("head")[0];
                HtmlElement script = doc.CreateElement("script");

                script.SetAttribute("type", "text/javascript");
                script.InnerText = "function init" + step.order + "() {";
                script.InnerText += "var elements = document.getElementsByClassName('asistime');";
                script.InnerText += "while(elements.length > 0){";
                script.InnerText += "elements[0].parentNode.removeChild(elements[0]);";
                script.InnerText += "}";

                foreach (Element e in step.elements)
                {
                    script.InnerText += initElement(positionStep, i, e.x, e.y, e.width, e.weight, e.type, e.color);
                    i++;
                }

                script.InnerText += "}";
                head.AppendChild(script);

                doc.InvokeScript("init" + step.order);
            }
            else
            {
                MessageBox.Show("No hay mas pasos, vuelve a comenzar", "Fin del tutorial", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private string initElement(int positionStep, int positionElement, int x, int y, int width, int weight, int type, string color)
        {
            try
            {
                width = 200;
                var js = "";
                js += "var canvas" + positionStep + positionElement + " = document.createElement('canvas');";
                js += "canvas" + positionStep + positionElement + ".id='canvas" + positionStep + positionElement + "';";
                js += "canvas" + positionStep + positionElement + ".style.cssText = 'position: absolute; z-index: 9999; left: " + x + "px; top: " + y + "px;';";
                js += "canvas" + positionStep + positionElement + ".width=" + width + ";";
                js += "canvas" + positionStep + positionElement + ".height=" + width + ";";
                js += "canvas" + positionStep + positionElement + ".className = 'asistime';";
                js += "document.body.appendChild(canvas" + positionStep + positionElement + ");";
                if (type == 1) // cuadrado
                {
                    js += "var cuadrado=document.getElementById('canvas" + positionStep + positionElement + "');";
                    js += "var context = cuadrado.getContext('2d');";
                    js += "context.rect(0,0," + width + "," + width + ");";
                    js += "context.strokeStyle = '#" + color + "'" + ";";
                    js += "context.lineWidth =" + weight + ";";
                    js += "context.stroke();";
                }

                return js;
            }
            catch
            {
                throw new Exception("No se pudo crear el documento.");
            }
        }

        public override void ShowMenu()
        {
            //esta instanciacion deberia ir después del login
            var userController = new TourController();
            user = userController.GetAllToursAsync("5f0907dd5d988f31d515dc72").Result;
            MenuAdult menu = new MenuAdult(user, this);

            this.Hide();
            menu.Show();
        }

        public void CloseTour()
        {
            tourBar.Hide();
            asistimeAppBar.Show();
        }
    }
}
