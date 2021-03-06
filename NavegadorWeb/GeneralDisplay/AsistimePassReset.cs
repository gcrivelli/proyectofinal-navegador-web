﻿using NavegadorWeb.Controller;
using NavegadorWeb.Extra;
using NavegadorWeb.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.GeneralDisplay
{
    public partial class AsistimePassReset : AsistimeModalForm
    {

        private AsistimeSearchBox mailTextBox;
        private AsistimeActionButton resetPassButton;
        public AsistimeLogin previousForm;

        public AsistimePassReset()
        {
            
            InitializeComponent();

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

            mailTextBox.Location = new Point(this.Width / 2 - mailTextBox.Width / 2, initControlsHeight);
            mailLabel.Location = new Point(mailTextBox.Location.X, mailTextBox.Location.Y - spaceBeforeTextBox);

            resetPassButton = new AsistimeActionButton();
            resetPassButton.Click += new EventHandler(ResetPassword);
            resetPassButton.ButtonText = "Restablecer contraseña";
            this.Controls.Add(resetPassButton);

            //this.Load += new System.EventHandler(this.AsistimePassReset_Load);
        }

        protected void ResetPassword(object sender, EventArgs e)
        {
            if (mailTextBox.TextName != string.Empty)
            {
                var userController = new UserController();
                var result = userController.ForgotPasswordAsync(mailTextBox.TextName).Result;

                if (result)
                {
                    new PopupNotification("Mail enviado", "Se ha enviado un mail de recupero de contraseña.");
                    this.Close();
                    previousForm.Show();
                }
                else
                    new PopupNotification("Error", "El mail ingresado es incorrecto.");

                mailTextBox.TextName = string.Empty;
            }
            else
                new PopupNotification("Error", "Ingrese un mail.");
        }

        private void AsistimePassReset_Load(object sender, EventArgs e)
        {
            int loginButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(resetPassButton.ButtonText, resetPassButton.Font);
                size.Width += 40;
                loginButtonWidth = (int)size.Width;
            }
            resetPassButton.Location = new Point(this.Width / 2 - loginButtonWidth / 2, mailTextBox.Location.Y + spaceBeforeActionButtons);

            this.Height = resetPassButton.Location.Y;
            this.FinalizeLoading();

        }
    }
}
