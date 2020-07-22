﻿using NavegadorWeb.Controller;
using NavegadorWeb.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public partial class NavigatorForm : Form
    {
        protected AsistimeAppBar asistimeAppBar;
        protected WebBrowser webBrowser;
        protected User user;
        public NavigatorForm()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.Width = Screen.PrimaryScreen.WorkingArea.Size.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Size.Height;


            asistimeAppBar = new AsistimeAppBar() {Parent = this };
            asistimeAppBar.Width = this.Width;
            this.Controls.Add(asistimeAppBar);

            webBrowser = new WebBrowser()
            {
                Parent = this,
                Url = new Uri("http://www.google.com.ar"),
                ScriptErrorsSuppressed = true
            };
            webBrowser.Width = this.Width;
            webBrowser.Height = this.Height - Constants.AppBarHeight;
            webBrowser.Location = new Point(0, Constants.AppBarHeight);
            webBrowser.Navigating += webBrowser_Navigating;
            this.Controls.Add(webBrowser);
            //this.FormBorderStyle = FormBorderStyle.none;
        }

        private void Controles3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void NavigateBack() { webBrowser.GoBack(); }

        public void NavigateUpdate() { webBrowser.Update(); }

        public void NavigateForward() { webBrowser.GoForward(); }

        public void Navigate(String address)
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
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        public virtual void ShowMenu() { }

        private void NavigatorForm_Load(object sender, EventArgs e)
        {
            int[] browserEmulationVersion = { 0, 7000, 8000, 8888, 9000, 9999, 10000, 10001, 11000, 11001 };
            var appName = Process.GetCurrentProcess().ProcessName + ".exe";

            WebBrowserHelper.FixBrowserVersion();
            WebBrowserHelper.FixBrowserVersion(appName);

            foreach (int i in browserEmulationVersion)
                WebBrowserHelper.FixBrowserVersion(appName, i);
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            asistimeAppBar.Navigating(webBrowser.Url.ToString());
        }

    }
}