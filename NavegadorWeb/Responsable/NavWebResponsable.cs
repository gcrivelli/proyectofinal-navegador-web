using System;
using System.Windows.Forms;
using System.IO;
using NavegadorWeb.Models;
using System.Collections.Generic;
using NavegadorWeb.Controller;

namespace NavegadorWeb.Responsable
{
    public partial class NavWebResponsable : NavigatorForm
    {
        private CreateStep createStepView;
        public int countStep;
        public Tour tour;

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

        private void initStep()
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
                    //Init all the tour components
                    tour = new Tour()
                    {
                        steps = new List<Step>(),
                        name = model.nameTxt.Text,
                        description = model.descTxt.Text,
                        active = true
                    };

                    countStep = 0;
                    countTxt.Text = countStep.ToString();

                    initStep();

                    addStepBntt.Visible = false;
                    endTutorialBtn.Visible = true;
                    addStepBtn.Visible = true;
                    countTxt.Visible = true;

                    MessageBox.Show("Comenza la grabación del tutorial", "Comienza el Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Cargando, espere.");
        }

        private void endTutorialBtn_Click(object sender, EventArgs e)
        {
            // post del tour
            var tourController = new TourController();
            tour.user_id = "5f0907dd5d988f31d515dc72";
            var response = tourController.PostAsync(tour);

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
            initStep();
            addStepBtn.Enabled = false;
        }

        public void addStepToTour()
        {
            //cargar audio --> URL 

            var step = new Step()
            {
                order = countStep,
                elements = new List<Element>(),
                url = webBrowser.Url.ToString(),
                audio_url = webBrowser.Url.ToString()
            };

            tour.steps.Add(step);
        }

        public void incrementStepCount()
        {
            countStep++;
            countTxt.Text = countStep.ToString();
        }
    }
}