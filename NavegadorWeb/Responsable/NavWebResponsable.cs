using System;
using System.Windows.Forms;
using System.IO;

namespace NavegadorWeb.Responsable
{
    public partial class NavWebResponsable : NavigatorForm
    {
        public static HtmlDocument doc;

        public NavWebResponsable()
        {
            InitializeComponent();
        }

        public void InitializeStep()
        {
            HtmlElement head = doc.GetElementsByTagName("head")[0];

            HtmlElement script = doc.CreateElement("script");
            var path = Path.Combine(System.Environment.CurrentDirectory, "script.js");
            var js = File.ReadAllText(path);
            script.SetAttribute("type", "text/javascript");
            script.InnerText = js;
            head.AppendChild(script);

            doc.InvokeScript("init");
        }

        public void InitializeRectangle()
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initCuadrado");
        }

        public void InitializeDialog()
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initEmoji");
        }

        public void InitializeText()
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initTexto");
        }

        public void InitializeCircle()
        {
            doc.InvokeScript("initCanvas");
            doc.InvokeScript("initCirculo");
        }

        public void reduceLineShape()
        {
            doc.InvokeScript("achicarLine");
        }

        public void increaseLineShape()
        {
            doc.InvokeScript("agrandarLine");
        }

        public void reduceShape()
        {
            doc.InvokeScript("achicarCanvas");
        }

        public void increaseShape()
        {
            doc.InvokeScript("agrandarCanvas");
        }

        private void initStep()
        {
            HtmlElement head = doc.GetElementsByTagName("head")[0];

            HtmlElement script = doc.CreateElement("script");
            var path = Path.Combine(System.Environment.CurrentDirectory, "script.js");
            var js = File.ReadAllText(path);
            script.SetAttribute("type", "text/javascript");
            script.InnerText = js;
            head.AppendChild(script);

            doc.InvokeScript("init");
        }

        private void addStepBntt_Click(object sender, EventArgs e)
        {
            doc = webBrowser.Document;
            initStep();

            CreateStep model = new CreateStep(doc);
            model.TopMost = true;
            model.Show();
        }
    }
}
