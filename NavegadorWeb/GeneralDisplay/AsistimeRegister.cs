using NavegadorWeb.Controller;
using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public partial class AsistimeRegister : Form
    {

        private AsistimeSearchBox nameTextBox;
        private AsistimeSearchBox mailTextBox;
        private AsistimeSearchBox passwrdTextBox;

        private AsistimeActionButton registerAccountButton;
        private AsistimeActionButton backToLoginButton;

        private int initControlsHeight = 350;
        private int spaceBetweenTextBoxes = 150;
        private int spaceBeforeTextBox = 30;
        private int spaceBetweeActionButtons = 100;

        public AsistimeLogin previousForm;

        public AsistimeRegister()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            this.Width = 700;
            this.Height = 1000;
            this.BackColor = Color.White;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            AsistimeRoundButton exitButton = new AsistimeRoundButton(46, 46, Constants.CloseImage, Constants.CloseHoverImage, Constants.CloseClickedImage) { Parent = this.Parent };
            exitButton.Location = new Point(this.Width - 56, 10);
            exitButton.Click += new EventHandler(Exit);
            this.Controls.Add(exitButton);

            PictureBox logo = new PictureBox();
            logo.ImageLocation = Constants.AsistimeLogo; ;
            this.Controls.Add(logo);
            logo.Width = 500;
            logo.Height = 200;
            logo.Location = new Point(101, 70);
            logo.BringToFront();

            Label nameLabel = new Label()
            {
                Text = "NOMBRE",
                Font = Constants.H2LabelFont,
                Width = 400
            };
            this.Controls.Add(nameLabel);

            nameTextBox = new AsistimeSearchBox()
            {
                Font = Constants.TextBoxFont,
                Parent = this,
                Width = 400,
                TextName = null
            };
            this.Controls.Add(nameTextBox);

            nameTextBox.Location = new Point(this.Width / 2 - nameTextBox.Width / 2, initControlsHeight);
            nameLabel.Location = new Point(nameTextBox.Location.X, nameTextBox.Location.Y - spaceBeforeTextBox);

            Label mailLabel = new Label()
            {
                Text = "MAIL",
                Font = Constants.H2LabelFont,
                Width = 400
            };
            this.Controls.Add(mailLabel);

            mailTextBox = new AsistimeSearchBox()
            {
                Font = Constants.TextBoxFont,
                Parent = this,
                Width = 400,
                TextName = null
            };
            this.Controls.Add(mailTextBox);

            mailTextBox.Location = new Point(this.Width / 2 - mailTextBox.Width / 2, nameTextBox.Location.Y + spaceBetweenTextBoxes);
            mailLabel.Location = new Point(mailTextBox.Location.X, mailTextBox.Location.Y - spaceBeforeTextBox);

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

            passwrdTextBox.Location = new Point(this.Width / 2 - passwrdTextBox.Width / 2, mailTextBox.Location.Y + spaceBetweenTextBoxes);
            passwrdLabel.Location = new Point(passwrdTextBox.Location.X, passwrdTextBox.Location.Y - spaceBeforeTextBox);

            registerAccountButton = new AsistimeActionButton();
            registerAccountButton.Click += new EventHandler(RegisterAccount);
            registerAccountButton.ButtonText = "Registrar cuenta";
            this.Controls.Add(registerAccountButton);

            backToLoginButton = new AsistimeActionButton();
            backToLoginButton.Click += new EventHandler(BackToLogin);
            backToLoginButton.ButtonText = "Volver al Login";
            this.Controls.Add(backToLoginButton);

            


        }

        protected void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected void RegisterAccount(object sender, EventArgs e)
        {
            //Validaciones de campos
            //Llamado al a api
            //Mensaje de que hay que validar la cuenta
            //Volver al login?
            if (validateForm())
            {
                var user = new User();
                user.name = nameTextBox.TextName;
                user.email = mailTextBox.TextName;
                user.password = passwrdTextBox.TextName;
                user.tours = new List<Tour>();

                var userController = new UserController();
                var token = userController.RegisterAsync(user).Result;
                //Aca hace su magia nacho con el token
            }
            else
                MessageBox.Show("Registro invalido", "Todos los campos son requeridos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected void BackToLogin(object sender, EventArgs e)
        {
            this.Hide();
            this.previousForm.Show();
        }

        private bool validateForm()
        {
            if (nameTextBox.TextName == string.Empty || passwrdTextBox.TextName == string.Empty || mailTextBox.TextName == string.Empty)
                return false;
            else 
                return true;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AsistimeRegister
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "AsistimeRegister";
            this.Load += new System.EventHandler(this.AsistimeRegister_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AsistimeRegister_MouseDown);
            this.ResumeLayout(false);

        }

        private void AsistimeRegister_Load(object sender, EventArgs e)
        {
            int registerAccountButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(registerAccountButton.ButtonText, registerAccountButton.Font);
                size.Width += 40;
                registerAccountButtonWidth = (int)size.Width;
            }
            registerAccountButton.Location = new Point(this.Width / 2 - registerAccountButtonWidth / 2, passwrdTextBox.Location.Y + spaceBetweeActionButtons);

            int backToLoginButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(backToLoginButton.ButtonText, backToLoginButton.Font);
                size.Width += 40;
                backToLoginButtonWidth = (int)size.Width;
            }
            backToLoginButton.Location = new Point(this.Width / 2 - backToLoginButtonWidth / 2, registerAccountButton.Location.Y + 80);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void AsistimeRegister_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
    }
}
