﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace NavegadorWeb
{
    public partial class NavigatorForm2 : Form
    {
        string actualUrl = null;
        public NavigatorForm2()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        //Update the page
        private void updateButton_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        // Navigates to the URL in the address box when 
        // the Go button is clicked.
        private void goButton_Click(object sender, EventArgs e)
        {
            Navigate(directionBox.Text);
        }

        //Make responsive the size of the form
        protected void NavigatorForm_Resize(object sender, EventArgs e)
        {
            webBrowser.Width = this.Width - 20;
            webBrowser.Height = this.Height;
        }

        // Navigates to the URL in the address box when 
        // the ENTER key is pressed while the ToolStripTextBox has focus.
        protected void directionBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate(directionBox.Text);
            }
        }

        // Navigates to the given URL if it is valid.
        protected void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser.Navigate(new Uri(address));
                actualUrl = address;
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        // Updates the URL in TextBoxAddress upon navigation.

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if(actualUrl != webBrowser.Url.ToString())
                directionBox.Text = webBrowser.Url.ToString();
        }

        // Resolve error "not load images" 
        private void NavigatorForm_Load(object sender, EventArgs e)
        {
            int[] browserEmulationVersion = { 0, 7000, 8000, 8888, 9000, 9999, 10000, 10001, 11000, 11001 };
            var appName = Process.GetCurrentProcess().ProcessName + ".exe";

            // You may find messagebox.show, just for testing.
            //WebBrowserHelper.SetIE8KeyforWebBrowserControl(appName);

            WebBrowserHelper.FixBrowserVersion();
            WebBrowserHelper.FixBrowserVersion(appName);

            foreach(int i in browserEmulationVersion)
                WebBrowserHelper.FixBrowserVersion(appName, i);
        }
    }
}
