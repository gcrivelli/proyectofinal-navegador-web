using NavegadorWeb.Adult;
using NavegadorWeb.Responsable;
using NavegadorWeb.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.GeneralDisplay
{
    public partial class AsistimeLogin : Form
    {
        private AsistimeSearchBox userTextBox;
        private AsistimeSearchBox passwrdTextBox;

        public AsistimeLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            this.Width = 700;
            this.Height = 800;

            int initControlsHeight = 300;
            int spaceBetweenTextBoxes = 150;
            int spaceBeforeTextBox = 30;
            int spaceBetweeActionButtons = 100;

            Panel panel = new Panel();
            panel.BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            panel.Location = new Point(0, 0);
            panel.Size = new Size(800, 200);
            this.Controls.Add(panel);

            /*Label asistimeLabel = new Label()
            {
                Text = "Asistime",
                Font = Constants.LogoLabelFont
            };
            asistimeLabel.BackColor = Color.Transparent;
            asistimeLabel.Image = null;
            asistimeLabel.ForeColor = Color.White;
            asistimeLabel.Location = new Point(this.Width / 2 - asistimeLabel.Width / 2, 50);
            this.Controls.Add(asistimeLabel);
            asistimeLabel.BringToFront();*/

            Label userLabel = new Label()
            {
                Text = "USUARIO",
                Font = Constants.H2LabelFont,
                Width = 400
            };
            this.Controls.Add(userLabel);

            userTextBox = new AsistimeSearchBox()
            {
                Font = Constants.TextBoxFont,
                Parent = this,
                Width = 400,
                TextName = null
            };
            this.Controls.Add(userTextBox);

            userTextBox.Location = new Point(this.Width / 2 - userTextBox.Width / 2, initControlsHeight);
            userLabel.Location = new Point(userTextBox.Location.X, userTextBox.Location.Y - spaceBeforeTextBox);

            Label passwrdLabel = new Label()
            {
                Text = "PASSWORD",
                Font = Constants.H2LabelFont,
                Width = 400
            };
            this.Controls.Add(passwrdLabel);

            passwrdTextBox = new AsistimeSearchBox()
            {
                Font = Constants.TextBoxFont,
                Parent = this,
                Width = 400,
                TextName = null
            };
            this.Controls.Add(passwrdTextBox);

            passwrdTextBox.Location = new Point(this.Width / 2 - passwrdTextBox.Width / 2, userTextBox.Location.Y + spaceBetweenTextBoxes);
            passwrdLabel.Location = new Point(passwrdTextBox.Location.X, passwrdTextBox.Location.Y - spaceBeforeTextBox);

            AsistimeActionButton loginButton = new AsistimeActionButton();

            loginButton.Click += new EventHandler(LogUser);
            //loginButton.IdleFillColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            //loginButton.ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            loginButton.ButtonText = "Ingresar";
            this.Controls.Add(loginButton);
            loginButton.Width = 200;
            loginButton.Location = new Point(this.Width / 2 - loginButton.Width / 2 + 15, passwrdTextBox.Location.Y + spaceBetweeActionButtons);

            AsistimeActionButton registerButton = new AsistimeActionButton();
            registerButton.ButtonText = "Registrarse";
            this.Controls.Add(registerButton);
            registerButton.Width = 200;
            registerButton.Location = new Point(this.Width / 2 - registerButton.Width / 2, loginButton.Location.Y + 80);
            
        }

        protected void LogUser(object sender, EventArgs e)
        {
            if (userTextBox.TextName == "adulto")
            {
                NavigatorAdult mod = new NavigatorAdult();
                mod.Show();
            }
            else if (userTextBox.TextName == "responsable")
            {
                NavWebResponsable mod = new NavWebResponsable();
                mod.Show();
            }

        }
    }
}
