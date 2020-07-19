using NavegadorWeb.Adult;
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
        public AsistimeTourBar()
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Height = Constants.AppBarHeight;
            Width = Constants.AppBarWidth;

            
            this.Controls.Add(this.GetStepBackButton((this.Width / 2) - 39 - 150, 35));
            this.Controls.Add(this.GetPlayButton((this.Width / 2) - 39, 35));
            this.Controls.Add(this.GetStepForwardButton((this.Width / 2) + 39 + 72, 35));
            this.Controls.Add(this.GetCloseTourButton(this.ClientSize.Width - 150, 35));
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
    }
}
