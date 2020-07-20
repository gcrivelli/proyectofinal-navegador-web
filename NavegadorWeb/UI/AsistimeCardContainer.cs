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
            AutoScroll = true;

            foreach (Tour tour in tourList)
            {
                //MessageBox.Show("Tour " + tour.name);
                int x = 20;
                int y = 20 * (i + 1) + 400 * (i - 1);
                this.Controls.Add(new AsistimeTourCard(tour, x, y) { Parent = this, count = i });
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
