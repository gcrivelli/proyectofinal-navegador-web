using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeBasePopup : Panel
    {
        public AsistimeBasePopup()
        {
            this.Width = 700;
            this.Height = 700;
            this.BackColor = Color.White;
        }
    }

    class AsistimeCreatePanel : AsistimeBasePopup
    {
        private AsistimeSearchBox tourNameTextBox;
        private AsistimeSearchBox tourDescTextBox;

        private AsistimeActionButton nextButton;
        private AsistimeActionButton cancelButton;

        private AsistimeSearchBox box;

        public AsistimeCreatePanel()
        {
            Label tourNameLabel = new Label()
            {
                Text = "NOMBRE DEL TOUR",
                Font = Constants.H2LabelFont,
                Width = 400
            };
            
            this.Controls.Add(tourNameLabel);
            tourNameTextBox = new AsistimeSearchBox()
            {
                Font = Constants.TextBoxFont,
                Parent = this,
                Width = 400,
                TextName = null
            };
            this.Controls.Add(tourNameTextBox);

            Label tourDescTextBox = new Label()
            {
                Text = "DESCRIPCIÓN",
                Font = Constants.H2LabelFont,
                Width = 400
            };
            this.Controls.Add(tourDescTextBox);

            box = new AsistimeSearchBox();
            box.Width = 400;
            box.Height = 300;
            this.Controls.Add(box);
            box.BringToFront();

            TextBox textbox = new TextBox();
            textbox.Multiline = true;
            textbox.Width = 380; //20 menos que el ancho del searchbox
            textbox.Height = 280; //20 menos que la altura del searchbox
            this.Controls.Add(textbox);
            textbox.BorderStyle = BorderStyle.None;
            textbox.Font = Constants.TextBoxFont;
            textbox.BringToFront();

            box.Location = new Point(this.Width / 2 - box.Width / 2, 200);
            textbox.Location = new Point(box.Location.X + 10, box.Location.Y + 10);
            tourDescTextBox.Location = new Point(box.Location.X, box.Location.Y - 30);
            tourNameTextBox.Location = new Point(this.Width / 2 - tourNameTextBox.Width / 2, 90);
            tourNameLabel.Location = new Point(tourNameTextBox.Location.X, tourNameTextBox.Location.Y - 30);



            nextButton = new AsistimeActionButton();
            nextButton.Click += new EventHandler(Next);
            nextButton.ButtonText = "Siguiente";
            this.Controls.Add(nextButton);
            nextButton.BringToFront();

            cancelButton = new AsistimeActionButton();
            cancelButton.Click += new EventHandler(Cancel);
            cancelButton.ButtonText = "Cancelar";
            this.Controls.Add(cancelButton);
            cancelButton.BringToFront();

            int nextButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(nextButton.ButtonText, nextButton.Font);
                size.Width += 40;
                nextButtonWidth = (int)size.Width;
            }
            nextButton.Location = new Point(this.Width / 2 - nextButtonWidth / 2, 600);

            int cancelButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(cancelButton.ButtonText, cancelButton.Font);
                size.Width += 40;
                cancelButtonWidth = (int)size.Width;
            }
            cancelButton.Location = new Point(this.Width / 2 - cancelButtonWidth / 2, nextButton.Location.Y + 80);
        }

        protected void Next(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected void Cancel(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
