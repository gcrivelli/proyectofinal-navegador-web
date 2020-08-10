using NavegadorWeb.GeneralDisplay;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private int initControlsHeight = 300;
        private int spaceBetweenTextBoxes = 150;
        private int spaceBeforeTextBox = 30;
        private int spaceBetweeActionButtons = 100;

        public AsistimeLogin previousForm;

        public AsistimeRegister()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            this.Width = 700;
            this.Height = 1000;

            AsistimeRoundButton exitButton = new AsistimeRoundButton(48, 48, Constants.CloseImage, Constants.CloseImage, Constants.CloseClickedImage) { Parent = this.Parent };
            exitButton.Location = new Point(this.Width - 60, 10);
            exitButton.Click += new EventHandler(Exit);
            this.Controls.Add(exitButton);

            Panel panel = new Panel();
            panel.BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            panel.Location = new Point(0, 0);
            panel.Size = new Size(800, 200);
            this.Controls.Add(panel);

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
        }

        protected void BackToLogin(object sender, EventArgs e)
        {
            this.Hide();
            this.previousForm.Show();
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
            this.ResumeLayout(false);

        }

        private void AsistimeRegister_Load(object sender, EventArgs e)
        {
            
        }
    }
}
