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
        //private AsistimeBasePopup tourCreation = null;
        private AsistimeBasePopup stepCreation = null;
        //private AsistimeBasePopup formsCreation = null;
        private AsistimeBasePopup messageCreation = null;

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
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.TransparencyKey = Color.Green;
            this.BackColor = Color.Green;

            tour = new Tour();
        }

        private void AsistimeTourCreation_Load(object sender, EventArgs e)
        {
            tourCreation = new AsistimeCreatePanel() { Parent = this};
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
            audioCreation.Hide();

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

        public void AdvanceToAudio()
        {
            audioCreation.SetTour(tour.name, 0);// tour.steps.Count);
            formsCreation.Hide();
            audioCreation.Show();
        }

        public void ConfirmStep()
        {
            audioCreation.Hide();
            NavigatorAssistant form = previousForm as NavigatorAssistant;
            //form.addStep();
            steps.Show();
        }

        public void AdvanceToForms()
        {
            steps.Hide();
            formsCreation.Show();
        }

        public void AdvanceToSteps(String name, String desc)
        {
            this.tour.name = name;
            this.tour.description = desc;
            steps.SetTour(tour.name, tour.description, 1);// tour.steps.Count);
            tourCreation.Hide();
            steps.Show();
        }

        public void BackToSteps()
        {
            formsCreation.Hide();
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
            NavigatorAssistant form = previousForm as NavigatorAssistant;
            form.BackToNavigation();
        }
    }
}
