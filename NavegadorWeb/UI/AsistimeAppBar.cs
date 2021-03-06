﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public class AsistimeAppBar : Panel
    {

        public static AsistimeRoundButton NavBackButton = null;
        public static AsistimeRoundButton NavRefreshButton = null;
        public static AsistimeRoundButton NavForwardButton = null;
        public static AsistimeRoundButton NavProfileButton = null;
        public AsistimeSearchBox searchTextBox;

        public AsistimeAppBar()
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Height = Constants.AppBarHeight;
            Width = Constants.AppBarWidth;

            this.Controls.Add(this.GetNavBackButton(20, 15));
            this.Controls.Add(this.GetNavRefreshButton(130, 15));
            this.Controls.Add(this.GetNavForwardButton(240, 15));
            this.Controls.Add(this.GetNavProfileButton(this.ClientSize.Width - 150, 15));

            Label backLabel = new Label() { Text = "Atrás", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(backLabel, NavBackButton);
            this.Controls.Add(backLabel);
            Label refreshLabel = new Label() { Text = "Recargar", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(refreshLabel, NavRefreshButton);
            this.Controls.Add(refreshLabel);
            Label forwardLabel = new Label() { Text = "Adelante", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(forwardLabel, NavForwardButton);
            this.Controls.Add(forwardLabel);
            Label profileLabel = new Label() { Text = "Menú", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(profileLabel, NavProfileButton);
            this.Controls.Add(profileLabel);

            searchTextBox = new AsistimeSearchBox()
            {
                Font = Constants.TextBoxFont,
                TextName = Constants.SearchBoxText,
                Parent = this
            };
            searchTextBox.Location = new System.Drawing.Point(350, 37);
            searchTextBox.KeyDown += directionBox_KeyDown;
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

            AsistimeActionButton goGoogle = new AsistimeActionButton()
            {
                Font = Constants.ActionbuttonFont,
                ButtonText = "Google",
                Parent = this
            };
            goGoogle.Click += new EventHandler(this.NavigateToGoogle);
            goGoogle.Location = new System.Drawing.Point(searchTextBox.Location.X + searchTextBox.Width + searchButton.Width - 75, searchTextBox.Location.Y);
            this.Controls.Add(goGoogle);

            /*AsistimeActionButton seeToursButton = new AsistimeActionButton()
            {
                Font = Constants.ActionbuttonFont,
                ButtonText = Constants.SeeToursButtonText,
                Parent = this
            };
            seeToursButton.Location = new System.Drawing.Point(searchTextBox.Location.X, searchTextBox.Location.Y + 50);
            seeToursButton.Click += new EventHandler(ShowTour);
            this.Controls.Add(seeToursButton);*/

        }

        protected Control GetNavBackButton(int x, int y)
        {
            if (NavBackButton == null)
            {
                NavBackButton = new AsistimeRoundButton(98, 98, Constants.NavBackImage, Constants.NavBackHoverImage, Constants.NavBackClickedImage) { Parent = this.Parent };
                NavBackButton.Location = new Point(x, y);
            }
            NavBackButton.Click += new EventHandler(this.NavigateBack);
            return NavBackButton;
        }

        protected void NavigateBack(object sender, EventArgs e)
        {
            NavigatorForm control = this.Parent as NavigatorForm;
            control.NavigateBack();
        }

        protected Control GetNavRefreshButton(int x, int y)
        {
            if (NavRefreshButton == null)
            {
                NavRefreshButton = new AsistimeRoundButton(98, 98, Constants.NavRefreshImage, Constants.NavRefreshHoverImage, Constants.NavRefreshClickedImage) { Parent = this.Parent };
                NavRefreshButton.Location = new Point(x, y);
            }
            NavRefreshButton.Click += new EventHandler(this.NavigateUpdate);
            return NavRefreshButton;
        }

        protected void NavigateUpdate(object sender, EventArgs e)
        {
            NavigatorForm control = this.Parent as NavigatorForm;
            control.NavigateUpdate();
        }

        protected Control GetNavForwardButton(int x, int y)
        {
            if (NavForwardButton == null)
            {
                NavForwardButton = new AsistimeRoundButton(98, 98, Constants.NavForwardImage, Constants.NavForwardHoverImage, Constants.NavForwardClickedImage) { Parent = this.Parent };
                NavForwardButton.Location = new Point(x, y);
            }
            NavForwardButton.Click += new EventHandler(this.NavigateForward);
            return NavForwardButton;
        }
        protected void NavigateForward(object sender, EventArgs e)
        {
            NavigatorForm control = this.Parent as NavigatorForm;
            control.NavigateForward();
        }

        protected Control GetNavProfileButton(int x, int y)
        {
            if (NavProfileButton == null)
            {
                NavProfileButton = new AsistimeRoundButton(98, 98, Constants.NavProfileImage, Constants.NavProfileHoverImage, Constants.NavProfileClickedImage) { Parent = this.Parent };
                NavProfileButton.Location = new Point(x, y);
            }
            NavProfileButton.Click += new EventHandler(this.ShowMenu);
            return NavProfileButton;
        }

        protected void ShowMenu(object sender, EventArgs e)
        {
            NavigatorForm control = this.Parent as NavigatorForm;
            control.ShowMenu();
        }

        public void Navigate(object sender, EventArgs e)
        {
            NavigatorForm control = this.Parent as NavigatorForm;
            control.Navigate(this.searchTextBox.TextName);
        }

        public void NavigateToGoogle(object sender, EventArgs e)
        {
            NavigatorForm control = this.Parent as NavigatorForm;
            control.Navigate("www.google.com.ar");
        }
        
        /*protected void ShowTour(Object sender, EventArgs e)
        {
            NavigatorAdult control = this.Parent as NavigatorAdult;
            control.ShowTour();
        }*/

        public void Navigated(string url)
        {
            searchTextBox.TextName = url;
        }

        private void directionBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Navigate(sender, e);
            }
        }

        protected void Center_With(Label label, AsistimeRoundButton button)
        {
            int labelWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(label.Text, label.Font);
                labelWidth = (int)size.Width + 7;
            }
            label.Width = labelWidth;
            label.Location = new Point(button.Location.X + button.Width / 2 - labelWidth / 2, button.Location.Y + button.Width);
        }
    }
}
