using NavegadorWeb.GeneralDisplay;
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
            /*this.BackColor = Color.Black;
            this.Opacity = 0.5;*/
            this.FormBorderStyle = FormBorderStyle.None;

            /*this.TransparencyKey = Color.Blue;
            this.BackColor = Color.Blue;*/
        }

        private void AsistimeTourCreation_Load(object sender, EventArgs e)
        {




            AsistimeMultilineTextbox multi = new AsistimeMultilineTextbox();
            multi.Location = new Point(100,100);
            this.Controls.Add(multi);
            multi.BringToFront();

        }
    }
}
