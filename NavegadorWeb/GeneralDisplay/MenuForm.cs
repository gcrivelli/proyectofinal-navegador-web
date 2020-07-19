using NavegadorWeb.Models;
using NavegadorWeb.UI;
using System.Windows.Forms;

namespace NavegadorWeb.GeneralDisplay
{
    public partial class MenuForm : Form
    {
        protected User user;
        protected NavigatorForm previousForm;
        protected AsistimeMenuPanel menuPanel;
        protected AsistimeContentPanel contentPanel;

        public MenuForm(User user, NavigatorForm form)
        {
            this.user = user;
            this.previousForm = form;

            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, System.EventArgs e)
        {

        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void ReturnToNavigation()
        {
            this.Hide();
            previousForm.Show();
        }

        public void ShowProfile()
        {

        }
    }
}
