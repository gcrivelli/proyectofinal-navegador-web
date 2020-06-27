using System;
using System.Windows.Forms;

namespace NavegadorWeb.Responsable
{
    public partial class CreateStep : Form
    {
        public CreateStep()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
