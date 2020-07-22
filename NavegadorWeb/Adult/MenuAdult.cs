using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Models;
using NavegadorWeb.UI;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NavegadorWeb.Adult
{
    public partial class MenuAdult : MenuForm
    {
        private AsistimeCardContainer MyTours;
        private AsistimeCardContainer NewTours;

        public MenuAdult(User user, NavigatorAdult form) : base(user,form)
        {
            InitializeComponent();

            menuPanel = new AsistimeMenuPanel(this) { Parent = this };
            menuPanel.Location = new System.Drawing.Point(0, 0);
            this.Controls.Add(menuPanel);

            MyTours = new AsistimeCardContainer(user.tours, this) { Parent = this };
            contentPanel.Controls.Add(MyTours);

            NewTours = new AsistimeCardContainer(null, this) { Parent = this };
            contentPanel.Controls.Add(NewTours);

            ShowProfile();
        }

        public void ShowNewTours()
        {
            contentPanel.ShowControl(NewTours);
        }

        public void ShowMyTours()
        {
            contentPanel.ShowControl(MyTours);
        }

        public void PlayTour(Tour tour)
        {
            this.Hide();
            NavigatorAdult form = previousForm as NavigatorAdult;
            form.PlayTour(tour);
        }

    }
}
