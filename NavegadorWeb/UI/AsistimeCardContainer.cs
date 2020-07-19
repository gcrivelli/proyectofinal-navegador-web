using NavegadorWeb.Adult;
using NavegadorWeb.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeCardContainer : AsistimeContentPanel
    {
        public AsistimeCardContainer(List<Tour> tourList)
        {
            int i = 1;

            //MessageBox.Show("La cantidad de tours es: " + tourList.Count);

            foreach (Tour tour in tourList)
            {
                //MessageBox.Show("Tour " + tour.name);
                this.Controls.Add(new AsistimeTourCard(tour, 20, 50 + (i - 1) * 50 + 30) { Parent = this });
                i++;
            }
        }

        public void ReSize(int new_width,int new_height)
        {
            this.Height = new_height;
            this.Width = new_width;
            this.Dock = DockStyle.Right;
        }

        public void PlayTour(Tour tour)
        {
            //MessageBox.Show("pidieron un tour: " + tour.name);
            MenuAdult parent = this.Parent as MenuAdult;
            parent.PlayTour(tour);
        }
    }
}
