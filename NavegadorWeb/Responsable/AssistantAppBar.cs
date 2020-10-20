using NavegadorWeb.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.Responsable
{
    class AssistantAppBar : AsistimeAppBar
    {
        public static AsistimeRoundButton AddTourButton = null;

        public AssistantAppBar()
        {
            this.Controls.Add(this.GetAddTourButton(this.ClientSize.Width - 300, 15));

            Label addTourLabel = new Label() { Text = "Crear tour", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(addTourLabel, AddTourButton);
            this.Controls.Add(addTourLabel);
        }

        protected Control GetAddTourButton(int x, int y)
        {
            if (AddTourButton == null)
            {
                AddTourButton = new AsistimeRoundButton(98, 98, Constants.AddTourImage, Constants.AddTourHoverImage, Constants.AddTourClickImage) { Parent = this.Parent };
                AddTourButton.Location = new Point(x, y);
            }
            AddTourButton.Click += new EventHandler(this.AddTour);
            return AddTourButton;
        }

        protected void AddTour(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.AddTour();
        }
    }

    class AsistimeFormBar : Panel
    {
        public AsistimeFormBar()
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Height = Constants.AppBarHeight;
            Width = Constants.AppBarWidth;
        }
    }

    class AsistimeStepsBar : Panel
    {
        public static AsistimeRoundButton NavBackButton = null;
        public static AsistimeRoundButton ConfirmButton = null;

        public AsistimeStepsBar()
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Height = Constants.AppBarHeight;
            Width = Constants.AppBarWidth;

            this.Controls.Add(this.GetNavBackButton(20, 15));
            Label backLabel = new Label() { Text = "Atrás", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(backLabel, NavBackButton);
            this.Controls.Add(backLabel);

            AsistimeRoundButton RectangleButton = new AsistimeRoundButton(84, 84, Constants.RectImage2, Constants.RectHoverImage2, Constants.RectClickImage2) { Parent = this.Parent };
            Label rectLabel = new Label() { Text = "Cuadrado", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            RectangleButton.Location = new Point(this.Width/2 - 44 - 220, 28);
            Center_With(rectLabel, RectangleButton);
            RectangleButton.Click += new EventHandler(DrawRectangle);
            RectangleButton.BackColor = Color.Black;
            this.Controls.Add(RectangleButton);
            this.Controls.Add(rectLabel);

            AsistimeRoundButton DivButton = new AsistimeRoundButton(84, 84, Constants.DivImage2, Constants.DivHoverImage2, Constants.DivClickImage2) { Parent = this.Parent };
            Label divLabel = new Label() { Text = "Zona", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            DivButton.Location = new Point(RectangleButton.Location.X + 110, RectangleButton.Location.Y);
            Center_With(divLabel, DivButton);
            DivButton.Click += new EventHandler(DrawDiv);
            this.Controls.Add(DivButton);
            this.Controls.Add(divLabel);

            AsistimeRoundButton DialogButton = new AsistimeRoundButton(84, 84, Constants.DialogImage2, Constants.DialogHoverImage2, Constants.DialogClickImage2) { Parent = this.Parent };
            Label dialogLabel = new Label() { Text = "Diálogo", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            DialogButton.Location = new Point(RectangleButton.Location.X + 220, RectangleButton.Location.Y);
            Center_With(dialogLabel, DialogButton);
            DialogButton.Click += new EventHandler(DrawDialog);
            this.Controls.Add(DialogButton);
            this.Controls.Add(dialogLabel);

            AsistimeRoundButton TextButton = new AsistimeRoundButton(84, 84, Constants.TextImage2, Constants.TextHoverImage2, Constants.TextClickImage2) { Parent = this.Parent };
            Label textLabel = new Label() { Text = "Texto", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            TextButton.Location = new Point(RectangleButton.Location.X + 330, RectangleButton.Location.Y);
            Center_With(textLabel, TextButton);
            TextButton.Click += new EventHandler(DrawText);
            this.Controls.Add(TextButton);
            this.Controls.Add(textLabel);

            AsistimeRoundButton CircleButton = new AsistimeRoundButton(84, 84, Constants.CircleImage2, Constants.CircleHoverImage2, Constants.CircleClickImage2) { Parent = this.Parent };
            Label circleLabel = new Label() { Text = "Círculo", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            CircleButton.Location = new Point(RectangleButton.Location.X + 440, RectangleButton.Location.Y);
            Center_With(circleLabel, CircleButton);
            CircleButton.Click += new EventHandler(DrawCircle);
            this.Controls.Add(CircleButton);
            this.Controls.Add(circleLabel);

            this.Controls.Add(this.GetNavConfirmButton(this.ClientSize.Width - 150, 15));
            Label profileLabel = new Label() { Text = "Confirmar", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(profileLabel, ConfirmButton);
            this.Controls.Add(profileLabel);
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

        protected void DrawCircle(object sender, EventArgs e)
        {
            NavigatorAssistant form = this.Parent as NavigatorAssistant;
            form.drawForm("circulo");
        }

        protected void DrawText(object sender, EventArgs e)
        {
            NavigatorAssistant form = this.Parent as NavigatorAssistant;
            form.drawForm("texto");
        }

        protected void DrawDialog(object sender, EventArgs e)
        {
            NavigatorAssistant form = this.Parent as NavigatorAssistant;
            form.drawForm("dialogo");
        }

        protected void DrawDiv(object sender, EventArgs e)
        {
            NavigatorAssistant form = this.Parent as NavigatorAssistant;
            form.drawForm("div");
        }

        protected void DrawRectangle(object sender, EventArgs e)
        {
            NavigatorAssistant form = this.Parent as NavigatorAssistant;
            form.drawForm("rectangulo");
        }

        protected Control GetNavBackButton(int x, int y)
        {
            if (NavBackButton == null)
            {
                NavBackButton = new AsistimeRoundButton(98, 98, Constants.NavBackImage, Constants.NavBackHoverImage, Constants.NavBackClickedImage) { Parent = this.Parent };
                NavBackButton.Location = new Point(x, y);
            }
            NavBackButton.Click += new EventHandler(this.NavigateBack);
            return NavBackButton;
        }

        protected void NavigateBack(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.BackToTourCreation();
        }

        protected Control GetNavConfirmButton(int x, int y)
        {
            if (ConfirmButton == null)
            {
                ConfirmButton = new AsistimeRoundButton(98, 98, Constants.ConfirmImage, Constants.ConfirmHoverImage, Constants.ConfirmClickImage) { Parent = this.Parent };
                ConfirmButton.Location = new Point(x, y);
            }
            ConfirmButton.Click += new EventHandler(this.ShowMenu);
            return ConfirmButton;
        }

        protected void ShowMenu(object sender, EventArgs e)
        {
            NavigatorForm control = this.Parent as NavigatorForm;
            control.ShowMenu();
        }

    }
}
