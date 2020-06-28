using System;
using System.Windows.Forms;

namespace NavegadorWeb.Responsable
{
    public partial class CreateStep : Form
    {
        public static HtmlDocument doc;
        private System.Windows.Forms.WebBrowser webBrowser;

        public CreateStep(HtmlDocument _doc, System.Windows.Forms.WebBrowser _webBrowser)
        {
            InitializeComponent();
            doc = _doc;
            webBrowser = _webBrowser;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            doc.InvokeScript("finishStep");
            webBrowser.Refresh();
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
            webBrowser.Refresh();
            doc.InvokeScript("finishStep");
            this.Close();
        }
    }
}
