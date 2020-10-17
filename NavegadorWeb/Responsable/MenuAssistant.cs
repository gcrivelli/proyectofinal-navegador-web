using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Models;
using NavegadorWeb.Responsable;
using NavegadorWeb.UI;
using System.Collections.Generic;

namespace NavegadorWeb.Adult
{
    public partial class MenuAssistant : MenuForm
    {
        private AsistimeCardContainer MyTours;
        private AsistimeCardContainer NewTours;

        public MenuAssistant(List<Tour> tours, NavigatorAssistant form) : base(tours, form)
        {
            //InitializeComponent();

            menuPanel = new AsistimeMenuPanel(this) { Parent = this };
            menuPanel.Location = new System.Drawing.Point(0, 0);
            this.Controls.Add(menuPanel);

            MyTours = new AsistimeCardContainer(tours, this) { Parent = this };
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

    }
}
