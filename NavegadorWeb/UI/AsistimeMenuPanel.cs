using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeMenuPanel : Panel
    {
        AsistimeMenuButton profileMenuButton;
        AsistimeMenuButton myToursMenuButton;
        AsistimeMenuButton newToursMenuButton;
        AsistimeMenuButton backMenuButton;

        public AsistimeMenuPanel(Form parent)
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Height = 1024;
            Width = Constants.MenuWidth;
            Parent = parent;

            profileMenuButton = new AsistimeMenuButton(this, Constants.profileMenuButton);
            newToursMenuButton = new AsistimeMenuButton(this, Constants.newToursMenuButton);
            myToursMenuButton = new AsistimeMenuButton(this, Constants.myToursMenuButton);
            backMenuButton = new AsistimeMenuButton(this, Constants.backMenuButton);

            profileMenuButton.Location = new System.Drawing.Point(0, 0);
            newToursMenuButton.Location = new System.Drawing.Point(0, Constants.MenuButtonHeight);
            myToursMenuButton.Location = new System.Drawing.Point(0, Constants.MenuButtonHeight * 2);
            backMenuButton.Location = new System.Drawing.Point(0, Constants.MenuButtonHeight * 3);

            this.Controls.Add(profileMenuButton);
            this.Controls.Add(newToursMenuButton);
            this.Controls.Add(myToursMenuButton);
            this.Controls.Add(backMenuButton);

            this.profileMenuButton.Activate();

            /*this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;*/
        }
        public void ReSize(int new_height)
        {
            this.Height = new_height;
            this.Dock = DockStyle.Left;
        }

        public void ActiveMenu(object sender)
        {
            AsistimeMenuButton botonActivo = sender as AsistimeMenuButton;

            switch(botonActivo.Text)
            {
                case Constants.profileMenuButton:
                    this.profileMenuButton.Activate();
                    this.newToursMenuButton.DeActivate();
                    this.myToursMenuButton.DeActivate();
                    break;
                case Constants.newToursMenuButton:
                    this.profileMenuButton.DeActivate();
                    this.newToursMenuButton.Activate();
                    this.myToursMenuButton.DeActivate();
                    break;
                case Constants.myToursMenuButton:
                    this.profileMenuButton.DeActivate();
                    this.newToursMenuButton.DeActivate();
                    this.myToursMenuButton.Activate();
                    break;
                case Constants.backMenuButton:
                    this.profileMenuButton.DeActivate();
                    this.newToursMenuButton.DeActivate();
                    this.myToursMenuButton.DeActivate();
                    this.backMenuButton.Activate();
                    break;
            }

            if(botonActivo.Active)
            {
                Controles2 form = this.Parent as Controles2;
                form.ActiveMenu(botonActivo);
            }
            
        }

    }

}
