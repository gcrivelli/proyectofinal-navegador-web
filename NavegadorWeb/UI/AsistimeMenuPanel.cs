using NavegadorWeb.Adult;
using NavegadorWeb.GeneralDisplay;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public class AsistimeMenuPanel : Panel
    {
        //AsistimeMenuButton profileMenuButton;
        AsistimeMenuButton myToursMenuButton;
        AsistimeMenuButton myAdultsMenuButton;
        AsistimeMenuButton backMenuButton;

        public AsistimeMenuPanel(Form parent)
        {
            InitializeComponent();
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Width = Constants.MenuWidth;
            Parent = parent;
            Height = 1024;
            //Height = Parent.Height;

            //profileMenuButton = new AsistimeMenuButton(this, Constants.profileMenuButton);
            //profileMenuButton.Click += new EventHandler(this.ShowProfile);
            //newToursMenuButton = new AsistimeMenuButton(this, Constants.newToursMenuButton);
            //newToursMenuButton.Click += new EventHandler(this.ShowNewTours);
            myToursMenuButton = new AsistimeMenuButton(this, Constants.myToursMenuButton);
            myToursMenuButton.Click += new EventHandler(this.ShowMyTours);
            myAdultsMenuButton = new AsistimeMenuButton(this, Constants.myAdultsButton);
            myAdultsMenuButton.Click += new EventHandler(this.ShowMyAdults);
            backMenuButton = new AsistimeMenuButton(this, Constants.backMenuButton);
            backMenuButton.Click += new EventHandler(this.ReturnToNavigation);

            //profileMenuButton.Location = new System.Drawing.Point(0, 0);
            //newToursMenuButton.Location = new System.Drawing.Point(0, 0);
            myToursMenuButton.Location = new System.Drawing.Point(0, 0);
            myAdultsMenuButton.Location = new System.Drawing.Point(0, Constants.MenuButtonHeight);
            backMenuButton.Location = new System.Drawing.Point(0, Constants.MenuButtonHeight * 2 );

            //this.Controls.Add(profileMenuButton);
            //this.Controls.Add(newToursMenuButton);
            this.Controls.Add(myToursMenuButton);
            this.Controls.Add(backMenuButton);

            this.myToursMenuButton.Activate();
            
        }

        
        private void ShowProfile(object sender, EventArgs e)
        {
            //this.profileMenuButton.Activate();
            this.myAdultsMenuButton.DeActivate();
            this.myToursMenuButton.DeActivate();
            MenuAdult parent = this.Parent as MenuAdult;
            parent.ShowProfile();
        }

        private void ShowNewTours(object sender, EventArgs e)
        {
            //this.profileMenuButton.DeActivate();
            this.myAdultsMenuButton.DeActivate();
            this.myToursMenuButton.DeActivate();
            MenuAdult parent = this.Parent as MenuAdult;
            parent.ShowNewTours();
        }

        private void ReturnToNavigation(object sender, EventArgs e)
        {
            //this.profileMenuButton.DeActivate();
            this.myAdultsMenuButton.DeActivate();
            this.myToursMenuButton.DeActivate();
            this.backMenuButton.Activate();
            MenuForm parent = this.Parent as MenuForm;
            parent.ReturnToNavigation();
        }

        private void ShowMyTours(object sender, EventArgs e)
        {
            //this.profileMenuButton.DeActivate();
            this.myAdultsMenuButton.DeActivate();
            this.myToursMenuButton.Activate();
            MenuForm parent = this.Parent as MenuForm;
            parent.ShowMyTours();
        }

        private void ShowMyAdults(object sender, EventArgs e)
        {
            this.myToursMenuButton.DeActivate();
            this.myAdultsMenuButton.Activate();
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
