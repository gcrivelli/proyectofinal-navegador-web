using System;
using System.Windows.Forms;
using NavegadorWeb.Responsable;

namespace NavegadorWeb.Responsable
{
    public partial class CreateStep : Form
    {
        public static HtmlDocument doc;

        public CreateStep(HtmlDocument doc_bis)
        {
            InitializeComponent();
            doc = doc_bis;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
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

            HtmlElement head = doc.GetElementsByTagName("head")[0];

            HtmlElement script = doc.CreateElement("script");
            script.SetAttribute("type", "text/javascript");
            script.InnerText = "function setColor" + color + "() { setColor('" + color + "'); }";
            head.AppendChild(script);

            doc.InvokeScript("setColor" + color);
        }
    }
}
