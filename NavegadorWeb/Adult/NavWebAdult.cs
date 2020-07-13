using NavegadorWeb.Controller;
using NavegadorWeb.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows;
using MessageBox = System.Windows.MessageBox;
using NavegadorWeb.UI;

namespace NavegadorWeb.Adult
{
    public partial class NavWebAdult : NavigatorForm
    {
        public NavWebAdult()
        {
            InitializeComponent();
        }

        private void viewTutorialBtn_Click(object sender, EventArgs e)
        {
            /*var tourController = new TourController();
            var tour = tourController.GetAsync(textBox1.Text).Result;
            MessageBox.Show(tour.name + ", " + tour.description);*/
            var doc = initStep();
            doc.InvokeScript("init");
        }

        private HtmlDocument initStep()
        {
            try
            {
                HtmlDocument doc = webBrowser.Document;
                HtmlElement head = doc.GetElementsByTagName("head")[0];
                HtmlElement script = doc.CreateElement("script");

                string[] colors = { "FF0000", "008000", "FF0000", "0000FF" };
                int[] withs = { 200, 100, 500, 300 };
                int[] weights = { 5, 2, 4, 5 };
                int[] tipos = { 1, 1, 1, 1 };
                int[] lefts = { 500, 600, 900, 20 };
                int[] tops = { 10, 600, 20, 400 };

                script.SetAttribute("type", "text/javascript");
                script.InnerText = "function init() {";

                for (int i = 0; i < 4; i++)
                {
                    script.InnerText += "var canvas" + i + " = document.createElement('canvas');";
                    script.InnerText += "canvas" + i + ".id='canvas" + i + "';";
                    script.InnerText += "canvas" + i + ".style.cssText = 'position: absolute; z-index: 9999; left: " + lefts[i] + "px; top: " + tops[i] + "px;';";
                    script.InnerText += "canvas" + i + ".width=" + withs[i] + ";";
                    script.InnerText += "canvas" + i + ".height=" + withs[i] + ";";
                    script.InnerText += "document.body.appendChild(canvas" + i + ");";
                    if (tipos[i] == 1) // cuadrado
                    {
                        script.InnerText += "var cuadrado=document.getElementById('canvas" + i + "');";
                        script.InnerText += "var context = cuadrado.getContext('2d');";
                        script.InnerText += "context.rect(0,0," + withs[i] + "," + withs[i] + ");";
                        script.InnerText += "context.strokeStyle = '#" + colors[i] + "'" + ";";
                        script.InnerText += "context.lineWidth =" + weights[i] + ";";
                        script.InnerText += "context.stroke();";
                    }
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

        private void profile_Click(object sender, EventArgs e)
        {
            Controles2 mod = new Controles2();
            mod.Show();
        }
    }
}
