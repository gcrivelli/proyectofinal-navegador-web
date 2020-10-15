using NavegadorWeb.Adult;
using NavegadorWeb.Controller;
using NavegadorWeb.Extra;
using NavegadorWeb.Models;
using NavegadorWeb.Responsable;
using NavegadorWeb.UI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace NavegadorWeb.GeneralDisplay
{
    public partial class AsistimeLogin : AsistimeModalForm
    {
        protected AsistimeSearchBox userTextBox;
        protected AsistimeSearchBox passwrdTextBox;

        protected AsistimeActionButton loginButton;
        protected AsistimeActionButton registerButton;
        protected AsistimeActionButton forgotPasswordButton;

        public AsistimeLogin() : base()
        {
            InitializeComponent();

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
                Text = "CONTRASEÑA",
                Font = Constants.H2LabelFont,
                Width = 400
            };
            this.Controls.Add(passwrdLabel);

            passwrdTextBox = new AsistimeSearchBox()
            {
                Font = Constants.TextBoxFont,
                Parent = this,
                Width = 400,
                TextName = null,
                IsPassword = true
            };
            this.Controls.Add(passwrdTextBox);

            passwrdTextBox.Location = new Point(this.Width / 2 - passwrdTextBox.Width / 2, userTextBox.Location.Y + spaceBetweenTextBoxes);
            passwrdLabel.Location = new Point(passwrdTextBox.Location.X, passwrdTextBox.Location.Y - spaceBeforeTextBox);

            loginButton = new AsistimeActionButton();
            loginButton.Click += new EventHandler(LogUser);
            loginButton.ButtonText = "Ingresar";
            this.Controls.Add(loginButton);

            registerButton = new AsistimeActionButton();
            registerButton.Click += new EventHandler(RegisterUser);
            registerButton.ButtonText = "Registrarse";
            this.Controls.Add(registerButton);

            forgotPasswordButton = new AsistimeActionButton();
            forgotPasswordButton.Click += new EventHandler(ForgotPassword);
            forgotPasswordButton.ButtonText = "Olvidé mi contraseña";
            this.Controls.Add(forgotPasswordButton);

        }

        protected void LogUser(object sender, EventArgs e)
        {
            if (userTextBox.TextName != string.Empty)
            {
                if (passwrdTextBox.TextName != string.Empty)
                {
                    var userController = new UserController();
                    var user = new User();
                    user.email = userTextBox.TextName;
                    user.password = passwrdTextBox.TextName;

                    var token = userController.LoginAsync(user).Result;

                    if (token != null)
                    {
                        Constants.token = token.access_token;
                        Constants.user = new User();
                        Constants.user = token.user;
                        new PopupNotification("App Asistime!", "Bienvenido " + token.user.name);

                        if (token.user.rol == "Adulto")
                        {
                            // Obtengo los tours 

                            var tourController = new TourController();
                            Constants.tours = tourController.GetAllToursAsync().Result;

                            ////Active notifications of new tours
                            Thread threadNewTour = new Thread(NewTourThread.DoWork);
                            threadNewTour.IsBackground = true;
                            threadNewTour.Start();

                            NavigatorAdult mod = new NavigatorAdult();
                            mod.Show();
                        }
                        else if (token.user.rol == "Responsable")
                        {
                            ////Active notifications
                            Thread threadNotification = new Thread(NotificationThread.DoWork);
                            threadNotification.IsBackground = true;
                            threadNotification.Start();

                            NavigatorAssistant mod = new NavigatorAssistant();
                            mod.Show();
                        }
                    }
                    else
                        new PopupNotification("Error Login", "Usuario o contraseña incorrecta.");

                }
            }
            else
                new PopupNotification("Error Login", "Todos los campos deben tenes un valor.");
        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            AsistimeRegister registerForm = new AsistimeRegister();
            registerForm.previousForm = this;
            this.Hide();
            registerForm.Show();
        }

        protected void ForgotPassword(object sender, EventArgs e)
        {
            AsistimePassReset forgotPassForm = new AsistimePassReset();
            forgotPassForm.previousForm = this;
            this.Hide();
            forgotPassForm.Show();
        }



        private void AsistimeLogin_Load(object sender, EventArgs e)
        {
            int loginButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(loginButton.ButtonText, loginButton.Font);
                size.Width += 40;
                loginButtonWidth = (int)size.Width;
            }
            loginButton.Location = new Point(this.Width / 2 - loginButtonWidth / 2, passwrdTextBox.Location.Y + spaceBeforeActionButtons);

            int registerButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(registerButton.ButtonText, registerButton.Font);
                size.Width += 40;
                registerButtonWidth = (int)size.Width;
            }
            registerButton.Location = new Point(this.Width / 2 - registerButtonWidth / 2, loginButton.Location.Y + spaceBetweeActionButtons);

            int forgotButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(forgotPasswordButton.ButtonText, forgotPasswordButton.Font);
                size.Width += 40;
                forgotButtonWidth = (int)size.Width;
            }
            forgotPasswordButton.Location = new Point(this.Width / 2 - forgotButtonWidth / 2, registerButton.Location.Y + spaceBetweeActionButtons);

            this.Height = forgotPasswordButton.Location.Y;
            this.FinalizeLoading();
            RePaint();

        }

        protected void RePaint()
        {
            GraphicsPath graphicpath = new GraphicsPath();
            graphicpath.StartFigure();
            graphicpath.AddArc(0, 0, 25, 25, 180, 90);
            graphicpath.AddLine(25, 0, this.Width - 25, 0);
            graphicpath.AddArc(this.Width - 25, 0, 25, 25, 270, 90);
            graphicpath.AddLine(this.Width, 25, this.Width, this.Height - 25);
            graphicpath.AddArc(this.Width - 25, this.Height - 25, 25, 25, 0, 90);
            graphicpath.AddLine(this.Width - 25, this.Height, 25, this.Height);
            graphicpath.AddArc(0, this.Height - 25, 25, 25, 90, 90);
            graphicpath.CloseFigure();
            this.Region = new Region(graphicpath);
        }

    }

}
