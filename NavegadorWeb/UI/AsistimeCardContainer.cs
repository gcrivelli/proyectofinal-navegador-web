using Bunifu.Framework.UI;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

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
            BunifuThinButton2 sarasa = new BunifuThinButton2();
            AsistimeActionButton sarasa2 = new AsistimeActionButton();
            BunifuThinButton2 sarasa3 = new BunifuThinButton2();

            sarasa2.Location = new System.Drawing.Point(0, 240);
            sarasa3.Location = new System.Drawing.Point(0, 280);

            sarasa.Location = new System.Drawing.Point(0, 200);
            botoncito2.Location = new System.Drawing.Point(200, 200);

            sarasa.IdleLineColor = sarasa.ActiveLineColor;
            this.Controls.Add(botoncito);
            this.Controls.Add(botoncito2);
            this.Controls.Add(sarasa);
            this.Controls.Add(sarasa2);
            this.Controls.Add(sarasa3);

            AsistimeSearchBox testbox1 = new AsistimeSearchBox();
            BunifuMaterialTextbox textbox2 = new BunifuMaterialTextbox();
            BunifuMetroTextbox textbox3 = new BunifuMetroTextbox();
            BunifuCustomTextbox textbox4 = new BunifuCustomTextbox();
            testbox1.Location = new System.Drawing.Point(400, 200);
            textbox2.Location = new System.Drawing.Point(400, 240);
            textbox3.Location = new System.Drawing.Point(400, 280);
            textbox4.Location = new System.Drawing.Point(400, 320);
            //testbox1.BackColor = Color.Transparent;
            this.Controls.Add(testbox1);
            this.Controls.Add(textbox2);
            this.Controls.Add(textbox3);
            this.Controls.Add(textbox4);
        }

        public void ReSize(int new_width,int new_height)
        {
            this.Height = new_height;
            this.Width = new_width;
            this.Dock = DockStyle.Right;
        }
    }
}
