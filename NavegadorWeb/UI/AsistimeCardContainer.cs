using Bunifu.Framework.UI;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            BunifuImageButton botoncito = new BunifuImageButton();
            BunifuImageButton botoncito2 = new BunifuImageButton();
            botoncito2.Location = new System.Drawing.Point(200, 200);
            this.Controls.Add(botoncito);
            this.Controls.Add(botoncito2);
        }

        public void ReSize(int new_width,int new_height)
        {
            this.Height = new_height;
            this.Width = new_width;
            this.Dock = DockStyle.Right;
        }
    }
}
