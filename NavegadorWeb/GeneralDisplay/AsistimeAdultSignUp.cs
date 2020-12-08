using NavegadorWeb.Controller;
using NavegadorWeb.Extra;
using NavegadorWeb.Models;
using NavegadorWeb.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.GeneralDisplay
{
    public partial class AsistimeAdultSignUp : AsistimeBaseForm
    {
        public AsistimeAdultSignUp()
        {
            this.Load += new System.EventHandler(AdultSignUp_Load);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.TransparencyKey = Color.Green;
            this.BackColor = Color.Green;

            InitializeComponent();
        }

        private void AdultSignUp_Load(object sender, EventArgs e)
        {
            AsistimeSignUpPanel adultCreation = new AsistimeSignUpPanel() { Parent = this };
            adultCreation.Width = 700;
            adultCreation.Height = 800;
            this.Controls.Add(adultCreation);
            adultCreation.BackColor = Color.White;
            adultCreation.Location = new Point(this.Width / 2 - adultCreation.Width / 2, this.Height / 2 - adultCreation.Height / 2);
        }

        public void Exit()
        {
            this.Close();
        }

    }

    class AsistimeSignUpPanel : AsistimeBasePopup
    {
        protected AsistimeSearchBox nameTextBox;
        protected AsistimeSearchBox mailTextBox;
        protected AsistimeSearchBox passwrdTextBox;
        protected AsistimeSearchBox passwrdConfirmationTextBox;
        protected AsistimeActionButton registerAccountButton;
        protected AsistimeActionButton backToLoginButton;

        protected int initControlsHeight = 200;
        protected int spaceBetweenTextBoxes = 100;
        protected int spaceBeforeTextBox = 30;
        protected int spaceBeforeActionButtons = 100;
        protected int spaceBetweeActionButtons = 100;
        protected int spaceAfterControls = 150;

        public AsistimeSignUpPanel()
        {
            this.title.Text = "CREACIÓN DE CUENTA DE ADULTO";


            Label nameLabel = new Label()
            {
                Text = "NOMBRE",
                Font = Constants.H2LabelFont,
                Width = 400
            };
            this.Controls.Add(nameLabel);
            nameLabel.BringToFront();

            nameTextBox = new AsistimeSearchBox()
            {
                Font = Constants.TextBoxFont,
                Parent = this,
                Width = 400,
                TextName = null
            };
            this.Controls.Add(nameTextBox);
            nameTextBox.BringToFront();

            nameTextBox.Location = new Point(this.Width / 2 - nameTextBox.Width / 2, initControlsHeight);
            nameLabel.Location = new Point(nameTextBox.Location.X, nameTextBox.Location.Y - spaceBeforeTextBox);

            Label mailLabel = new Label()
            {
                Text = "MAIL",
                Font = Constants.H2LabelFont,
                Width = 400
            };
            this.Controls.Add(mailLabel);
            mailLabel.BringToFront();

            mailTextBox = new AsistimeSearchBox()
            {
                Font = Constants.TextBoxFont,
                Parent = this,
                Width = 400,
                TextName = null
            };
            this.Controls.Add(mailTextBox);
            mailTextBox.BringToFront();

            mailTextBox.Location = new Point(this.Width / 2 - mailTextBox.Width / 2, nameTextBox.Location.Y + spaceBetweenTextBoxes);
            mailLabel.Location = new Point(mailTextBox.Location.X, mailTextBox.Location.Y - spaceBeforeTextBox);

            Label passwrdLabel = new Label()
            {
                Text = "PASSWORD",
                Font = Constants.H2LabelFont,
                Width = 400
            };
            this.Controls.Add(passwrdLabel);
            passwrdLabel.BringToFront();

            passwrdTextBox = new AsistimeSearchBox()
            {
                Font = Constants.TextBoxFont,
                Parent = this,
                Width = 400,
                TextName = null,
                IsPassword = true
            };
            this.Controls.Add(passwrdTextBox);
            passwrdTextBox.BringToFront();

            passwrdTextBox.Location = new Point(this.Width / 2 - passwrdTextBox.Width / 2, mailTextBox.Location.Y + spaceBetweenTextBoxes);
            passwrdLabel.Location = new Point(passwrdTextBox.Location.X, passwrdTextBox.Location.Y - spaceBeforeTextBox);

            Label passwrdConfirmationLabel = new Label()
            {
                Text = "REPETIR PASSWORD",
                Font = Constants.H2LabelFont,
                Width = 400
            };
            this.Controls.Add(passwrdConfirmationLabel);
            passwrdConfirmationLabel.BringToFront();

            passwrdConfirmationTextBox = new AsistimeSearchBox()
            {
                Font = Constants.TextBoxFont,
                Parent = this,
                Width = 400,
                TextName = null,
                IsPassword = true
            };
            this.Controls.Add(passwrdConfirmationTextBox);
            passwrdConfirmationTextBox.BringToFront();

            passwrdConfirmationTextBox.Location = new Point(this.Width / 2 - passwrdConfirmationTextBox.Width / 2, passwrdTextBox.Location.Y + spaceBetweenTextBoxes);
            passwrdConfirmationLabel.Location = new Point(passwrdConfirmationTextBox.Location.X, passwrdConfirmationTextBox.Location.Y - spaceBeforeTextBox);

            registerAccountButton = new AsistimeActionButton();
            registerAccountButton.Click += new EventHandler(RegisterAccount);
            registerAccountButton.ButtonText = "Registrar cuenta";
            this.Controls.Add(registerAccountButton);
            registerAccountButton.BringToFront();

            backToLoginButton = new AsistimeActionButton();
            backToLoginButton.Click += new EventHandler(Back);
            backToLoginButton.ButtonText = "Cancelar";
            this.Controls.Add(backToLoginButton);
            backToLoginButton.BringToFront();

            int loginButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(registerAccountButton.ButtonText, registerAccountButton.Font);
                size.Width += 40;
                loginButtonWidth = (int)size.Width;
            }
            registerAccountButton.Location = new Point(this.Width / 2 - loginButtonWidth / 2, passwrdConfirmationTextBox.Location.Y + spaceBeforeActionButtons);

            int registerButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(backToLoginButton.ButtonText, backToLoginButton.Font);
                size.Width += 40;
                registerButtonWidth = (int)size.Width;
            }
            backToLoginButton.Location = new Point(this.Width / 2 - registerButtonWidth / 2, registerAccountButton.Location.Y + spaceBetweeActionButtons);

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
                user.password_confirmation = passwrdConfirmationTextBox.TextName;

                var userController = new UserController();
                
                    var token = userController.RegisterOldPeopleAsync(user).Result;
                    new PopupNotification("Registro correcto", "Adulto registrado correctamente.");

                AsistimeAdultSignUp form = Parent as AsistimeAdultSignUp;
                form.Exit();


            }
            else
            {
                if (passwrdTextBox.TextName != passwrdConfirmationTextBox.TextName)
                {
                    new PopupNotification("Registro inválido", "Las contraseñas no coinciden.");
                }
                else
                {
                    new PopupNotification("Registro inválido", "Complete todos los datos.");
                }
            }
        }

        protected void Back(object sender, EventArgs e)
        {
            AsistimeAdultSignUp form = Parent as AsistimeAdultSignUp;
            form.Exit();
        }

        private bool validateForm()
        {
            if (nameTextBox.TextName == string.Empty || passwrdTextBox.TextName == string.Empty || mailTextBox.TextName == string.Empty || passwrdTextBox.TextName != passwrdConfirmationTextBox.TextName)
                return false;
            else
                return true;
        }


    }
}
