using NavegadorWeb.Adult;
using NavegadorWeb.Responsable;
using NavegadorWeb.UI;
using System;
using System.Windows.Forms;

namespace NavegadorWeb.GeneralDisplay
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void responsableBnt_Click(object sender, EventArgs e)
        {
            NavWebResponsable mod = new NavWebResponsable();
            mod.Show();
        }

        private void adultBtn_Click(object sender, EventArgs e)
        {
            NavWebAdult mod = new NavWebAdult();
            mod.Show();
        }

        private void adminBnt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented view");
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
