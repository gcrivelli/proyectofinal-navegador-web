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

        private AsistimeActionButton loginButton;
        private AsistimeActionButton registerButton;

        private Label asistimeLabel;

        private int initControlsHeight = 300;
        private int spaceBetweenTextBoxes = 150;
        private int spaceBeforeTextBox = 30;
        private int spaceBetweeActionButtons = 100;

        public AsistimeLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            this.Width = 700;
            this.Height = 800;
            this.AllowTransparency = true;

            AsistimeRoundButton exitButton = new AsistimeRoundButton(48, 48, Constants.CloseImage, Constants.CloseImage, Constants.CloseClickedImage) { Parent = this.Parent };
            exitButton.Location = new Point(this.Width - 60, 10);
            exitButton.Click += new EventHandler(Exit);
            this.Controls.Add(exitButton);


            Panel panel = new Panel();
            panel.BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            panel.Location = new Point(0, 0);
            panel.Size = new Size(800, 200);
            this.Controls.Add(panel);

            asistimeLabel = new Label()
            {
                Text = "Asistime",
                Font = Constants.LogoLabelFont,
                ForeColor = Color.White
            };
            this.Controls.Add(asistimeLabel);
            panel.Controls.Add(asistimeLabel);
            asistimeLabel.BringToFront();

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

            loginButton = new AsistimeActionButton();
            loginButton.Click += new EventHandler(LogUser);
            loginButton.ButtonText = "Ingresar";
            this.Controls.Add(loginButton);

            registerButton = new AsistimeActionButton();
            registerButton.Click += new EventHandler(RegisterUser);
            registerButton.ButtonText = "Registrarse";
            this.Controls.Add(registerButton);
            
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
            else if (userTextBox.TextName == "prueba")
            {
                Form1 mod = new Form1();
                mod.Show();
            }

        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            AsistimeRegister registerForm = new AsistimeRegister();
            registerForm.previousForm = this;
            this.Hide();
            registerForm.Show();
        }

        protected void Exit(object sender, EventArgs e)
        {
            //Application.Exit();
            AsistimeTourCreation sarasa = new AsistimeTourCreation();
            this.Hide();
            sarasa.Show();
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
            loginButton.Location = new Point(this.Width / 2 - loginButtonWidth / 2, passwrdTextBox.Location.Y + spaceBetweeActionButtons);

            int registerButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(registerButton.ButtonText, registerButton.Font);
                size.Width += 40;
                registerButtonWidth = (int)size.Width;
            }
            registerButton.Location = new Point(this.Width / 2 - registerButtonWidth / 2, loginButton.Location.Y + 80);

            /*asistimeLabel.BackColor = Color.Transparent;
            asistimeLabel.Image = null;
            asistimeLabel.ForeColor = Color.White;
            asistimeLabel.Location = new Point(this.Width / 2 - asistimeLabel.Width / 2, 50);*/
        }







        //NO BORRAR ESTO
        /*[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);*/

        private void AsistimeLogin_MouseDown(object sender, MouseEventArgs e)
        {
            /*ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);*/
        }
    }
}
