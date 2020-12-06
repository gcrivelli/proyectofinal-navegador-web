using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.GeneralDisplay
{
    public partial class AsistimeBaseForm : Form
    {
        public AsistimeBaseForm()
        {
            MaximizeBox = false;
            WindowState = FormWindowState.Maximized;
            //this.Width = Screen.PrimaryScreen.WorkingArea.Size.Width;
            //this.Height = Screen.PrimaryScreen.WorkingArea.Size.Height;
            this.Text = "Asistime";

            InitializeComponent();
        }

        private void AsistimeBaseForm_Load(object sender, EventArgs e)
        {
            
        }

        /*private void AsistimeBaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }*/
    }
}
