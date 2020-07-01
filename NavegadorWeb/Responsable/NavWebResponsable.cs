using System;
using System.Windows.Forms;
using System.IO;

namespace NavegadorWeb.Responsable
{
    public partial class NavWebResponsable : NavigatorForm
    {
        private CreateStep createStepView;
        public int countStep;
        public NavWebResponsable()
        {
            InitializeComponent();
        }

        private HtmlDocument initJsFile()
        {
            try
            {
                HtmlDocument doc = webBrowser.Document;
                HtmlElement head = doc.GetElementsByTagName("head")[0];
                HtmlElement script = doc.CreateElement("script");

                var path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/Responsable/CreateCanvas.js";
                var js = File.ReadAllText(path);
                script.SetAttribute("type", "text/javascript");
                script.InnerText = js;
                head.AppendChild(script);
                doc.InvokeScript("init");

                return doc;
            }
            catch
            {
                throw new Exception("No se pudo crear el documento.");
            }
        }

        private void addStep()
        {
            var doc = initJsFile();
            createStepView = new CreateStep(doc, this);
            createStepView.TopMost = true;
            createStepView.Show();
        }
        private void addStepBntt_Click(object sender, EventArgs e)
        {
            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                var model = new CreateTutorial();
                model.ShowDialog();
                if(model.DialogResult == DialogResult.OK)
                {
                    countStep = 0;
                    addStep();
                    addStepBntt.Visible = false;
                    endTutorialBtn.Visible = true;
                    addStepBtn.Visible = true;
                    countTxt.Visible = true;
                    countTxt.Text = countStep.ToString();
                    MessageBox.Show("Comenza la grabación del tutorial", "Comienza el Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Cargando, espere.");
        }

        private void endTutorialBtn_Click(object sender, EventArgs e)
        {
            addStepBntt.Visible = true;
            endTutorialBtn.Visible = false;
            addStepBtn.Visible = false;
            countTxt.Visible = false;
            createStepView.Close();
            webBrowser.Refresh();

            MessageBox.Show("Tutorial Terminado! Se guardaron "+ countStep.ToString() +" pasos", "Fin del Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addStepBtn_Click(object sender, EventArgs e)
        {
            addStep();
        }
    }
}