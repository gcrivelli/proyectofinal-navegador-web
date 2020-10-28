using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NavegadorWeb.Models;

namespace NavegadorWeb.UI
{
    class AsistimeBasePopup : Panel
    {
        protected Label title;

        public AsistimeBasePopup()
        {
            this.Width = 700;
            this.Height = 800;
            this.BackColor = Color.White;

            Panel frontPanel = new Panel();
            frontPanel.Width = this.Width - 10;
            frontPanel.Height = this.Height - 10;
            frontPanel.BackColor = Color.White;
            frontPanel.Location = new Point(this.Location.X + 5, this.Location.Y + 5);
            Controls.Add(frontPanel);
            frontPanel.SendToBack();
            frontPanel.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, frontPanel.Width, frontPanel.Height, 18, 18));

            Panel backPanel = new Panel();
            backPanel.Width = this.Width;
            backPanel.Height = this.Height;
            backPanel.BackColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            backPanel.Location = new Point(this.Location.X, this.Location.Y);
            Controls.Add(backPanel);
            backPanel.SendToBack();

            title = new Label()
            {
                Text = "CREACIÓN DE TOUR",
                Font = Constants.HLabelFont,
                Width = 400,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
            };
            title.Location = new Point(this.Width / 2 - title.Width / 2, 50);
            this.Controls.Add(title);
            title.BringToFront();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
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
    }

    class AsistimeCreatePanel : AsistimeBasePopup
    {
        private AsistimeSearchBox tourNameTextBox;
        private AsistimeSearchBox tourDescTextBox;

        private AsistimeActionButton nextButton;
        private AsistimeActionButton cancelButton;

        private AsistimeSearchBox box;
        private Label tourNameLabel;
        private TextBox textbox;

        public AsistimeCreatePanel()
        {
            this.title.Text = "CREACIÓN DE TOUR";

            tourNameLabel = new Label()
            {
                Text = "NOMBRE DEL TOUR",
                Font = Constants.H2LabelFont,
                Width = 400
            };
            this.Controls.Add(tourNameLabel);
            tourNameLabel.BringToFront();

            tourNameTextBox = new AsistimeSearchBox()
            {
                Font = Constants.TextBoxFont,
                Parent = this,
                Width = 400,
                TextName = null
            };
            this.Controls.Add(tourNameTextBox);
            tourNameTextBox.BringToFront();

            Label tourDescTextBox = new Label()
            {
                Text = "DESCRIPCIÓN",
                Font = Constants.H2LabelFont,
                Width = 400
            };
            this.Controls.Add(tourDescTextBox);
            tourDescTextBox.BringToFront();

            box = new AsistimeSearchBox();
            box.Width = 400;
            box.Height = 300;
            this.Controls.Add(box);
            box.BringToFront();

            textbox = new TextBox();
            textbox.Multiline = true;
            textbox.Width = 380; //20 menos que el ancho del searchbox
            textbox.Height = 280; //20 menos que la altura del searchbox
            this.Controls.Add(textbox);
            textbox.BorderStyle = BorderStyle.None;
            textbox.Font = Constants.H2LabelFont;
            textbox.BringToFront();

            box.Location = new Point(this.Width / 2 - box.Width / 2, 260);
            textbox.Location = new Point(box.Location.X + 10, box.Location.Y + 10);
            tourDescTextBox.Location = new Point(box.Location.X, box.Location.Y - 30);
            tourNameTextBox.Location = new Point(this.Width / 2 - tourNameTextBox.Width / 2, 150);
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
            if (tourNameTextBox.TextName != string.Empty && textbox.Text != string.Empty)
            {
                AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
                form.AdvanceToSteps(tourNameTextBox.TextName, textbox.Text);
            }
            else
                MessageBox.Show("Elija un nombre y descripción para el tutorial.", "Nombre Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected void Cancel(object sender, EventArgs e)
        {
            AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
            form.BackToNavigation();
        }
    }





    class AsistimeStepsPanel : AsistimeBasePopup
    {
        private AsistimeActionButton nextButton;
        private AsistimeActionButton cancelButton;

        private Label tourNameLabel;
        private TextBox textbox;
        private int stepCount;

        //private List<Step>;

        public AsistimeStepsPanel()
        {
            this.title.Text = "ALTA DE PASOS";
            stepCount = 0;

            /*tourNameLabel = new Label()
            {
                Font = Constants.H2LabelFont,
                Width = 400
            };
            this.Controls.Add(tourNameLabel);*/

            textbox = new TextBox();
            textbox.Multiline = true;
            textbox.Width = 450;
            textbox.Height = 300;
            this.Controls.Add(textbox);
            textbox.BorderStyle = BorderStyle.None;
            textbox.Font = Constants.H2LabelFont;
            textbox.BringToFront();
            textbox.Text = "¡Agregá pasos al tour! En cada paso, indicale al adulto mayor qué es lo que debe hacer, ayudándolo con dibujos en pantalla y un audio opcional. Recordá que cuanta menos información incluyas en cada paso, el adulto mayor podrá realizar el tour con mas facilidad.";
            textbox.TextAlign = HorizontalAlignment.Center;
            textbox.Location = new Point(this.Width / 2 - textbox.Width / 2, 120);
            //tourNameLabel.Location = new Point(textbox.Location.X, textbox.Location.Y - 30);

            Label stepsLabel = new Label()
            {
                Text = "CANTIDAD DE PASOS: " + stepCount,
                Font = Constants.H2LabelFont,
                Width = 400
            };
            stepsLabel.Location = new Point(textbox.Location.X, textbox.Location.Y + textbox.Height);
            this.Controls.Add(stepsLabel);

            AsistimeRoundButton AddStepButton = new AsistimeRoundButton(84, 84, Constants.AddStepImage, Constants.AddStepHoverImage, Constants.AddStepClickImage) { Parent = this.Parent };
            Label addLabel = new Label() { Text = "Agregar paso", ForeColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour), Font = Constants.H1LabelFont, Height = 40 };
            AddStepButton.Location = new Point(450, textbox.Location.Y + textbox.Height - 30);
            Center_With(addLabel, AddStepButton);
            AddStepButton.Click += new EventHandler(AddStep);
            this.Controls.Add(AddStepButton);
            AddStepButton.BringToFront();
            this.Controls.Add(addLabel);

            nextButton = new AsistimeActionButton();
            nextButton.Click += new EventHandler(Next);
            nextButton.ButtonText = "Siguiente";
            this.Controls.Add(nextButton);
            nextButton.BringToFront();

            cancelButton = new AsistimeActionButton();
            cancelButton.Click += new EventHandler(Cancel);
            cancelButton.ButtonText = "Anterior";
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

        public void SetTour(String name, String desc, int stepCount)
        {
            /*tourNameLabel.Text = name;
            textbox.Text = desc;*/
            stepCount = stepCount;
        }

        protected void AddStep(object sender, EventArgs e)
        {
            stepCount++;
            AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
            form.AdvanceToForms();
        }

        protected void Next(object sender, EventArgs e)
        {
            if (stepCount != 0)
            {
                AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
                form.ConfirmTour();
            }
            else
                MessageBox.Show("¡Agregá pasos al tour! Por ahora no tiene niguno.", "Tour vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        protected void Cancel(object sender, EventArgs e)
        {
            AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
            form.BackToTour();
        }

        public void cancelLastStep()
        {
            stepCount--;
        }


    }

    class AsistimeFormsPanel : AsistimeBasePopup
    {
        private AsistimeActionButton nextButton;
        private AsistimeActionButton cancelButton;
        private TextBox textbox;

        public AsistimeFormsPanel()
        {
            this.title.Text = "CREACIÓN DE FORMAS";

            textbox = new TextBox();
            textbox.Multiline = true;
            textbox.Width = 450;
            textbox.Height = 250;
            this.Controls.Add(textbox);
            textbox.BorderStyle = BorderStyle.None;
            textbox.Font = Constants.H2LabelFont;
            textbox.BringToFront();
            textbox.Text = "¡Dale forma al tour! Cada una de las siguientes formas está pensada para resaltar sectores del sitio web. Con ellas podés indicarle al adulto mayor en qué sector de la página debe realizar una acción, qué componentes debe observar, o restringir el 'click' en algún sector.";
            textbox.TextAlign = HorizontalAlignment.Center;
            textbox.Location = new Point(this.Width / 2 - textbox.Width / 2, 120);

            AsistimeRoundButton RectangleButton = new AsistimeRoundButton(84, 84, Constants.RectImage, Constants.RectHoverImage, Constants.RectClickImage) { Parent = this.Parent };
            Label rectLabel = new Label() { Text = "Rectángulo", ForeColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour), Font = Constants.H1LabelFont, Height = 40 };
            RectangleButton.Location = new Point(87, 400);
            Center_With(rectLabel, RectangleButton);
            RectangleButton.Click += new EventHandler(DrawRectangle);
            this.Controls.Add(RectangleButton);
            this.Controls.Add(rectLabel);

            AsistimeRoundButton DivButton = new AsistimeRoundButton(84, 84, Constants.DivImage, Constants.DivHoverImage, Constants.DivClickImage) { Parent = this.Parent };
            Label divLabel = new Label() { Text = "Recuadrar", ForeColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour), Font = Constants.H1LabelFont, Height = 40 };
            DivButton.Location = new Point(RectangleButton.Location.X + 110, RectangleButton.Location.Y);
            Center_With(divLabel, DivButton);
            DivButton.Click += new EventHandler(DrawDiv);
            this.Controls.Add(DivButton);
            this.Controls.Add(divLabel);

            AsistimeRoundButton DialogButton = new AsistimeRoundButton(84, 84, Constants.DialogImage, Constants.DialogHoverImage, Constants.DialogClickImage) { Parent = this.Parent };
            Label dialogLabel = new Label() { Text = "Diálogo", ForeColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour), Font = Constants.H1LabelFont, Height = 40 };
            DialogButton.Location = new Point(RectangleButton.Location.X + 220, RectangleButton.Location.Y);
            Center_With(dialogLabel, DialogButton);
            DialogButton.Click += new EventHandler(DrawDialog);
            this.Controls.Add(DialogButton);
            this.Controls.Add(dialogLabel);

            AsistimeRoundButton TextButton = new AsistimeRoundButton(84, 84, Constants.TextImage, Constants.TextHoverImage, Constants.TextClickImage) { Parent = this.Parent };
            Label textLabel = new Label() { Text = "Texto", ForeColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour), Font = Constants.H1LabelFont, Height = 40 };
            TextButton.Location = new Point(RectangleButton.Location.X + 330, RectangleButton.Location.Y);
            Center_With(textLabel, TextButton);
            TextButton.Click += new EventHandler(DrawText);
            this.Controls.Add(TextButton);
            this.Controls.Add(textLabel);

            AsistimeRoundButton CircleButton = new AsistimeRoundButton(84, 84, Constants.CircleImage, Constants.CircleHoverImage, Constants.CircleClickImage) { Parent = this.Parent };
            Label circleLabel = new Label() { Text = "Círculo", ForeColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour), Font = Constants.H1LabelFont, Height = 40 };
            CircleButton.Location = new Point(RectangleButton.Location.X + 440, RectangleButton.Location.Y);
            Center_With(circleLabel, CircleButton);
            CircleButton.Click += new EventHandler(DrawCircle);
            this.Controls.Add(CircleButton);
            this.Controls.Add(circleLabel);

            nextButton = new AsistimeActionButton();
            nextButton.Click += new EventHandler(Next);
            nextButton.ButtonText = "Siguiente";
            this.Controls.Add(nextButton);
            nextButton.BringToFront();

            cancelButton = new AsistimeActionButton();
            cancelButton.Click += new EventHandler(Cancel);
            cancelButton.ButtonText = "Anterior";
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
            AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
            //form.AdvanceToAudio();
        }

        protected void Cancel(object sender, EventArgs e)
        {
            AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
            form.BackToSteps();
        }

        protected void DrawCircle(object sender, EventArgs e)
        {
            AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
            form.drawForm("circulo");
        }

        protected void DrawText(object sender, EventArgs e)
        {
            AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
            form.drawForm("texto");
        }

        protected void DrawDialog(object sender, EventArgs e)
        {
            AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
            form.drawForm("dialogo");
        }

        protected void DrawDiv(object sender, EventArgs e)
        {
            AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
            form.drawForm("div");
        }

        protected void DrawRectangle(object sender, EventArgs e)
        {
            AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
            form.drawForm("rectangulo");
        }
    }

    class AsistimeAudioPanel : AsistimeBasePopup
    {
        public static HtmlDocument doc;
        String UrlReproductor = null;
        SoundPlayer ReproductorWav;
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        private AsistimeActionButton nextButton;
        private AsistimeActionButton cancelButton;
        AsistimeRoundButton RecordButton;
        AsistimeRoundButton StopButton;
        AsistimeRoundButton PlayButton;
        private TextBox textbox;

        public String tourName;
        public int countStep;

        public AsistimeAudioPanel()
        {
            this.title.Text = "GRABACIÓN DE AUDIO";

            textbox = new TextBox();
            textbox.Multiline = true;
            textbox.Width = 450;
            textbox.Height = 250;
            this.Controls.Add(textbox);
            textbox.BorderStyle = BorderStyle.None;
            textbox.Font = Constants.H2LabelFont;
            textbox.BringToFront();
            textbox.Text = "Recordá hablar despacio y claro, para que alguien mayor te pueda entender. ¡Ojo! Sólo puede haber un audio por paso, si ya existe un audio y grabás uno nuevo vas a borrar el anterior.";
            textbox.TextAlign = HorizontalAlignment.Center;
            textbox.Location = new Point(this.Width / 2 - textbox.Width / 2, 120);

            ReproductorWav = new SoundPlayer();

            RecordButton = new AsistimeRoundButton(84, 84, Constants.RecordImage, Constants.RecordHoverImage, Constants.RecordClickImage) { Parent = this.Parent };
            Label recordLabel = new Label() { Text = "Grabar", ForeColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour), Font = Constants.H1LabelFont, Height = 40 };
            RecordButton.Location = new Point(103, 400);
            Center_With(recordLabel, RecordButton);
            RecordButton.Click += new EventHandler(RecordAudio);
            this.Controls.Add(RecordButton);
            this.Controls.Add(recordLabel);
            recordLabel.BringToFront();
            RecordButton.BringToFront();

            StopButton = new AsistimeRoundButton(84, 84, Constants.StopImage, Constants.StopHoverImage, Constants.StopClickImage) { Parent = this.Parent };
            Label stopLabel = new Label() { Text = "Parar", ForeColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour), Font = Constants.H1LabelFont, Height = 40 };
            StopButton.Location = new Point(RecordButton.Location.X + 205, RecordButton.Location.Y);
            Center_With(stopLabel, StopButton);
            StopButton.Click += new EventHandler(StopRecording);
            this.Controls.Add(StopButton);
            StopButton.Enabled = false;
            this.Controls.Add(stopLabel);
            stopLabel.BringToFront();
            StopButton.BringToFront();

            PlayButton = new AsistimeRoundButton(84, 84, Constants.ListenImage, Constants.ListenHoverImage, Constants.ListenClickImage) { Parent = this.Parent };
            Label playLabel = new Label() { Text = "Reproducir", ForeColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour), Font = Constants.H1LabelFont, Height = 40 };
            PlayButton.Location = new Point(RecordButton.Location.X + 410, RecordButton.Location.Y);
            Center_With(playLabel, PlayButton);
            PlayButton.Click += new EventHandler(PlayAudio);
            this.Controls.Add(PlayButton);
            PlayButton.Enabled = false;
            this.Controls.Add(playLabel);
            playLabel.BringToFront();
            PlayButton.BringToFront();


            nextButton = new AsistimeActionButton();
            nextButton.Click += new EventHandler(Next);
            nextButton.ButtonText = "¡Listo!";
            this.Controls.Add(nextButton);
            nextButton.BringToFront();

            /*cancelButton = new AsistimeActionButton();
            cancelButton.Click += new EventHandler(Cancel);
            cancelButton.ButtonText = "Anterior";
            this.Controls.Add(cancelButton);
            cancelButton.BringToFront();*/

            int nextButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(nextButton.ButtonText, nextButton.Font);
                size.Width += 40;
                nextButtonWidth = (int)size.Width;
            }
            nextButton.Location = new Point(this.Width / 2 - nextButtonWidth / 2, 600);

            try
            {
                if (File.Exists(UrlReproductor))
                {
                    PlayButton.Enabled = false;
                };
            }
            catch
            {
                MessageBox.Show("Error al crear el directorio para los audios", "Error");
            }

            /*int cancelButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(cancelButton.ButtonText, cancelButton.Font);
                size.Width += 40;
                cancelButtonWidth = (int)size.Width;
            }
            cancelButton.Location = new Point(this.Width / 2 - cancelButtonWidth / 2, nextButton.Location.Y + 80);*/
        }

        protected void Next(object sender, EventArgs e)
        {
            AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
            form.ConfirmStep();
        }

        protected void Cancel(object sender, EventArgs e)
        {
            AsistimeTourCreation form = this.Parent as AsistimeTourCreation;
            form.BackToForms();
        }

        private void RecordAudio(object sender, EventArgs e)
        {
            record("open new Type waveaudio Alias recsound", "", 0, 0);
            record("record recsound", "", 0, 0);
            PlayButton.Enabled = false;
            StopButton.Enabled = true;
        }

        private void StopRecording(object sender, EventArgs e)
        {
            createDirectory();

            var nameTourWithoutSpace = this.tourName.Replace(" ", "");
            var audioName = "/Audio" + nameTourWithoutSpace + this.countStep + ".wav";
            UrlReproductor = Constants.audioPath + audioName;

            record("save recsound " + UrlReproductor, "", 0, 0);
            record("close recsound", "", 0, 0);

            MessageBox.Show("Archivo de audio guardado en: " + UrlReproductor);

            PlayButton.Enabled = true;
            StopButton.Enabled = false;
        }

        private void PlayAudio(object sender, EventArgs e)
        {
            ReproductorWav.SoundLocation = UrlReproductor;
            ReproductorWav.Play();
        }

        private void createDirectory()
        {
            var path = Constants.audioPath;
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch
            {
                MessageBox.Show("Error al crear el directorio para los audios", "Error");
            }
        }

        public void SetTour(String name, int count)
        {
            this.tourName = name;
            this.countStep = count;
        }
    }











    class TutorialStep : Panel
    {
        protected Label title;
        protected TextBox subTitle;
        public TutorialStep previous;
        public TutorialStep next;
        protected AsistimeRoundButton BackButton;
        protected AsistimeRoundButton ForwardButton;

        public TutorialStep()
        {
            this.Width = 700;
            this.Height = 500;
            this.BackColor = Color.White;

            Panel frontPanel = new Panel();
            frontPanel.Width = this.Width-10;
            frontPanel.Height = this.Height-10;
            frontPanel.BackColor = Color.White;
            frontPanel.Location = new Point(this.Location.X + 5, this.Location.Y + 5);
            Controls.Add(frontPanel);
            frontPanel.SendToBack();
            frontPanel.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, frontPanel.Width, frontPanel.Height, 18, 18));

            Panel backPanel = new Panel();
            backPanel.Width = this.Width;
            backPanel.Height = this.Height;
            backPanel.BackColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            backPanel.Location = new Point(this.Location.X, this.Location.Y);
            Controls.Add(backPanel);
            backPanel.SendToBack();

            title = new Label()
            {
                Text = " ",
                Font = Constants.HLabelFont,
                Width = 400,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
            };
            title.Location = new Point(this.Width / 2 - title.Width / 2, 50);
            this.Controls.Add(title);
            title.BringToFront();

            subTitle = new TextBox();
            subTitle.Multiline = true;
            subTitle.Width = 450;
            subTitle.Height = 250;
            this.Controls.Add(subTitle);
            subTitle.BorderStyle = BorderStyle.None;
            subTitle.Font = Constants.H2LabelFont;
            subTitle.BringToFront();
            subTitle.Text = " ";
            subTitle.TextAlign = HorizontalAlignment.Center;
            subTitle.Location = new Point(this.Width / 2 - subTitle.Width / 2, 120);
            subTitle.BringToFront();

            BackButton = new AsistimeRoundButton(98, 98, Constants.PreviousImage, Constants.PreviousHoverImage, Constants.PreviousClickImage) { Parent = this.Parent };
            BackButton.Location = new Point(30, 372);
            BackButton.Click += new EventHandler(this.Back);
            this.Controls.Add(BackButton);
            BackButton.BringToFront();

            ForwardButton = new AsistimeRoundButton(98, 98, Constants.NextImage, Constants.NextHoverImage, Constants.NextClickImage) { Parent = this.Parent };
            ForwardButton.Location = new Point(572, 372);
            ForwardButton.Click += new EventHandler(this.Forward);
            this.Controls.Add(ForwardButton);
            ForwardButton.BringToFront();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
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

        protected void Back(object sender, EventArgs e)
        {
            this.Hide();
            previous.Show();
        }

        protected void Forward(object sender, EventArgs e)
        {
            this.Hide();
            next.Show();
        }
    }

    class HowToTour : TutorialStep
    {
        public HowToTour()
        {
            this.BackButton.Hide();
            AsistimeRoundButton CancelButton = new AsistimeRoundButton(98, 98, Constants.CancelImage, Constants.CancelHoverImage, Constants.CancelClickImage) { Parent = this.Parent };
            CancelButton.Location = new Point(BackButton.Location.X, BackButton.Location.Y);
            CancelButton.Click += new EventHandler(this.Cancel);
            this.Controls.Add(CancelButton);
            CancelButton.BringToFront();

            title.Text = "CREACIÓN DE TOUR";
            subTitle.Text = "Creá un tour para un adulto mayor. Dale un nombre que represente para qué sirve, y una descripción para que la persona que lo realice entienda de qué se trata.";
        }

        protected void Cancel(object sender, EventArgs e)
        {
            this.Hide();
        }
    }

    class HowToSteps : TutorialStep
    {
        public HowToSteps()
        {
            title.Text = "ALTA DE PASOS";
            subTitle.Text = "¡Agregá pasos al tour! En cada paso, indicale al adulto mayor qué es lo que debe hacer, ayudándolo con dibujos en pantalla y un audio opcional. Recordá que cuanta menos información incluyas en cada paso, el adulto mayor podrá realizar el tour con mas facilidad.";
        }
    }

    class HowToForms : TutorialStep
    {
        public HowToForms()
        {
            title.Text = "CREACIÓN DE FORMAS";
            subTitle.Text = "¡Dale forma a los pasos! Cada una de las formas que podés agregar a los pasos está pensada para resaltar sectores del sitio web. Con ellas podés indicarle al adulto mayor en qué sector de la página debe realizar una acción, qué componentes debe observar, o restringir el 'click' en algún sector.";
        }
    }

    class HowToAudio : TutorialStep
    {
        public HowToAudio()
        {
            this.ForwardButton.Hide();
            AsistimeRoundButton ConfirmButton = new AsistimeRoundButton(98, 98, Constants.OkImage, Constants.OkHoverImage, Constants.OkClickImage) { Parent = this.Parent };
            ConfirmButton.Location = new Point(ForwardButton.Location.X, ForwardButton.Location.Y);
            ConfirmButton.Click += new EventHandler(this.Confirm);
            this.Controls.Add(ConfirmButton);
            ConfirmButton.BringToFront();

            title.Text = "GRABACIÓN DE AUDIO";
            subTitle.Text = "¡Con audio se entiende mejor! Podés grabar una ayuda auditiva que explique la acción que se debe realizar. Recordá hablar despacio y claro, para que alguien mayor te pueda entender. Si querés, podés saltear este paso.";
        }

        protected void Confirm(object sender, EventArgs e)
        {
            this.Hide();
            AsistimeTourCreation form = Parent as AsistimeTourCreation;
            form.GoToTour();
        }
    }

}
