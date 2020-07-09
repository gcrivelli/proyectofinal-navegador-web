using NavegadorWeb.Controller;
using NavegadorWeb.Models;
using System;
using System.Windows;

namespace NavegadorWeb.Adult
{
    public partial class NavWebAdult : NavigatorForm
    {
        public NavWebAdult()
        {
            InitializeComponent();
        }

        private void viewTutorialBtn_Click(object sender, EventArgs e)
        {
            var tourController = new TourController();
            var tour = tourController.GetAsync(textBox1.Text).Result;
            MessageBox.Show(tour.name + ", " + tour.description);
        }
    }
}
