using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeTourCreation : AsistimeBaseForm
    {
        private AsistimeBasePopup tourCreation = null;
        private AsistimeBasePopup stepCreation = null;
        private AsistimeBasePopup validationCreation = null;
        private AsistimeBasePopup messageCreation = null;

        public AsistimeTourCreation()
        {
            this.Load += new System.EventHandler(this.AsistimeTourCreation_Load);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.TransparencyKey = Color.Green;
            this.BackColor = Color.Green;
        }

        private void AsistimeTourCreation_Load(object sender, EventArgs e)
        {
            AsistimeCreatePanel panel = new AsistimeCreatePanel();
            panel.Width = 700;
            panel.Height = 800;
            this.Controls.Add(panel);
            panel.BackColor = Color.White;
            panel.Location = new Point(this.Width / 2 - panel.Width / 2, this.Height / 2 - panel.Height / 2);

        }
    }
}
