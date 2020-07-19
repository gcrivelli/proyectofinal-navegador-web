using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;
using NavegadorWeb.Models;
using System.Text.RegularExpressions;
using MessageBox = System.Windows.MessageBox;

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
                if (canvas!=null)
                {
                    String style = canvas.Style;
                    String[] styles = style.Split(";".ToCharArray());
                    Int16 x = 0;
                    Int16 y = 0;
                    Int16 width = 0;
                    Int16 height = 0;
                    String color = "";
                    Int16 type = 0;
                    Int16 weight = 1;
                    char[] charsToTrim = {' '};
                    foreach (var item in styles)
                    {

                        String[] attr = item.Split(":".ToCharArray());

                        if (attr[0].Trim(charsToTrim) == "left")
                        {
                            Match m;
                            m = Regex.Match(attr[1], " ?([0-9]+)px",RegexOptions.IgnoreCase);
                            x = Int16.Parse(m.Groups[1].ToString());
                        }
                        if (attr[0].Trim(charsToTrim) =="top")
                        {
                            Match m;
                            m = Regex.Match(attr[1], " ?([0-9]+)px", RegexOptions.IgnoreCase);
                            y = Int16.Parse(m.Groups[1].ToString());
                        }
                        if (attr[0].Trim(charsToTrim) == "height")
                        {
                            Match m;
                            m = Regex.Match(attr[1], " ?([0-9]+)px", RegexOptions.IgnoreCase);
                            height = Int16.Parse(m.Groups[1].ToString());
                        }
                        color = canvas.GetAttribute("data-color");
                        if (color == null)
                        {
                            color = "000000";
                        }
                    }
                    type = Int16.Parse(canvas.GetAttribute("data-tipo"));
                    weight = Int16.Parse(canvas.GetAttribute("data-weight"));
                    width = Int16.Parse(canvas.GetAttribute("data-width"));

                    addElementToStep(x, y, height, width, color, type, weight);
                }
            }            

            navWebResponsable.webBrowser.Refresh();
            navWebResponsable.addStepBtn.Enabled = true;
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

        private void addElementToStep(int x, int y, int height, int width, string color, int type, int weight)
        {
            var element = new Element()
            {
                x = x,
                y = y,
                height = height,
                width = width,
                color = color,
                weight = weight,
                type = type
            };

            navWebResponsable.tour.steps.Find(
                step => step.order == navWebResponsable.countStep).elements.Add(element);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("initDiv");
        }
    }
}
