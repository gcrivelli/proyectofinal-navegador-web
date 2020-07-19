using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Models;
using NavegadorWeb.UI;
using System.Windows;

namespace NavegadorWeb.Adult
{
    public partial class MenuAdult : MenuForm
    {
        private AsistimeMenuPanel asistimeMenuPanel;
        private AsistimeCardContainer asistimeCardContainer;

        public MenuAdult(User user, NavigatorAdult form) : base(user,form)
        {
            asistimeMenuPanel = new AsistimeMenuPanel(this) { Parent = this };
            asistimeMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.Controls.Add(asistimeMenuPanel);

            asistimeCardContainer = new AsistimeCardContainer(user.tours) { Parent = this };
            asistimeCardContainer.Location = new System.Drawing.Point(Constants.MenuWidth, 0);
            this.Controls.Add(asistimeCardContainer);
            asistimeCardContainer.Hide();

            InitializeComponent();
        }

        public void ShowNewTours()
        {
            asistimeCardContainer.Hide();
        }

        public void ShowMyTours()
        {
            asistimeCardContainer.Show();
        }

        public void PlayTour(Tour tour)
        {
            this.Hide();
            NavigatorAdult form = previousForm as NavigatorAdult;
            form.PlayTour(tour);
        }

    }
}
