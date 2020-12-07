using NavegadorWeb.Adult;
using NavegadorWeb.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeTourBar : Panel
    {
        public static AsistimeRoundButton StepBackButton = null;
        public static AsistimeRoundButton PlayButton = null;
        public static AsistimeRoundButton StepForwardButton = null;
        public static AsistimeRoundButton CloseTourButton = null;
        public static AsistimeTourProgressBar progressBar;
        private Tour tour;
        public int StepCount;
        public bool isLastStepInUrl;

        public AsistimeTourBar()
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Height = Constants.AppBarHeight;
            Width = Constants.AppBarWidth;

            progressBar = new AsistimeTourProgressBar();
            this.Controls.Add(progressBar);


            this.Controls.Add(this.GetStepBackButton((this.Width / 2) - 49 - 200, 15));
            this.Controls.Add(this.GetPlayButton((this.Width / 2) - 49, 15));
            this.Controls.Add(this.GetStepForwardButton((this.Width / 2) - 49 + 200, 15));
            this.Controls.Add(this.GetCloseTourButton(this.ClientSize.Width - 150, 15));
            StepBackButton.Enabled = false;

            Label backLabel = new Label() { Text = "Paso anterior", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(backLabel, StepBackButton);
            this.Controls.Add(backLabel);
            Label playLabel = new Label() { Text = "Repetir paso", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(playLabel, PlayButton);
            this.Controls.Add(playLabel);
            Label forwardLabel = new Label() { Text = "Siguiente paso", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(forwardLabel, StepForwardButton);
            this.Controls.Add(forwardLabel);
            Label closeLabel = new Label() { Text = "Cerrar", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(closeLabel, CloseTourButton);
            this.Controls.Add(closeLabel);
        }
        public void SetStep(int actualStep)
        {
            this.StepCount = actualStep;
            double progressDouble = ((double)(StepCount + 1) / (double)tour.steps.Count) * 100;
            int progress = (int)Math.Truncate(progressDouble);
            progressBar.Value = progress;
            StepForwardButton.Enabled = ValidateForwardButton();
            StepBackButton.Enabled = ValidateBackButton();
        }

        protected Control GetStepBackButton(int x, int y)
        {
            if (StepBackButton == null)
            {
                StepBackButton = new AsistimeRoundButton(98, 98, Constants.StepBackImage, Constants.StepBackHoverImage, Constants.StepBackClickImage) { Parent = this.Parent };
                StepBackButton.Location = new Point(x, y);
            }
            StepBackButton.Click += new EventHandler(this.GoOneStepBack);
            return StepBackButton;
        }

        protected void GoOneStepBack(object sender, EventArgs e)
        {
            NavigatorAdult form = this.Parent as NavigatorAdult;
            if (form.actualTour._id == tour._id && StepCount > 0 &&  StepCount != 99)
            {
                StepCount--;
                this.SetStep(StepCount);
                playStepInTheSameUrl(tour, StepCount);
            }

            if (StepCount == 0)
                StepBackButton.Enabled = false;
        }

        protected Control GetPlayButton(int x, int y)
        {
            if (PlayButton == null)
            {
                PlayButton = new AsistimeRoundButton(98, 98, Constants.StepPlayImage, Constants.StepPlayHoverImage, Constants.StepPlayClickImage) { Parent = this.Parent };
                PlayButton.Location = new Point(x, y);
            }
            PlayButton.Click += new EventHandler(this.PlayStep);
            return PlayButton;
        }

        protected void PlayStep(object sender, EventArgs e)
        {
            NavigatorAdult form = this.Parent as NavigatorAdult;
            if (form.actualTour._id == tour._id && StepCount != 99)
            {
                playStepInTheSameUrl(tour, StepCount);
            }
        }

        protected Control GetStepForwardButton(int x, int y)
        {
            if (StepForwardButton == null)
            {
                StepForwardButton = new AsistimeRoundButton(98, 98, Constants.StepForwardImage, Constants.StepForwardHoverImage, Constants.StepForwardClickImage) { Parent = this.Parent };
                StepForwardButton.Location = new Point(x, y);
            }
            StepForwardButton.Click += new EventHandler(this.GoOneStepForward);
            return StepForwardButton;
        }

        protected void GoOneStepForward(object sender, EventArgs e)
        {
            NavigatorAdult form = this.Parent as NavigatorAdult;
            if (form.actualTour._id == tour._id && StepCount < tour.steps.Count && StepCount != 99)
            {
                StepCount++;
                this.SetStep(StepCount);
                playStepInTheSameUrl(tour, StepCount);
            }
        }

        protected Control GetCloseTourButton(int x, int y)
        {
            if (CloseTourButton == null)
            {
                CloseTourButton = new AsistimeRoundButton(98, 98, Constants.CloseTourImage, Constants.CloseTourHoverImage, Constants.CloseTourClickImage) { Parent = this.Parent };
                CloseTourButton.Location = new Point(x, y);
            }
            CloseTourButton.Click += new EventHandler(this.CloseTour);
            return CloseTourButton;
        }

        protected void CloseTour(object sender, EventArgs e)
        {
            NavigatorAdult form = this.Parent as NavigatorAdult;
            form.CloseTour();
            StepCount = 99;
        }

        public void TourInititated(Tour tour)
        {
            StepCount = 0;
            this.tour = tour;
            this.SetStep(StepCount);
        }

        private bool ValidateForwardButton()
        {
            if (StepCount == tour.steps.Count - 1) //es el último paso
            {
                return false;
            }
            else if (tour.steps[StepCount].url == tour.steps[StepCount + 1].url) //sigue en la misma url
            {
                return true;
            }
            else
            {
                return false; //el próximo paso cambia de url
            }
        }

        private bool ValidateBackButton()
        {
            if (StepCount == 0) //es el último paso
            {
                isLastStepInUrl = false;
            }
            else if (tour.steps[StepCount].url == tour.steps[StepCount - 1].url) //sigue en la misma url
            {
                isLastStepInUrl = true;
            }
            else
            {
                isLastStepInUrl = false; //el próximo paso cambia de url
            }
            return isLastStepInUrl;
        }

        private void playStepInTheSameUrl(Tour tour, int positionStep)
        {
            var step = tour.steps.Find(s => s.order == positionStep);
            var audioPath = "";

            if (step.audio != null)
                audioPath = Constants.audioPath + "/Audio " + tour._id + step._id + ".wav";
           
            NavigatorAdult form = this.Parent as NavigatorAdult;
            var doc = form.initDocument(step, positionStep);
            doc.InvokeScript("init" + step.order);

            form.playAudio(audioPath);
            form.countLoad = positionStep + 1;
        }

        private void Center_With(Label label, AsistimeRoundButton button)
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
    }
}
