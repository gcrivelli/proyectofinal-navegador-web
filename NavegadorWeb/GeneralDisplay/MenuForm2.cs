using NavegadorWeb.Adult;
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
        protected AsistimeRoundButton backButton;
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

            AddButtons();
            ArrangeCardGrid();
        }

        protected void AddButtons()
        {
            backButton = new AsistimeRoundButton(98, 98, Constants.PreviousImageG, Constants.PreviousHoverImageG, Constants.PreviousClickImageG) { Parent = this };
            backButton.Location = new Point(20, 15);
            backButton.Click += new EventHandler(this.ReturnToNavigation);
            this.Controls.Add(backButton);
            Label backLabel = new Label() { Text = "Volver", ForeColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour), Font = Constants.H1LabelFont, Height = 40 };
            Center_With(backLabel, backButton);
            backButton.BringToFront();
            this.Controls.Add(backLabel);

            if (Constants.user.rol == "Adulto")
            {
                assistButton = new AsistimeRoundButton(98, 98, Constants.AsistimeImageG, Constants.AsistimeHoverImageG, Constants.AsistimeClickImageG) { Parent = this };
                assistButton.Location = new Point(this.ClientSize.Width - 150, 15);
                assistButton.Click += new EventHandler(this.Asistime);
                this.Controls.Add(assistButton);
                Label assistLabel = new Label() { Text = "Asistime", ForeColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour), Font = Constants.H1LabelFont, Height = 40 };
                Center_With(assistLabel, assistButton);
                assistButton.BringToFront();
                this.Controls.Add(assistLabel);
            }
            else if (Constants.user.rol == "Responsable")
            {
                addAdultButton = new AsistimeRoundButton(98, 98, Constants.AddAdultImage, Constants.AddAdultHoverImage, Constants.AddAdultClickImage) { Parent = this };
                addAdultButton.Location = new Point(this.ClientSize.Width - 150, 15);
                addAdultButton.Click += new EventHandler(this.AddAdult);
                this.Controls.Add(addAdultButton);
                Label addLabel = new Label() { Text = "Nuevo Adulto", ForeColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour), Font = Constants.H1LabelFont, Height = 40 };
                Center_With(addLabel, addAdultButton);
                addAdultButton.BringToFront();
                this.Controls.Add(addLabel);
            }

            PictureBox logo = new PictureBox();
            logo.Image = Constants.AsistimeLogo291x99;
            this.Controls.Add(logo);
            logo.Width = 291;
            logo.Height = 99;
            logo.Location = new Point(this.Width/2 - logo.Width/2, 15);
            logo.BringToFront();

        }

        protected void AddAdult(object sender, EventArgs e)
        {
            AsistimeAdultSignUp addAdultView = new AsistimeAdultSignUp();
            addAdultView.TopMost = true;
            addAdultView.Show();
        }

        protected void ReturnToNavigation(object sender, EventArgs e)
        {
            this.Hide();
            previousForm.Show();
        }

        protected void Asistime(object sender, EventArgs e)
        {
            NavigatorAdult control = this.previousForm as NavigatorAdult;
            control.Asistime();
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

        public void ArrangeCardGrid()
        {
            this.Controls.Clear();
            AddButtons();
            this.tours = Constants.tours;

            if (!(this.tours.Count == 0))
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

                Label title = new Label()
                {
                    Text = "MIS TOURS",
                    Font = Constants.MenuHeaderFont,
                    Width = 400,
                    Height = 60,
                    TextAlign = ContentAlignment.MiddleLeft,
                };
                title.Location = new Point(spaceBeforeCards, 200);
                this.Controls.Add(title);
                title.BringToFront();

                int line = 1;
                int y;
                int x;
                foreach (Tour tour in this.tours)
                {
                    if (i <= CardsxLine)
                    {
                        x = spaceBeforeCards + 20 * (i-1) + Constants.TourCardWidth * (i - 1);
                        y = 270 + 20 * (line-1) + Constants.TourCardHeigth * (line - 1);

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
                        y = 270 + 20 * (line - 1) + Constants.TourCardHeigth * (line - 1);

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

                Panel panel = new Panel();
                panel.Width = 500;
                panel.Height = 50;
                panel.Location = new Point(0, 270 + 20 * (line - 1) + Constants.TourCardHeigth * (line));
                this.Controls.Add(panel);
            }
            else
            {
                if (Constants.user.rol == "Adulto")
                {
                    Label title = new Label()
                    {
                        Text = "Todavía no tenés tours asignados",
                        Font = Constants.MenuHeaderFont,
                        Width = 1000,
                        Height = 60,
                        TextAlign = ContentAlignment.MiddleCenter,
                    };
                    title.Location = new Point(this.Width / 2 - title.Width / 2, this.Height / 2 - title.Height / 2);
                    this.Controls.Add(title);
                }
                else if (Constants.user.rol == "Responsable")
                {
                    Label title = new Label()
                    {
                        Text = "Todavía no creaste ningún tour",
                        Font = Constants.MenuHeaderFont,
                        Width = 1000,
                        Height = 60,
                        TextAlign = ContentAlignment.MiddleCenter,
                    };
                    title.Location = new Point(this.Width / 2 - title.Width / 2, this.Height / 2 - title.Height / 2);
                    this.Controls.Add(title);
                }
                
            }
        }

        public void PlayTour(Tour tour)
        {
            this.Hide();
            NavigatorAdult form = previousForm as NavigatorAdult;
            form.PlayTour(tour);
        }

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

