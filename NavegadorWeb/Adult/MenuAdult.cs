using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Models;
using NavegadorWeb.UI;
using System.Collections.Generic;

namespace NavegadorWeb.Adult
{
    public partial class MenuAdult : MenuForm
    {
        private AsistimeCardContainer MyTours;
        private AsistimeCardContainer NewTours;

        public MenuAdult(List<Tour> tours, NavigatorAdult form) : base(tours, form)
        {
            InitializeComponent();

            menuPanel = new AsistimeMenuPanel(this) { Parent = this };
            menuPanel.Location = new System.Drawing.Point(0, 0);
            this.Controls.Add(menuPanel);

            MyTours = new AsistimeCardContainer(tours, this) { Parent = this };
            contentPanel.Controls.Add(MyTours);

            NewTours = new AsistimeCardContainer(null, this) { Parent = this };
            contentPanel.Controls.Add(NewTours);

            ShowMyTours();
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
