using NavegadorWeb.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.Adult
{
    class AdultAppBar : AsistimeAppBar
    {
        public static AsistimeRoundButton AsistimeButton = null;

        public AdultAppBar()
        {
            this.Controls.Add(this.GetAsistimeButton(this.ClientSize.Width - 300, 15));

            Label asistimeLabel = new Label() { Text = "Asistime", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(asistimeLabel, AsistimeButton);
            this.Controls.Add(asistimeLabel);
        }

        protected Control GetAsistimeButton(int x, int y)
        {
            if (AsistimeButton == null)
            {
                AsistimeButton = new AsistimeRoundButton(98, 98, Constants.AsistimeImage, Constants.AsistimeHoverImage, Constants.AsistimeClickImage) { Parent = this.Parent };
                AsistimeButton.Location = new Point(x, y);
            }
            AsistimeButton.Click += new EventHandler(this.Asistime);
            return AsistimeButton;
        }

        protected void Asistime(object sender, EventArgs e)
        {
            NavigatorAdult control = this.Parent as NavigatorAdult;
            control.Asistime();
        }
    }
}
