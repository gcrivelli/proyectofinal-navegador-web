using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public partial class Controles3 : Form
    {
        private AsistimeAppBar asistimeAppBar;
        private WebBrowser webBrowser;
        public Controles3()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Blue;

            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            asistimeAppBar = new AsistimeAppBar() {Parent = this };
            this.Controls.Add(asistimeAppBar);

            webBrowser = new WebBrowser()
            {
                Height = 1080 - Constants.AppBarHeight,
                Width = Constants.AppBarWidth,
                Parent = this
            };
            webBrowser.Location = new Point(0, Constants.AppBarHeight);
            this.Controls.Add(webBrowser);
        }

        private void Controles3_FormClosing(object sender, FormClosingEventArgs e) { }

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

        public void ShowMenu()
        {
            Controles2 mod = new Controles2() { Sarasa = this };
            this.Hide();
            mod.Show();
        }
    }
}
