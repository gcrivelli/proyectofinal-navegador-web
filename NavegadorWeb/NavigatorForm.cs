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
        private void NavigatorForm_Resize(object sender, EventArgs e)
        {
            webBrowser.Width = this.Width - 20;
            webBrowser.Height = this.Height;
        }

        //Get from the API
        private void whoAreButton_Click(object sender, EventArgs e)
        {
            var a = new TutorialController();
            var request = a.Get("https://proyecto-final-navegador-web.herokuapp.com/api/people");
            MessageBox.Show(request);
        }

        // Navigates to the URL in the address box when 
        // the ENTER key is pressed while the ToolStripTextBox has focus.
        private void directionBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate(directionBox.Text);
            }
        }

        // Navigates to the given URL if it is valid.
        private void Navigate(String address)
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

        // Updates the URL in TextBoxAddress upon navigation.
        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            directionBox.Text = webBrowser.Url.ToString();
        }

    }
}
