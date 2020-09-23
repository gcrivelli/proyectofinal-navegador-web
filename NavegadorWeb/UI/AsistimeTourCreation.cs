using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Models;
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
        private AsistimeBasePopup tourCreation = null;
        private AsistimeBasePopup stepCreation = null;
        private AsistimeBasePopup validationCreation = null;
        private AsistimeBasePopup messageCreation = null;

        AsistimeCreatePanel tourName;
        AsistimeStepsPanel steps;
        private Tour tour;

        public AsistimeTourCreation()
        {
            this.Load += new System.EventHandler(this.AsistimeTourCreation_Load);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.TransparencyKey = Color.Green;
            this.BackColor = Color.Green;

            tour = new Tour();
        }

        private void AsistimeTourCreation_Load(object sender, EventArgs e)
        {
            tourName = new AsistimeCreatePanel() { Parent = this };
            tourName.Width = 700;
            tourName.Height = 800;
            this.Controls.Add(tourName);
            tourName.BackColor = Color.White;
            tourName.Location = new Point(this.Width / 2 - tourName.Width / 2, this.Height / 2 - tourName.Height / 2);

            steps = new AsistimeStepsPanel() { Parent = this };
            steps.Width = 700;
            steps.Height = 800;
            this.Controls.Add(steps);
            steps.BackColor = Color.White;
            steps.Location = new Point(this.Width / 2 - steps.Width / 2, this.Height / 2 - steps.Height / 2);
            steps.Hide();

        }

        public void AdvanceToSteps(String name, String desc)
        {
            this.tour.name = name;
            this.tour.description = desc;
            steps.SetTour(tour.name, tour.description);
            tourName.Hide();
            steps.Show();
        }

        public void BackToTour()
        {
            steps.Hide();
            tourName.Show();
        }
    }
}
