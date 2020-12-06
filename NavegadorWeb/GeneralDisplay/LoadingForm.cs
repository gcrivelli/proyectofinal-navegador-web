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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            pictureBoxLoad.Image = NavegadorWeb.Properties.Resources.loadingGif3;
            pictureBoxLoad.Location = new Point(this.Width / 2 - pictureBoxLoad.Width / 2, this.Height / 2 - pictureBoxLoad.Height / 2);
        }
    }
}
