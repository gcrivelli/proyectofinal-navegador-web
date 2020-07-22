using NavegadorWeb.Models;
using NavegadorWeb.UI;
using System.Windows.Forms;

namespace NavegadorWeb.GeneralDisplay
{
    public partial class MenuForm : AsistimeBaseForm
    {
        protected User user;
        protected NavigatorForm previousForm;
        protected AsistimeMenuPanel menuPanel;
        protected AsistimeContentPanel contentPanel;
        protected Panel profile;

        public MenuForm(User user, NavigatorForm form)
        {
            InitializeComponent();
            this.user = user;
            this.previousForm = form;

            WindowState = FormWindowState.Maximized;
            this.Width = Screen.PrimaryScreen.WorkingArea.Size.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Size.Height;

            contentPanel = new AsistimeContentPanel();
            contentPanel.Location = new System.Drawing.Point(Constants.MenuWidth, 0);
            this.Controls.Add(contentPanel);

            profile = new Panel();

            MaximizeBox = false;

        }

        private void MenuForm_Load(object sender, System.EventArgs e)
        {

        }

        public void ReturnToNavigation()
        {
            this.Hide();
            previousForm.Show();
        }

        public void ShowProfile()
        {
            contentPanel.ShowControl(profile);
        }

        protected void Exit()
        {
            Application.Exit();
        }

        protected void Minimize()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        protected void Collapse()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
