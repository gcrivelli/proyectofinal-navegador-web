using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Models;
using NavegadorWeb.Responsable;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public partial class AsistimeAudioCreation : AsistimeBaseForm
    {
        AsistimeAudioPanel audioCreation;
        private Tour tour;

        NavigatorAssistant previousForm;
        public AsistimeAudioCreation(NavigatorAssistant form)
        {
            this.previousForm = form;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.TransparencyKey = Color.Green;
            this.BackColor = Color.Green;

            tour = new Tour();
            InitializeComponent();
        }

        private void AsistimeAudioCreation_Load(object sender, EventArgs e)
        {
            audioCreation = new AsistimeAudioPanel() { Parent = this };
            audioCreation.Width = 700;
            audioCreation.Height = 800;
            this.Controls.Add(audioCreation);
            audioCreation.BackColor = Color.White;
            audioCreation.Location = new Point(this.Width / 2 - audioCreation.Width / 2, this.Height / 2 - audioCreation.Height / 2);
            audioCreation.Hide();
        }

        public void AdvanceToAudio(String tourName, int stepCount)
        {
            this.Show();
            audioCreation.SetTour(tourName, stepCount);// tour.steps.Count);
            //formsCreation.Hide();
            audioCreation.Show();
        }
    }
}
