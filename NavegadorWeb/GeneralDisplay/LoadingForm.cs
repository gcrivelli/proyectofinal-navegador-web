using System;
using System.Drawing;
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
            pictureBoxLoad.Location = new Point(this.Width / 2 - 150, this.Height / 2 - 130);
        }
    }
}
