using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Models;
using NavegadorWeb.Responsable;
using NavegadorWeb.UI;
using System.Collections.Generic;

namespace NavegadorWeb.Adult
{
    public partial class MenuAssistant : MenuForm
    {
        private AssistantCardContainer MyTours;
        private AssistantCardContainer NewTours;

        public MenuAssistant(List<Tour> tours, NavigatorAssistant form) : base(tours, form)
        {
            //InitializeComponent();

            menuPanel = new AsistimeMenuPanel(this) { Parent = this };
            menuPanel.Location = new System.Drawing.Point(0, 0);
            this.Controls.Add(menuPanel);

            MyTours = new AssistantCardContainer(tours, this) { Parent = this };
            contentPanel.Controls.Add(MyTours);

            NewTours = new AssistantCardContainer(null, this) { Parent = this };
            contentPanel.Controls.Add(NewTours);

            ShowMyTours();
        }

        public void ShowNewTours()
        {
            contentPanel.ShowControl(NewTours);
        }

        public override void ShowMyTours()
        {
            contentPanel.ShowControl(MyTours);
        }

    }
}
