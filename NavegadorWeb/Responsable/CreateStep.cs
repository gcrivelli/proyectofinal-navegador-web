using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;
using NavegadorWeb.Models;

namespace NavegadorWeb.Responsable
{
    public partial class CreateStep : Form
    {
        public static HtmlDocument doc;
        public NavWebResponsable navWebResponsable;
        String UrlReproductor = null;
        SoundPlayer ReproductorWav;
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int Grabar(string Comando, string StringRetorno, int Longitud, int hwndCallback);

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
            this.Close();
        }

        private void circleBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initCirculo");
            addElementToStep(2, 3, 4, 5, "red");
        }

        private void rectangleBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initCuadrado");
            addElementToStep(2, 3, 4, 5, "red");
        }

        private void dialogBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initEmoji");
            addElementToStep(2, 3, 4, 5, "red");
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
        }

        private void lessLineBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("achicarLine");
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

            navWebResponsable.webBrowser.Refresh();
            doc.InvokeScript("finishStep");
            this.Close();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            Grabar("open new Type waveaudio Alias recsound", "", 0, 0);
            Grabar("record recsound", "", 0, 0);
            btnRecord.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SaveFileDialog DialogoGuardar = new SaveFileDialog();
            DialogoGuardar.AddExtension = true;
            DialogoGuardar.FileName = "Audio"+ navWebResponsable.countStep + ".wav";
            DialogoGuardar.Filter = "Sonido (*.wav)|*.wav";
            DialogoGuardar.ShowDialog();
            if (!string.IsNullOrEmpty(DialogoGuardar.FileName))
            {
                UrlReproductor = DialogoGuardar.FileName;

                Grabar("save recsound " + DialogoGuardar.FileName, "", 0, 0);
                Grabar("close recsound", "", 0, 0);
                MessageBox.Show("Archivo de audio guardado en: " + DialogoGuardar.FileName);
            }
            else
            {
                MessageBox.Show("No se encontró ningún archivo de audio");
            }
            btnPlay.Enabled = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            ReproductorWav.SoundLocation = UrlReproductor;
            ReproductorWav.Play();
        }

        private void addElementToStep(int x, int y, int height, int width, string color)
        {
            if (navWebResponsable.tour.steps.Count == 0) //En el caso del primer paso
                navWebResponsable.addStepToTour();

            var element = new Element()
            {
                x = x,
                y = y,
                height = height,
                width = width,
                color = color
            };

            navWebResponsable.tour.steps.Find(
                step => step.order == navWebResponsable.countStep).elements.Add(element);
        }
    }
}
