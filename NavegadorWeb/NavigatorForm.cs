using Microsoft.Win32;
using NavegadorWeb.Controller;
using System;
using System.Diagnostics;
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

        // Resolve error "not load images" 
        private void NavigatorForm_Load(object sender, EventArgs e)
        {
            var appName = Process.GetCurrentProcess().ProcessName + ".exe";

            // You may find messagebox.show, just for testing.
            // SetIE8KeyforWebBrowserControl(appName);

            WebBrowserHelper.FixBrowserVersion();
            WebBrowserHelper.FixBrowserVersion(appName);
            WebBrowserHelper.FixBrowserVersion(appName, 11001);
        }

        // Show the code of IE error
        private void SetIE8KeyforWebBrowserControl(string appName)
        {
            RegistryKey Regkey = null;
            try
            {
                // For 64 bit machine
                if (Environment.Is64BitOperatingSystem)
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                else  //For 32 bit machine
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);

                // If the path is not correct or
                // if the user haven't priviledges to access the registry
                if (Regkey == null)
                {
                    MessageBox.Show("Application Settings Failed - Address Not found");
                    return;
                }

                string FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                // Check if key is already present
                if (FindAppkey == "8000")
                {
                    MessageBox.Show("Required Application Settings Present");
                    Regkey.Close();
                    return;
                }

                // If a key is not present add the key, Key value 8000 (decimal)
                if (string.IsNullOrEmpty(FindAppkey))
                    Regkey.SetValue(appName, unchecked((int)0x1F40), RegistryValueKind.DWord);

                // Check for the key after adding
                FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                if (FindAppkey == "8000")
                    MessageBox.Show("Application Settings Applied Successfully");
                else
                    MessageBox.Show("Application Settings Failed, Ref: " + FindAppkey);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application Settings Failed");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close the Registry
                if (Regkey != null)
                    Regkey.Close();
            }
        }
    }
}
