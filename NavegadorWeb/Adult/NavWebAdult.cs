using NavegadorWeb.Controller;
using NavegadorWeb.Models;
using System;
using System.Windows.Forms;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace NavegadorWeb.Adult
{
    public partial class NavWebAdult : NavigatorForm2
    {
        int stepCount;
        Tour tour;
        public NavWebAdult()
        {
            InitializeComponent();
        }

        private void viewTutorialBtn_Click(object sender, EventArgs e)
        {
            var tourController = new TourController();
            tour = tourController.GetTourAsync("5f16226e8f3f333ee16eee64").Result;//cuando navego a un tour
            MessageBox.Show("Comienza la reproducción del Tutorial " + tour.name, "Inicio de Tour", MessageBoxButton.OK, MessageBoxImage.Information);

            stepCount = 0;
            playStep(stepCount);
        }

        private void playStep(int positionStep)
        {
            var step = tour.steps.Find(s => s.order == stepCount);
            if (step != null)
            {
                //webBrowser.Navigate(step.url);

                foreach (Element e in step.elements)
                {
                    var doc = initStep(step.order, e.x, e.y, e.width, e.weight, e.type, e.color);
                    doc.InvokeScript("init");
                }
            }
            else
            {
                MessageBox.Show("No hay mas pasos, vuelve a comenzar","Fin del tutorial", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private HtmlDocument initStep(int positionStep, int x, int y, int width, int weight, int type, string color)
        {
            try
            {
                positionStep = 1;
                HtmlDocument doc = webBrowser.Document;
                HtmlElement head = doc.GetElementsByTagName("head")[0];
                HtmlElement script = doc.CreateElement("script");

                script.SetAttribute("type", "text/javascript");
                script.InnerText = "function init() {";

                script.InnerText += "var canvas" + positionStep + " = document.createElement('canvas');";
                script.InnerText += "canvas" + positionStep + ".id='canvas" + positionStep + "';";
                script.InnerText += "canvas" + positionStep + ".style.cssText = 'position: absolute; z-index: 9999; left: " + x + "px; top: " + y + "px;';";
                script.InnerText += "canvas" + positionStep + ".width=" + width + ";";
                script.InnerText += "canvas" + positionStep + ".height=" + width + ";";
                script.InnerText += "document.body.appendChild(canvas" + positionStep + ");";
                if (type == 1) // cuadrado
                {
                    script.InnerText += "var cuadrado=document.getElementById('canvas" + positionStep + "');";
                    script.InnerText += "var context = cuadrado.getContext('2d');";
                    script.InnerText += "context.rect(0,0," + width + "," + width + ");";
                    script.InnerText += "context.strokeStyle = '#" + color + "'" + ";";
                    script.InnerText += "context.lineWidth =" + weight + ";";
                    script.InnerText += "context.stroke();";
                }
                
                script.InnerText += "}";
                head.AppendChild(script);

                return doc;
            }
            catch
            {
                throw new Exception("No se pudo crear el documento.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stepCount++;
            playStep(stepCount);
        }
    }
}
