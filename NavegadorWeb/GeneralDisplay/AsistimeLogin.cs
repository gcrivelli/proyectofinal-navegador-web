using NavegadorWeb.Adult;
using NavegadorWeb.Controller;
using NavegadorWeb.Models;
using NavegadorWeb.Responsable;
using NavegadorWeb.UI;
using System;
using System.Drawing;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

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
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Asistime!!";
            popup.TitlePadding = new Padding(50, 20, 20, 20);
            popup.TitleFont = new Font("Arial", 26);
            popup.ContentText = "Bienvenido";
            popup.ContentFont = new Font("Arial", 13);
            popup.ContentPadding = new Padding(50, 0, 20, 20);

            popup.ShowCloseButton = true;
            popup.ShowOptionsButton = true;
            popup.Delay = 5000;
            popup.Size = new Size(300, 200);
            popup.Popup();

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

                        if (token.user.rol == "Adulto")
                        {
                            NavigatorAdult mod = new NavigatorAdult();
                            mod.Show();
                        }
                        else if (token.user.rol == "Responsable")
                        {
                            NavWebResponsable mod = new NavWebResponsable();
                            mod.Show();
                        }
                    }
                    else
                        MessageBox.Show("Usuario o contraseña incorrecta.", "Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
                MessageBox.Show("Todos los campos deben tenes un valor.", "Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }

    }
}
