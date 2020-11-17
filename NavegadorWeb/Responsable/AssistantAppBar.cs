using NavegadorWeb.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private AsistimeRoundButton LessThicknessButton;
        private AsistimeRoundButton MoreThicknessButton;
        private AsistimeRoundButton LessSizeButton;
        private AsistimeRoundButton MoreSizeButton;
        private AsistimeRoundButton TurnRightButton;
        private AsistimeRoundButton TurnLeftButton;
        private AsistimeRoundButton FontDownButton;
        private AsistimeRoundButton FontUpButton;
        private AsistimeRoundButton BlueButton;
        private AsistimeRoundButton YellowButton;
        private AsistimeRoundButton RedButton;
        private AsistimeRoundButton GreenButton;
        private AsistimeRoundButton OrangeButton;
        private AsistimeRoundButton VioletButton;
        private AsistimeRoundButton BackButton;

        public AsistimeFormBar()
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Height = 700;
            Width = 200;

            this.MouseMove += new MouseEventHandler(panel_MouseMove);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            LessThicknessButton = new AsistimeRoundButton(37, 37, Constants.MinusImage, Constants.MinusHoverImage, Constants.MinusHoverImage) { Parent = this.Parent };
            LessThicknessButton.Location = new Point(40, 30);
            LessThicknessButton.Click += new EventHandler(this.LessThickness);
            this.Controls.Add(LessThicknessButton);

            MoreThicknessButton = new AsistimeRoundButton(37, 37, Constants.PlusImage, Constants.PlusHoverImage, Constants.PlusHoverImage) { Parent = this.Parent };
            MoreThicknessButton.Location = new Point(107, 30);
            MoreThicknessButton.Click += new EventHandler(this.MoreThickness);
            this.Controls.Add(MoreThicknessButton);

            Label thickness = new Label() { Text = "Grosor", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            thickness.Location = new Point(10, 80);
            Center(thickness,this);
            this.Controls.Add(thickness);

            LessSizeButton = new AsistimeRoundButton(37, 37, Constants.MinusImage, Constants.MinusHoverImage, Constants.MinusHoverImage) { Parent = this.Parent };
            LessSizeButton.Location = new Point(40, 147);
            LessSizeButton.Click += new EventHandler(this.LessSize);
            this.Controls.Add(LessSizeButton);

            MoreSizeButton = new AsistimeRoundButton(37, 37, Constants.PlusImage, Constants.PlusHoverImage, Constants.PlusHoverImage) { Parent = this.Parent };
            MoreSizeButton.Location = new Point(107, 147);
            MoreSizeButton.Click += new EventHandler(this.MoreSize);
            this.Controls.Add(MoreSizeButton);

            Label size = new Label() { Text = "Tamaño", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            size.Location = new Point(10, 187);
            Center(size, this);
            this.Controls.Add(size);

            TurnRightButton = new AsistimeRoundButton(37, 37, Constants.TurnRightImage, Constants.TurnRightHoverImage, Constants.TurnRightHoverImage) { Parent = this.Parent };
            TurnRightButton.Location = new Point(40, 264);
            TurnRightButton.Click += new EventHandler(this.TurnRightSize);
            this.Controls.Add(TurnRightButton);

            TurnLeftButton = new AsistimeRoundButton(37, 37, Constants.TurnLeftImage, Constants.TurnLeftHoverImage, Constants.TurnLeftHoverImage) { Parent = this.Parent };
            TurnLeftButton.Location = new Point(107, 264);
            TurnLeftButton.Click += new EventHandler(this.TurnLeftSize);
            this.Controls.Add(TurnLeftButton);

            Label rotate = new Label() { Text = "Girar", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            rotate.Location = new Point(10, 304);
            Center(rotate, this);
            this.Controls.Add(rotate);

            FontDownButton = new AsistimeRoundButton(37, 37, Constants.FontDownImage, Constants.FontDownHoverImage, Constants.FontDownHoverImage) { Parent = this.Parent };
            FontDownButton.Location = new Point(40, 381);
            FontDownButton.Click += new EventHandler(this.FontDown);
            this.Controls.Add(FontDownButton);

            FontUpButton = new AsistimeRoundButton(37, 37, Constants.FontUpImage, Constants.FontUpHoverImage, Constants.FontUpHoverImage) { Parent = this.Parent };
            FontUpButton.Location = new Point(107, 381);
            FontUpButton.Click += new EventHandler(this.FontUp);
            this.Controls.Add(FontUpButton);

            Label font = new Label() { Text = "Fuente", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            font.Location = new Point(10, 421);
            Center(font, this);
            this.Controls.Add(font);

            BlueButton = new AsistimeRoundButton(37, 37, Constants.BlueImage, Constants.BlueImage, Constants.BlueImage) { Parent = this.Parent };
            BlueButton.Location = new Point(30, 498);
            BlueButton.Click += new EventHandler(this.Blue);
            this.Controls.Add(BlueButton);

            YellowButton = new AsistimeRoundButton(37, 37, Constants.YellowImage, Constants.YellowImage, Constants.YellowImage) { Parent = this.Parent };
            YellowButton.Location = new Point(80, 498);
            YellowButton.Click += new EventHandler(this.Yellow);
            this.Controls.Add(YellowButton);

            RedButton = new AsistimeRoundButton(37, 37, Constants.RedImage, Constants.RedImage, Constants.RedImage) { Parent = this.Parent };
            RedButton.Location = new Point(130, 498);
            RedButton.Click += new EventHandler(this.Red);
            this.Controls.Add(RedButton);

            GreenButton = new AsistimeRoundButton(37, 37, Constants.GreenImage, Constants.GreenImage, Constants.GreenImage) { Parent = this.Parent };
            GreenButton.Location = new Point(30, 540);
            GreenButton.Click += new EventHandler(this.Green);
            this.Controls.Add(GreenButton);

            OrangeButton = new AsistimeRoundButton(37, 37, Constants.OrangeImage, Constants.OrangeImage, Constants.OrangeImage) { Parent = this.Parent };
            OrangeButton.Location = new Point(80, 540);
            OrangeButton.Click += new EventHandler(this.Orange);
            this.Controls.Add(OrangeButton);

            VioletButton = new AsistimeRoundButton(37, 37, Constants.VioletImage, Constants.VioletImage, Constants.VioletImage) { Parent = this.Parent };
            VioletButton.Location = new Point(130, 540);
            VioletButton.Click += new EventHandler(this.Violet);
            this.Controls.Add(VioletButton);

            BackButton = new AsistimeRoundButton(37, 37, Constants.BlackImage, Constants.BlackImage, Constants.BlackImage) { Parent = this.Parent };
            BackButton.Location = new Point(80, 582);
            BackButton.Click += new EventHandler(this.Black);
            this.Controls.Add(BackButton);

            Label color = new Label() { Text = "Color", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            color.Location = new Point(10, 622);
            Center(color, this);
            this.Controls.Add(color);

        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        protected static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        protected void Center(Label label, Panel panel)
        {
            int labelWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(label.Text, label.Font);
                labelWidth = (int)size.Width + 7;
            }
            label.Width = labelWidth;
            label.Location = new Point(panel.Location.X + panel.Width / 2 - labelWidth / 2, label.Location.Y);
        }

        protected void LessThickness(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyForm("achicarLine");
        }

        protected void MoreThickness(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyForm("agrandarLine");
        }

        protected void LessSize(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyForm("achicarCanvas");
        }

        protected void MoreSize(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyForm("agrandarCanvas");
        }

        protected void TurnRightSize(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyForm("agrandarAngulo");
        }

        protected void TurnLeftSize(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyForm("achicarAngulo");
        }

        protected void FontDown(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyForm("achicarLetra");
        }

        protected void FontUp(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyForm("agrandarLetra");
        }
        protected void Blue(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyColor("#1C3671");
        }

        protected void Yellow(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyColor("#D7D700");
        }

        protected void Red(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyColor("#C90202");
        }

        protected void Green(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyColor("#00BD0D");
        }

        protected void Orange(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyColor("#FF9100");
        }

        protected void Violet(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyColor("#DE00E6");
        }

        protected void Black(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.ModifyColor("#000000");
        }

        public void ShowControlsRect()
        {
            this.Show();
            LessThicknessButton.Enabled = true;
            MoreThicknessButton.Enabled = true;
            LessSizeButton.Enabled = true;
            MoreSizeButton.Enabled = true;
            TurnRightButton.Enabled = true;
            TurnLeftButton.Enabled = true;
            FontDownButton.Enabled = false;
            FontUpButton.Enabled = false;
            BlueButton.Enabled = true;
            YellowButton.Enabled = true;
            RedButton.Enabled = true;
            GreenButton.Enabled = true;
            OrangeButton.Enabled = true;
            VioletButton.Enabled = true;
            BackButton.Enabled = true;
        }

        public void ShowControlsCircle()
        {
            this.Show();
            LessThicknessButton.Enabled = true;
            MoreThicknessButton.Enabled = true;
            LessSizeButton.Enabled = true;
            MoreSizeButton.Enabled = true;
            TurnRightButton.Enabled = false;
            TurnLeftButton.Enabled = false;
            FontDownButton.Enabled = false;
            FontUpButton.Enabled = false;
            BlueButton.Enabled = true;
            YellowButton.Enabled = true;
            RedButton.Enabled = true;
            GreenButton.Enabled = true;
            OrangeButton.Enabled = true;
            VioletButton.Enabled = true;
            BackButton.Enabled = true;
        }

        public void ShowControlsText()
        {
            this.Show();
            LessThicknessButton.Enabled = false;
            MoreThicknessButton.Enabled = false;
            LessSizeButton.Enabled = true;
            MoreSizeButton.Enabled = true;
            TurnRightButton.Enabled = true;
            TurnLeftButton.Enabled = true;
            FontDownButton.Enabled = true;
            FontUpButton.Enabled = true;
            BlueButton.Enabled = true;
            YellowButton.Enabled = true;
            RedButton.Enabled = true;
            GreenButton.Enabled = true;
            OrangeButton.Enabled = true;
            VioletButton.Enabled = true;
            BackButton.Enabled = true;
        }

        public void ShowControlsDiv()
        {
            this.Show();
            LessThicknessButton.Enabled = true;
            MoreThicknessButton.Enabled = true;
            LessSizeButton.Enabled = true;
            MoreSizeButton.Enabled = true;
            TurnRightButton.Enabled = true;
            TurnLeftButton.Enabled = true;
            FontDownButton.Enabled = true;
            FontUpButton.Enabled = true;
            BlueButton.Enabled = true;
            YellowButton.Enabled = true;
            RedButton.Enabled = true;
            GreenButton.Enabled = true;
            OrangeButton.Enabled = true;
            VioletButton.Enabled = true;
            BackButton.Enabled = true;
        }
    }

    class AsistimeTourCreationBar : Panel
    {
        public static AsistimeRoundButton AddStepButton = null;
        public static AsistimeRoundButton NavBackButton = null;
        public static AsistimeRoundButton ConfirmButton = null;
        public Label stepsLabel;

        public AsistimeTourCreationBar()
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Height = Constants.AppBarHeight;
            Width = Constants.AppBarWidth;

            

            this.Controls.Add(this.GetNavBackButton(50, 15));
            Label backLabel = new Label() { Text = "Cancelar tour", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(backLabel, NavBackButton);
            this.Controls.Add(backLabel);

            stepsLabel = new Label()
            {
                Text = "CANTIDAD DE PASOS: " + 0,
                Font = Constants.HLabelFont,
                ForeColor = Color.White,
                Width = 350,
                Height = 40
            };
            stepsLabel.Location = new Point(this.ClientSize.Width / 2 - 420, 55);
            this.Controls.Add(stepsLabel);
            stepsLabel.BringToFront();

            this.Controls.Add(this.GetAddStepsButton(this.ClientSize.Width - 300, 15)); //this.ClientSize.Width/2 - 49, 15));
            Label addTourLabel = new Label() { Text = "Agregar paso", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(addTourLabel, AddStepButton);
            this.Controls.Add(addTourLabel);

            this.Controls.Add(this.GetNavConfirmButton(this.ClientSize.Width - 150, 15));
            Label profileLabel = new Label() { Text = "Guardar tour", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(profileLabel, ConfirmButton);
            this.Controls.Add(profileLabel);
        }

        protected Control GetAddStepsButton(int x, int y)
        {
            if (AddStepButton == null)
            {
                AddStepButton = new AsistimeRoundButton(98, 98, Constants.AddTourImage, Constants.AddTourHoverImage, Constants.AddTourClickImage) { Parent = this.Parent };
                AddStepButton.Location = new Point(x, y);
            }
            AddStepButton.Click += new EventHandler(this.AddStep);
            return AddStepButton;
        }

        protected void AddStep(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.initStep();
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

        protected Control GetNavBackButton(int x, int y)
        {
            if (NavBackButton == null)
            {
                NavBackButton = new AsistimeRoundButton(98, 98, Constants.CancelRedImageB, Constants.CancelRedHoverImageB, Constants.CancelRedClickImageB) { Parent = this.Parent };
                NavBackButton.Location = new Point(x, y);
            }
            NavBackButton.Click += new EventHandler(this.NavigateBack);
            return NavBackButton;
        }

        protected void NavigateBack(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.cancelTour();
        }

        protected Control GetNavConfirmButton(int x, int y)
        {
            if (ConfirmButton == null)
            {
                ConfirmButton = new AsistimeRoundButton(98, 98, Constants.ConfirmGreenImageB, Constants.ConfirmGreenHoverImageB, Constants.ConfirmGreenClickImageB) { Parent = this.Parent };
                ConfirmButton.Location = new Point(x, y);
            }
            ConfirmButton.Click += new EventHandler(this.SaveTour);
            return ConfirmButton;
        }

        protected void SaveTour(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.endTutorial();
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

            this.Controls.Add(this.GetNavBackButton(50, 15));
            Label backLabel = new Label() { Text = "Atrás", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(backLabel, NavBackButton);
            this.Controls.Add(backLabel);

            var firstElement = (this.Width / 2 - 44 - 260);

            AsistimeRoundButton RectangleButton = new AsistimeRoundButton(84, 84, Constants.RectImage2, Constants.RectHoverImage2, Constants.RectClickImage2) { Parent = this.Parent };
            Label rectLabel = new Label() { Text = "Cuadrado", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            RectangleButton.Location = new Point(firstElement, 28);
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

            AsistimeRoundButton TextButton = new AsistimeRoundButton(84, 84, Constants.TextImage2, Constants.TextHoverImage2, Constants.TextClickImage2) { Parent = this.Parent };
            Label textLabel = new Label() { Text = "Texto", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            TextButton.Location = new Point(RectangleButton.Location.X + 220, RectangleButton.Location.Y);
            Center_With(textLabel, TextButton);
            TextButton.Click += new EventHandler(DrawText);
            this.Controls.Add(TextButton);
            this.Controls.Add(textLabel);

            AsistimeRoundButton CircleButton = new AsistimeRoundButton(84, 84, Constants.CircleImage2, Constants.CircleHoverImage2, Constants.CircleClickImage2) { Parent = this.Parent };
            Label circleLabel = new Label() { Text = "Círculo", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            CircleButton.Location = new Point(RectangleButton.Location.X + 330, RectangleButton.Location.Y);
            Center_With(circleLabel, CircleButton);
            CircleButton.Click += new EventHandler(DrawCircle);
            this.Controls.Add(CircleButton);
            this.Controls.Add(circleLabel);

            AsistimeRoundButton AudioButton = new AsistimeRoundButton(84, 84, Constants.AudioImage, Constants.AudioHoverImage, Constants.AudioClickImage) { Parent = this.Parent };
            Label audioLabel = new Label() { Text = "Audio", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            AudioButton.Location = new Point(RectangleButton.Location.X + 440, RectangleButton.Location.Y);
            Center_With(audioLabel, AudioButton);
            AudioButton.Click += new EventHandler(RecordAudio);
            this.Controls.Add(AudioButton);
            this.Controls.Add(audioLabel);

            AsistimeRoundButton EraseButton = new AsistimeRoundButton(84, 84, Constants.EraseImage, Constants.EraseHoverImage, Constants.EraseClickImage) { Parent = this.Parent };
            Label eraseLabel = new Label() { Text = "Borrar", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            EraseButton.Location = new Point(RectangleButton.Location.X + 550, RectangleButton.Location.Y);
            Center_With(eraseLabel, EraseButton);
            EraseButton.Click += new EventHandler(EraseForm);
            this.Controls.Add(EraseButton);
            this.Controls.Add(eraseLabel);

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

        protected void EraseForm(object sender, EventArgs e)
        {
            NavigatorAssistant form = this.Parent as NavigatorAssistant;
            form.drawForm("borrador");
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

        protected void RecordAudio(object sender, EventArgs e)
        {
            NavigatorAssistant form = this.Parent as NavigatorAssistant;
            form.RecordAudio();
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
            control.cancelStep();
        }

        protected Control GetNavConfirmButton(int x, int y)
        {
            if (ConfirmButton == null)
            {
                ConfirmButton = new AsistimeRoundButton(98, 98, Constants.ConfirmImage, Constants.ConfirmHoverImage, Constants.ConfirmClickImage) { Parent = this.Parent };
                ConfirmButton.Location = new Point(x, y);
            }
            ConfirmButton.Click += new EventHandler(this.SaveStep);
            return ConfirmButton;
        }

        protected void SaveStep(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.save();
        }

    }

    class AsistimeIconBar : Panel
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private AsistimeRoundButton Ban;
        private AsistimeRoundButton Bell;
        private AsistimeRoundButton Check;
        private AsistimeRoundButton Comment;
        private AsistimeRoundButton Frown;
        private AsistimeRoundButton GrinAlt;
        private AsistimeRoundButton HandPaper;
        private AsistimeRoundButton HandPointUp;
        private AsistimeRoundButton ShoePrints;
        private AsistimeRoundButton ShoppingCart;
        private AsistimeRoundButton ThumbsUp;

        public AsistimeIconBar()
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Height = 700;
            Width = 200;

            this.MouseMove += new MouseEventHandler(panel_MouseMove);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            Ban = new AsistimeRoundButton(37, 37, Constants.Ban, Constants.BanHover, Constants.BanHover) { Parent = this.Parent };
            Ban.Location = new Point(40, 30);
            Ban.Click += new EventHandler((sender, e) => DrawIcon("ban"));
            this.Controls.Add(Ban);

            Bell = new AsistimeRoundButton(37, 37, Constants.Bell, Constants.BellHover, Constants.BellHover) { Parent = this.Parent };
            Bell.Location = new Point(107, 30);
            Bell.Click += new EventHandler((sender, e) => DrawIcon("bell"));
            this.Controls.Add(Bell);

            Check = new AsistimeRoundButton(37, 37, Constants.Check, Constants.CheckHover, Constants.CheckHover) { Parent = this.Parent };
            Check.Location = new Point(40, 147);
            Check.Click += new EventHandler((sender, e) => DrawIcon("check"));
            this.Controls.Add(Check);

            Comment = new AsistimeRoundButton(37, 37, Constants.Comment, Constants.CommentHover, Constants.CommentHover) { Parent = this.Parent };
            Comment.Location = new Point(107, 147);
            Comment.Click += new EventHandler((sender, e) => DrawIcon("comment"));
            this.Controls.Add(Comment);

            Frown = new AsistimeRoundButton(37, 37, Constants.Frown, Constants.FrownHover, Constants.FrownHover) { Parent = this.Parent };
            Frown.Location = new Point(40, 264);
            Frown.Click += new EventHandler((sender, e) => DrawIcon("frown"));
            this.Controls.Add(Frown);

            GrinAlt = new AsistimeRoundButton(37, 37, Constants.GrinAlt, Constants.GrinAltHover, Constants.GrinAltHover) { Parent = this.Parent };
            GrinAlt.Location = new Point(107, 264);
            GrinAlt.Click += new EventHandler((sender, e) => DrawIcon("grin-alt"));
            this.Controls.Add(GrinAlt);

            HandPaper = new AsistimeRoundButton(37, 37, Constants.HandPaper, Constants.HandPaperHover, Constants.HandPaperHover) { Parent = this.Parent };
            HandPaper.Location = new Point(40, 381);
            HandPaper.Click += new EventHandler((sender, e) => DrawIcon("hand-paper"));
            this.Controls.Add(HandPaper);

            HandPointUp = new AsistimeRoundButton(37, 37, Constants.HandPointUp, Constants.HandPointUpHover, Constants.HandPointUpHover) { Parent = this.Parent };
            HandPointUp.Location = new Point(107, 381);
            HandPointUp.Click += new EventHandler((sender, e) => DrawIcon("hand-point-up"));
            this.Controls.Add(HandPointUp);

            ShoePrints = new AsistimeRoundButton(37, 37, Constants.ShoePrints, Constants.ShoePrintsHover, Constants.ShoePrintsHover) { Parent = this.Parent };
            ShoePrints.Location = new Point(30, 498);
            ShoePrints.Click += new EventHandler((sender, e) => DrawIcon("shoe-prints"));
            this.Controls.Add(ShoePrints);

            ShoppingCart = new AsistimeRoundButton(37, 37, Constants.ShoppingCart, Constants.ShoppingCartHover, Constants.ShoppingCartHover) { Parent = this.Parent };
            ShoppingCart.Location = new Point(80, 498);
            ShoppingCart.Click += new EventHandler((sender, e) => DrawIcon("shopping-cart"));
            this.Controls.Add(ShoppingCart);

            ThumbsUp = new AsistimeRoundButton(37, 37, Constants.ThumbsUp, Constants.ThumbsUpHover, Constants.ThumbsUpHover) { Parent = this.Parent };
            ThumbsUp.Location = new Point(130, 498);
            ThumbsUp.Click += new EventHandler((sender, e) => DrawIcon("thumbs-up"));
            this.Controls.Add(ThumbsUp);
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        protected static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        private void DrawIcon(String icon)
        {
            //recibe como parámetro el ícono que tiene que dibujar
        }
    }


}