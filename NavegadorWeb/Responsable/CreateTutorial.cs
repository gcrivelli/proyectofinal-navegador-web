using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.Responsable
{
    public partial class CreateTutorial : Form
    {
        public CreateTutorial()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Elija un nombre para el tutorial.", "Nombre Invalido",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
