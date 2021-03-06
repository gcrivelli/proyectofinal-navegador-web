﻿using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;
using NavegadorWeb.Models;
using System.IO;
using NavegadorWeb.UI;
using NavegadorWeb.Extra;

namespace NavegadorWeb.Responsable
{
    public partial class CreateStep : Form
    {
        public static HtmlDocument doc;
        public NavWebResponsable navWebResponsable;
        String UrlReproductor = null;
        SoundPlayer ReproductorWav;
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        public CreateStep(HtmlDocument _doc, NavWebResponsable _navWebResponsable)
        {
            InitializeComponent();
            doc = _doc;
            navWebResponsable = _navWebResponsable;
            ReproductorWav = new SoundPlayer();
            btnStop.Enabled = false;
            btnPlay.Enabled = false;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("finishStep");
            navWebResponsable.webBrowser.Refresh();
            navWebResponsable.addStepBtn.Enabled = true;
            this.Close();
        }

        private void circleBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initCirculo");
        }

        private void rectangleBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initCuadrado");
        }

        private void dialogBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initEmoji");
        }

        private void textBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initTexto");
        }

        private void colorBtn_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            String color = (colorDialog1.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
            colorBtn.BackColor = colorDialog1.Color;
            HtmlElement head = doc.GetElementsByTagName("head")[0];

            HtmlElement script = doc.CreateElement("script");
            script.SetAttribute("type", "text/javascript");
            script.InnerText = "function setColor" + color + "() { setColor('" + color + "'); }";
            head.AppendChild(script);

            doc.InvokeScript("setColor" + color);
        }

        private void moreLineBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("agrandarLine");
            doc.InvokeScript("agrandarOpacity");
        }

        private void lessLineBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("achicarLine");
            doc.InvokeScript("achicarOpacity");
        }

        private void lessCanvasBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("achicarCanvas");
        }

        private void moreCanvasBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("agrandarCanvas");
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            //Aca va el comportamiento para guardar el paso
            navWebResponsable.incrementStepCount();
            navWebResponsable.addStepToTour();

            for (int i = 1; i < 10; i++)
            {
                HtmlElement canvas = doc.GetElementById("canvas" + i);
                if (canvas != null)
                {
                    Int16 x = 0;
                    Int16 y = 0;
                    Int16 width = 0;
                    Int16 height = 0;
                    String color = "";
                    Int16 type = 0;
                    Int16 weight = 1;
                    String inclination;
                    String text;

                    color = canvas.GetAttribute("data-color");
                    if (color == null)
                    {
                        color = "000000";
                    }
                    width = Int16.Parse(canvas.OffsetRectangle.Width.ToString());
                    height = Int16.Parse(canvas.OffsetRectangle.Height.ToString());
                    x = Int16.Parse(canvas.OffsetRectangle.X.ToString());
                    y = Int16.Parse(canvas.OffsetRectangle.Y.ToString());
                    type = Int16.Parse(canvas.GetAttribute("data-tipo"));
                    weight = Int16.Parse(canvas.GetAttribute("data-weight"));
                    inclination = canvas.GetAttribute("data-inclinacion");
                    text = canvas.GetAttribute("data-text");

                    addElementToStep(x, y, height, width, color, type, weight, inclination, text);
                }
            }

            HtmlElement div = doc.GetElementById("asistime-div");
            if (div != null)
            {
                Int16 x = 0;
                Int16 y = 0;
                Int16 width = 0;
                Int16 height = 0;
                String opacity = "";
                String color = "";
                Int16 type = 9;

                opacity = div.GetAttribute("data-opacity");
                if (opacity == null)
                {
                    opacity = "0.5";
                }

                color = div.GetAttribute("data-color");
                if (color == null)
                {
                    color = "000000";
                }

                x = Int16.Parse(div.GetAttribute("data-x1"));
                y = Int16.Parse(div.GetAttribute("data-y1"));
                width = Int16.Parse(div.GetAttribute("data-x2"));
                height = Int16.Parse(div.GetAttribute("data-y2"));
                addElementToStep(x, y, height, width, color, type, 0, opacity, "");
            }

            navWebResponsable.webBrowser.Refresh();
            navWebResponsable.addStepBtn.Enabled = true;
            doc.InvokeScript("finishStep");
            this.Close();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            record("open new Type waveaudio Alias recsound", "", 0, 0);
            record("record recsound", "", 0, 0);
            btnRecord.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            createDirectory();

            var nameTourWithoutSpace = navWebResponsable.tour.name.Replace(" ", "");
            var audioName = "/Audio"+ nameTourWithoutSpace + navWebResponsable.countStep + ".wav";
            UrlReproductor = Constants.audioPath + audioName;

            record("save recsound " + UrlReproductor, "", 0, 0);
            record("close recsound", "", 0, 0);

            new PopupNotification("Grabado exitoso", "Archivo de audio guardado");

            btnPlay.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            ReproductorWav.SoundLocation = UrlReproductor;
            ReproductorWav.Play();
        }

        private void addElementToStep(int x, int y, int height, int width, string color, int type, int weight, string inclination, string text)
        {
            var element = new Element()
            {
                x = x,
                y = y,
                height = height,
                width = width,
                color = color,
                weight = weight,
                type = type,
                inclination = inclination,
                text = text
            };

            navWebResponsable.tour.steps.Find(
                step => step.order == navWebResponsable.countStep).elements.Add(element);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("initDiv");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("agrandarAngulo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("achicarAngulo");
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
                new PopupNotification("Error", "Error al crear el directorio para los audios");
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("achicarLetra");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("agrandarLetra");
        }

        private void CreateStep_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("achicarOpacity");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("agrandarOpacity");
        }
    }
}