using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Models;
using NavegadorWeb.Responsable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeTourCreation : AsistimeBaseForm
    {
        AsistimeCreatePanel tourCreation;
        AsistimeStepsPanel steps;
        AsistimeFormsPanel formsCreation;
        AsistimeAudioPanel audioCreation;
        private Tour tour;

        NavigatorAssistant previousForm;

        public AsistimeTourCreation(NavigatorAssistant form)
        {
            this.previousForm = form;
            this.Load += new System.EventHandler(this.AsistimeTourCreation_Load);
            //this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.TransparencyKey = Color.Green;
            this.BackColor = Color.Green;

            tour = new Tour();
        }

        private void AsistimeTourCreation_Load(object sender, EventArgs e)
        {
            /*tourCreation = new AsistimeCreatePanel() { Parent = this};
            tourCreation.Width = 700;
            tourCreation.Height = 800;
            this.Controls.Add(tourCreation);
            tourCreation.BackColor = Color.White;
            tourCreation.Location = new Point(this.Width / 2 - tourCreation.Width / 2, this.Height / 2 - tourCreation.Height / 2);

            steps = new AsistimeStepsPanel() { Parent = this};
            steps.Width = 700;
            steps.Height = 800;
            this.Controls.Add(steps);
            steps.BackColor = Color.White;
            steps.Location = new Point(this.Width / 2 - steps.Width / 2, this.Height / 2 - steps.Height / 2);
            steps.Hide();

            formsCreation = new AsistimeFormsPanel() { Parent = this};
            formsCreation.Width = 700;
            formsCreation.Height = 800;
            this.Controls.Add(formsCreation);
            formsCreation.BackColor = Color.White;
            formsCreation.Location = new Point(this.Width / 2 - formsCreation.Width / 2, this.Height / 2 - formsCreation.Height / 2);
            formsCreation.Hide();

            audioCreation = new AsistimeAudioPanel() { Parent = this};
            audioCreation.Width = 700;
            audioCreation.Height = 800;
            this.Controls.Add(audioCreation);
            audioCreation.BackColor = Color.White;
            audioCreation.Location = new Point(this.Width / 2 - audioCreation.Width / 2, this.Height / 2 - audioCreation.Height / 2);
            audioCreation.Hide();*/


            HowToTour howToTour = new HowToTour() { Parent = this };
            HowToSteps howToSteps = new HowToSteps();
            HowToForms howToForms = new HowToForms();
            HowToAudio howToAudio = new HowToAudio();
            howToTour.Location = new Point(this.Width / 2 - howToTour.Width / 2, this.Height / 2 - howToTour.Height / 2);
            howToSteps.Location = new Point(this.Width / 2 - howToSteps.Width / 2, this.Height / 2 - howToSteps.Height / 2);
            howToForms.Location = new Point(this.Width / 2 - howToForms.Width / 2, this.Height / 2 - howToForms.Height / 2);
            howToAudio.Location = new Point(this.Width / 2 - howToAudio.Width / 2, this.Height / 2 - howToAudio.Height / 2);
            this.Controls.Add(howToTour);
            this.Controls.Add(howToSteps);
            this.Controls.Add(howToForms);
            this.Controls.Add(howToAudio);
            howToTour.next = howToSteps;
            howToSteps.previous = howToTour;
            howToSteps.next = howToForms;
            howToForms.previous = howToSteps;
            howToForms.next = howToAudio;
            howToAudio.previous = howToForms;
            howToTour.Show();

            tourCreation = new AsistimeCreatePanel() { Parent = this };
            this.Controls.Add(tourCreation);
            tourCreation.BackColor = Color.White;
            tourCreation.Location = new Point(this.Width / 2 - tourCreation.Width / 2, this.Height / 2 - tourCreation.Height / 2);
            tourCreation.Hide();

            audioCreation = new AsistimeAudioPanel() { Parent = this };
            audioCreation.Width = 700;
            audioCreation.Height = 800;
            this.Controls.Add(audioCreation);
            audioCreation.BackColor = Color.White;
            audioCreation.Location = new Point(this.Width / 2 - audioCreation.Width / 2, this.Height / 2 - audioCreation.Height / 2);
            audioCreation.Hide();
        }

        public void CloseForm()
        {
            this.Close();
        }

        public void ConfirmTour()
        {
            steps.Hide();
            //TODO: agregar confirmación de tour
        }

        public void BackToForms()
        {
            audioCreation.Hide();
            formsCreation.Show();
        }

        public void AdvanceToAudio(String toruName, int stepCount)
        {
            this.Show();
            audioCreation.SetTour(toruName, stepCount);// tour.steps.Count);
            //formsCreation.Hide();
            audioCreation.Show();
        }

        public void ConfirmStep()
        {
            audioCreation.Hide();
            //steps.Show();
        }

        public void AdvanceToForms()
        {
            //NavigatorAssistant form = previousForm as NavigatorAssistant;
            previousForm.addStepToTour();
            steps.Hide();
            formsCreation.Show();
        }

        public void AdvanceToSteps(String name, String desc)
        {
            previousForm.setTourName(name, desc);
            //tourCreation.Hide();
            //steps.Show();
            tourCreation.Hide();
            this.Hide();
            previousForm.showTourBar();
        }

        public void BackToSteps()
        {
            previousForm.cancelLastStep();
            formsCreation.Hide();
            steps.cancelLastStep();
            steps.Show();
        }

        public void BackToTour()
        {
            steps.Hide();
            tourCreation.Show();
        }

        public void BackToNavigation()
        {
            this.Hide();
            //previousForm.cancelLastTour();
            previousForm.BackToNavigation();
        }

        public void drawForm(String form)
        {
            formsCreation.Hide();
            previousForm.drawForm(form);
        }

        public void GoToTour()
        {
            tourCreation.Show();
        }
    }

    class AsistimeTourAssign : AsistimeBaseForm
    {
        public Tour tour;
        AssistantTourCard previousForm;

        public AsistimeTourAssign(AssistantTourCard form, Tour tour)
        {
            this.previousForm = form;
            this.Load += new System.EventHandler(this.AsistimeTourAssign_Load);
            //this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.TransparencyKey = Color.Green;
            this.BackColor = Color.Green;

            this.tour = tour;
        }

        private void AsistimeTourAssign_Load(object sender, EventArgs e)
        {
            TutorialAssign asignTourPanel = new TutorialAssign() { Parent = this};
            asignTourPanel.Location = new Point(this.Width / 2 - asignTourPanel.Width / 2, this.Height / 2 - asignTourPanel.Height / 2);
            this.Controls.Add(asignTourPanel);
            asignTourPanel.Show();

        }

        public void CloseForm()
        {
            this.Close();
        }


    }

 }
