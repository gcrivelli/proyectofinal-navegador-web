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

        private static AsistimeRoundButton NavBackButton = null;
        private static AsistimeRoundButton NavRefreshButton = null;
        private static AsistimeRoundButton NavForwardButton = null;
        private static AsistimeRoundButton NavProfileButton = null;
        AsistimeSearchBox searchTextBox;

        public AsistimeAppBar()
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Height = Constants.AppBarHeight;
            Width = Constants.AppBarWidth;

            this.Controls.Add(this.GetNavBackButton(20, 35));
            this.Controls.Add(this.GetNavRefreshButton(100, 20));
            this.Controls.Add(this.GetNavForwardButton(210, 35));
            this.Controls.Add(this.GetNavProfileButton(this.ClientSize.Width - 150, 20));
            this.BringFrontRefreshButton();

            searchTextBox = new AsistimeSearchBox()
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
            searchButton.Click += new EventHandler(this.Navigate);
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

        private void BringFrontRefreshButton()
        {
            NavRefreshButton.BringToFront();
        }

        private Control GetNavBackButton(int x, int y)
        {
            if (NavBackButton == null)
            {
                NavBackButton = new AsistimeRoundButton(98, 98, Constants.NavBackImage, Constants.NavBackHoverImage, Constants.NavBackClickedImage) { Parent = this.Parent };
                NavBackButton.Location = new Point(x, y);
            }
            NavBackButton.Click += new EventHandler(this.NavigateBack);
            return NavBackButton;
        }

        private void NavigateBack(object sender, EventArgs e)
        {
            Controles3 control = this.Parent as Controles3;
            control.NavigateBack();
        }

        private Control GetNavRefreshButton(int x, int y)
        {
            if (NavRefreshButton == null)
            {
                NavRefreshButton = new AsistimeRoundButton(128, 128, Constants.NavRefreshImage, Constants.NavRefreshHoverImage, Constants.NavRefreshClickedImage) { Parent = this.Parent };
                NavRefreshButton.Location = new Point(x, y);
            }
            NavRefreshButton.Click += new EventHandler(this.NavigateUpdate);
            return NavRefreshButton;
        }

        private void NavigateUpdate(object sender, EventArgs e)
        {
            Controles3 control = this.Parent as Controles3;
            control.NavigateUpdate();
        }

        private Control GetNavForwardButton(int x, int y)
        {
            if (NavForwardButton == null)
            {
                NavForwardButton = new AsistimeRoundButton(98, 98, Constants.NavForwardImage, Constants.NavForwardHoverImage, Constants.NavForwardClickedImage) { Parent = this.Parent };
                NavForwardButton.Location = new Point(x, y);
            }
            NavForwardButton.Click += new EventHandler(this.NavigateForward);
            return NavForwardButton;
        }
        private void NavigateForward(object sender, EventArgs e)
        {
            Controles3 control = this.Parent as Controles3;
            control.NavigateForward();
        }

        private Control GetNavProfileButton(int x, int y)
        {
            if (NavProfileButton == null)
            {
                NavProfileButton = new AsistimeRoundButton(128, 128, Constants.NavProfileImage, Constants.NavProfileHoverImage, Constants.NavProfileClickedImage) { Parent = this.Parent };
                NavProfileButton.Location = new Point(x, y);
            }
            NavProfileButton.Click += new EventHandler(this.ShowMenu);
            return NavProfileButton;
        }

        private void ShowMenu(object sender, EventArgs e)
        {
            Controles3 control = this.Parent as Controles3;
            control.ShowMenu();
        }

        private void Navigate(object sender, EventArgs e)
        {
            Controles3 control = this.Parent as Controles3;
            control.Navigate(this.searchTextBox.TextName);
        }

    }
}
