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
                double progressDouble = ((double)StepCount / (double)tour.steps.Count) * 100;
                int progress = (int)Math.Truncate(progressDouble);
                progressBar.Value = progress;
                NavigatorAdult form = this.Parent as NavigatorAdult;
                form.playStep(tour, StepCount);
                StepForwardButton.Enabled = true;
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
            NavigatorAdult form = this.Parent as NavigatorAdult;
            form.playStep(tour, StepCount);
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
                double progressDouble = ((double)StepCount / (double)tour.steps.Count) * 100;
                int progress = (int)Math.Truncate(progressDouble);
                progressBar.Value = progress;
                NavigatorAdult form = this.Parent as NavigatorAdult;
                form.playStep(tour, StepCount);
                StepBackButton.Enabled = true;
            }

            if (StepCount == tour.steps.Count - 1)
                StepForwardButton.Enabled = false;
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
        }
    }
}
