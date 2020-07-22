using NavegadorWeb.Adult;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public class AsistimeMenuPanel : Panel
    {
        AsistimeMenuButton profileMenuButton;
        AsistimeMenuButton myToursMenuButton;
        AsistimeMenuButton newToursMenuButton;
        AsistimeMenuButton backMenuButton;

        public AsistimeMenuPanel(Form parent)
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Width = Constants.MenuWidth;
            Parent = parent;
            Height = 1024;
            //Height = Parent.Height;

            profileMenuButton = new AsistimeMenuButton(this, Constants.profileMenuButton);
            profileMenuButton.Click += new EventHandler(this.ShowProfile);
            newToursMenuButton = new AsistimeMenuButton(this, Constants.newToursMenuButton);
            newToursMenuButton.Click += new EventHandler(this.ShowNewTours);
            myToursMenuButton = new AsistimeMenuButton(this, Constants.myToursMenuButton);
            myToursMenuButton.Click += new EventHandler(this.ShowMyTours);
            backMenuButton = new AsistimeMenuButton(this, Constants.backMenuButton);
            backMenuButton.Click += new EventHandler(this.ReturnToNavigation);

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

        /*public void ActiveMenu(object sender)
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
            
        }*/

        
        
        
        
        
        
        
        
        
        
        
        
        private void ShowProfile(object sender, EventArgs e)
        {
            this.profileMenuButton.Activate();
            this.newToursMenuButton.DeActivate();
            this.myToursMenuButton.DeActivate();
            MenuAdult parent = this.Parent as MenuAdult;
            parent.ShowProfile();
        }

        private void ShowNewTours(object sender, EventArgs e)
        {
            this.profileMenuButton.DeActivate();
            this.newToursMenuButton.Activate();
            this.myToursMenuButton.DeActivate();
            MenuAdult parent = this.Parent as MenuAdult;
            parent.ShowNewTours();
        }

        private void ReturnToNavigation(object sender, EventArgs e)
        {
            this.profileMenuButton.DeActivate();
            this.newToursMenuButton.DeActivate();
            this.myToursMenuButton.DeActivate();
            this.backMenuButton.Activate();
            MenuAdult parent = this.Parent as MenuAdult;
            parent.ReturnToNavigation();
        }

        private void ShowMyTours(object sender, EventArgs e)
        {
            this.profileMenuButton.DeActivate();
            this.newToursMenuButton.DeActivate();
            this.myToursMenuButton.Activate();
            MenuAdult parent = this.Parent as MenuAdult;
            parent.ShowMyTours();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AsistimeMenuPanel
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AsistimeMenuPanel_Paint);
            this.Resize += new System.EventHandler(this.AsistimeMenuPanel_Resize);
            this.ResumeLayout(false);

        }

        private void AsistimeMenuPanel_Resize(object sender, EventArgs e)
        {
            
        }

        private void AsistimeMenuPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }

}
