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
        private int StepCount;
        public bool isLastStepInUrl;

        public AsistimeTourBar()
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Height = Constants.AppBarHeight;
            Width = Constants.AppBarWidth;

            progressBar = new AsistimeTourProgressBar();
            this.Controls.Add(progressBar);


            this.Controls.Add(this.GetStepBackButton((this.Width / 2) - 39 - 150, 35));
            this.Controls.Add(this.GetPlayButton((this.Width / 2) - 39, 35));
            this.Controls.Add(this.GetStepForwardButton((this.Width / 2) + 39 + 72, 35));
            this.Controls.Add(this.GetCloseTourButton(this.ClientSize.Width - 150, 35));
            StepBackButton.Enabled = false;
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
                StepBackButton = new AsistimeRoundButton(78, 78, Constants.StepBackImage, Constants.StepBackImage, Constants.StepBackClickImage) { Parent = this.Parent };
                StepBackButton.Location = new Point(x, y);
            }
            StepBackButton.Click += new EventHandler(this.GoOneStepBack);
            return StepBackButton;
        }

        protected void GoOneStepBack(object sender, EventArgs e)
        {
            if (StepCount > 0)
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
                PlayButton = new AsistimeRoundButton(78, 78, Constants.StepPlayImage, Constants.StepPlayImage, Constants.StepPlayClickImage) { Parent = this.Parent };
                PlayButton.Location = new Point(x, y);
            }
            PlayButton.Click += new EventHandler(this.PlayStep);
            return PlayButton;
        }

        protected void PlayStep(object sender, EventArgs e)
        {
            playStepInTheSameUrl(tour, StepCount);
        }

        protected Control GetStepForwardButton(int x, int y)
        {
            if (StepForwardButton == null)
            {
                StepForwardButton = new AsistimeRoundButton(78, 78, Constants.StepForwardImage, Constants.StepForwardImage, Constants.StepForwardClickImage) { Parent = this.Parent };
                StepForwardButton.Location = new Point(x, y);
            }
            StepForwardButton.Click += new EventHandler(this.GoOneStepForward);
            return StepForwardButton;
        }

        protected void GoOneStepForward(object sender, EventArgs e)
        {
            if (StepCount < tour.steps.Count)
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
                CloseTourButton = new AsistimeRoundButton(78, 78, Constants.CloseTourImage, Constants.CloseTourImage, Constants.CloseTourImage) { Parent = this.Parent };
                CloseTourButton.Location = new Point(x, y);
            }
            CloseTourButton.Click += new EventHandler(this.CloseTour);
            return CloseTourButton;
        }

        protected void CloseTour(object sender, EventArgs e)
        {
            NavigatorAdult form = this.Parent as NavigatorAdult;
            form.CloseTour();
        }

        public void TourInititated(Tour tour)
        {
            StepCount = 0;
            this.tour = tour;
            this.SetStep(StepCount);
            ConfirmationMessage m = new ConfirmationMessage("Iniciaste el tour!");
            m.Location = new System.Drawing.Point(Constants.AppBarWidth - 410, Constants.AppBarHeight + 50);
            m.Show();
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
                isLastStepInUrl = true; //el próximo paso cambia de url
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
            form.countLoad = positionStep;
        }
    }
}
