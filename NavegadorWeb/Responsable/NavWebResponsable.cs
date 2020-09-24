﻿using System;
using System.Windows.Forms;
using System.IO;
using NavegadorWeb.Models;
using System.Collections.Generic;
using NavegadorWeb.Controller;
using NavegadorWeb.UI;

namespace NavegadorWeb.Responsable
{
    public partial class NavWebResponsable : NavigatorForm2
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
            tour.user_id = Constants.user._id;
            var tourResponse = tourController.PostAsync(tour).Result;

            // post de los audios
            var allAudioResponse = true;
            for (int i = 0; i < countStep; i++)
            {
                var nameTourWithoutSpace = tour.name.Replace(" ", "");
                var audioName = "/Audio" + nameTourWithoutSpace + i + ".wav";
                var filename = Constants.audioPath + audioName;
                if (File.Exists(filename))
                {
                    allAudioResponse = allAudioResponse && tourController.PostAudio(filename, tourResponse._id, tourResponse.steps[i]._id).Result;
                }
            }

            addStepBntt.Visible = true;
            endTutorialBtn.Visible = false;
            addStepBtn.Visible = false;
            countTxt.Visible = false;
            createStepView.Close();
            webBrowser.Refresh();

            if (tourResponse._id != null && allAudioResponse)
                MessageBox.Show("Tutorial Terminado! Se guardaron " + countStep.ToString() + " pasos", "Fin del Tutorial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Un error ha ocurrido tratando de conectar al servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                url = webBrowser.Url.ToString()
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