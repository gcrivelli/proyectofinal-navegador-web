using NavegadorWeb.Adult;
using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeCardContainer : AsistimeMenuContent
    {
        List<Tour> TourList;
        MenuForm formAnterior;
        public AsistimeCardContainer(List<Tour> tourList, MenuForm form) : base()
        {
            formAnterior = form;
            TourList = tourList;
            ArrangeCardGrid();
        }

        public void PlayTour(Tour tour)
        {
            MenuAdult parent = this.formAnterior as MenuAdult;
            parent.PlayTour(tour);
        }

        private void ArrangeCardGrid()
        {
            this.Controls.Clear();

            if (!(TourList == null))
            {

                int i = 1;
                int CardsxLine = 1;
                while ((20 * i + Constants.TourCardWidth * i) < 1520)
                {
                    CardsxLine = i;
                    i++;
                }
                i = 1;

                int leftCards = this.TourList.Count;
                int line = 1;
                int y;
                int x;
                foreach (Tour tour in this.TourList)
                {
                    if(i <= CardsxLine)
                    {
                        x = 20 * i + Constants.TourCardWidth * (i - 1);
                        y = 20 * line + Constants.TourCardHeigth * (line - 1);
                        this.Controls.Add(new AsistimeTourCard(tour, x, y) { Parent = this });
                        i++;
                    }
                    else
                    {
                        i = 1;
                        line++;
                        x = 20 * i + Constants.TourCardWidth * (i - 1);
                        y = 20 * line + Constants.TourCardHeigth * (line - 1);
                        this.Controls.Add(new AsistimeTourCard(tour, x, y) { Parent = this });
                        i++;
                    }
                    
                }
            }
        }
    }
}
