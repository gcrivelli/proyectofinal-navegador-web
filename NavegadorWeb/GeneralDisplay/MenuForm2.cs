using NavegadorWeb.Models;
using NavegadorWeb.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.GeneralDisplay
{
    public partial class MenuForm2 : AsistimeBaseForm
    {
        protected List<Tour> tours;
        protected NavigatorForm previousForm;
        protected AsistimeRoundButton backButton = null;
        protected AsistimeRoundButton assistButton;
        protected AsistimeRoundButton addAdultButton;

        public MenuForm2(List<Tour> tours, NavigatorForm form)
        {
            InitializeComponent();
            this.tours = tours;
            this.previousForm = form;
            MaximizeBox = false;

            

        }

        private void MenuForm_Load(object sender, System.EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml(Constants.AppMenuBackgroundColour);
            AutoScroll = true;

            AddBackButton();

            if (Constants.user.rol == "Adulto")
            {
               
            }
            else if (Constants.user.rol == "Responsable")
            {
                
            }
            ArrangeCardGrid();
        }

        protected void AddBackButton()
        {
            backButton = new AsistimeRoundButton(98, 98, Constants.AddTourImage, Constants.AddTourHoverImage, Constants.AddTourClickImage) { Parent = this };
            backButton.Location = new Point(10, 10);
            backButton.Click += new EventHandler(this.ReturnToNavigation);
            this.Controls.Add(backButton);
            Label backLabel = new Label() { Text = "Volver", ForeColor = Color.Black, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(backLabel, backButton);
            backButton.BringToFront();
            this.Controls.Add(backLabel);
        }

        protected void ReturnToNavigation(object sender, EventArgs e)
        {
            this.Hide();
            previousForm.Show();
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public virtual void ShowMyTours() { }

        protected void Minimize()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        protected void Collapse()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void ArrangeCardGrid()
        {
            this.Controls.Clear();

            if (!(this.tours == null))
            {

                int i = 1;
                int CardsxLine = 1;
                while ((20 * i + Constants.TourCardWidth * i) < this.Width)
                {
                    CardsxLine = i;
                    i++;
                }
                var maxCardsAllowed = i-1;
                var maxWidthCards = maxCardsAllowed * Constants.TourCardWidth;
                var spaceBeforeCards = (this.Width - maxWidthCards - 20 * (maxCardsAllowed - 1)) / 2;
                i = 1;

                int line = 1;
                int y;
                int x;
                foreach (Tour tour in this.tours)
                {
                    if (i <= CardsxLine)
                    {
                        x = spaceBeforeCards + 20 * (i-1) + Constants.TourCardWidth * (i - 1);
                        y = 200 + 20 * (line-1) + Constants.TourCardHeigth * (line - 1);

                        if (Constants.user.rol == "Adulto")
                        {
                            this.Controls.Add(new AsistimeTourCard(tour, x, y) { Parent = this });
                        }
                        else if (Constants.user.rol == "Responsable")
                        {
                            this.Controls.Add(new AssistantTourCard(tour, x, y) { Parent = this });
                        }

                        i++;
                    }
                    else
                    {
                        i = 1;
                        line++;
                        x = spaceBeforeCards + 20 * (i - 1) + Constants.TourCardWidth * (i - 1);
                        y = 200 + 20 * (line - 1) + Constants.TourCardHeigth * (line - 1);

                        if (Constants.user.rol == "Adulto")
                        {
                            this.Controls.Add(new AsistimeTourCard(tour, x, y) { Parent = this });
                        }
                        else if (Constants.user.rol == "Responsable")
                        {
                            this.Controls.Add(new AssistantTourCard(tour, x, y) { Parent = this });
                        }

                        i++;
                    }

                }
            }
        }

        /*protected Control GetBackButton(int x, int y)
        {
            if (backButton == null)
            {
                backButton = new AsistimeRoundButton(98, 98, Constants.AddTourImage, Constants.AddTourHoverImage, Constants.AddTourClickImage) { Parent = this.Parent };
                backButton.Location = new Point(x, y);
            }
            backButton.Click += new EventHandler(this.NavigateBack);
            return backButton;
        }*/

        /*protected void NavigateBack(object sender, EventArgs e)
        {
            NavigatorForm control = this.Parent as NavigatorForm;
            control.NavigateBack();
        }*/

        protected void Center_With(Label label, AsistimeRoundButton button)
        {
            int labelWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(label.Text, label.Font);
                labelWidth = (int)size.Width + 7;
            }
            label.Width = labelWidth;
            label.Location = new Point(button.Location.X + button.Width / 2 - labelWidth / 2, button.Location.Y + button.Width);
        }
    }
}

