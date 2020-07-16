using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeAppBar : Panel
    {
        public AsistimeAppBar()
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Height = Constants.AppBarHeight;
            Width = Constants.AppBarWidth;
            
            NavButtons navControl = new NavButtons() { Parent = this };
            this.Controls.Add(navControl.GetNavBackButton(20, 35));
            this.Controls.Add(navControl.GetNavRefreshButton(100, 20));
            this.Controls.Add(navControl.GetNavForwardButton(210, 35));
            this.Controls.Add(navControl.GetNavProfileButton(this.ClientSize.Width - 150, 20));
            navControl.BringFrontRefreshButton();

            AsistimeSearchBox searchTextBox = new AsistimeSearchBox()
            {
                Font = Constants.TextBoxFont,
                TextName = Constants.SearchBoxText,
                Parent = this
            };
            searchTextBox.Location = new System.Drawing.Point(330, 35);
            this.Controls.Add(searchTextBox);

            AsistimeActionButton searchButton = new AsistimeActionButton()
            {
                Font = Constants.ActionbuttonFont,
                ButtonText = Constants.SearchButtonText,
                Parent = this
            };
            searchButton.Location = new System.Drawing.Point(searchTextBox.Location.X + searchTextBox.Width, searchTextBox.Location.Y);
            this.Controls.Add(searchButton);

            AsistimeActionButton seeToursButton = new AsistimeActionButton()
            {
                Font = Constants.ActionbuttonFont,
                ButtonText = Constants.SeeToursButtonText,
                Parent = this
            };
            seeToursButton.Location = new System.Drawing.Point(searchTextBox.Location.X, searchTextBox.Location.Y + 50);
            this.Controls.Add(seeToursButton);
            
        }


    }
}
