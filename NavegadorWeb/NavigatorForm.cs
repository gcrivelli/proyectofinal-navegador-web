using NavegadorWeb.Controller;
using System;
using System.Windows.Forms;

namespace NavegadorWeb
{
    public partial class NavigatorForm : Form
    {
        public NavigatorForm()
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

        private void updateButton_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate(directionBox.Text);
        }

        private void NavigatorForm_Resize(object sender, EventArgs e)
        {
            webBrowser.Width = this.Width - 20;
            webBrowser.Height = this.Height;
        }

        private void whoAreButton_Click(object sender, EventArgs e)
        {
            var a = new TutorialController();
            var request = a.Get("https://proyecto-final-navegador-web.herokuapp.com/api/people");
            MessageBox.Show(request);
        }
    }
}
