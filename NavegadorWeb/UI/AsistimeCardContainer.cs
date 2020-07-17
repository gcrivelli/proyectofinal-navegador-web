using NavegadorWeb.Models;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeCardContainer : Panel
    {
        public AsistimeCardContainer()
        {
            BackColor = ColorTranslator.FromHtml(Constants.CardContainerBackground);
            //ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Width = 1515;
            Height = 1024;

            for (int i = 0; i < 10; i++)
            {
                /*Label label = new Label();
                label.Text = "sarasa";
                label.Location = new Point(20,50+(i-1)*50+30);
                this.Controls.Add(label);*/

                this.Controls.Add(new AsistimeTourCard(new Tour(), 20, 50 + (i - 1) * 50 + 30) { Parent = this });

            }
        }

        public void ReSize(int new_width,int new_height)
        {
            this.Height = new_height;
            this.Width = new_width;
            this.Dock = DockStyle.Right;
        }

        public void RealizarTour(Tour tour)
        {

        }
    }
}
