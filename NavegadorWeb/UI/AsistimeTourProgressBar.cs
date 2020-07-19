using Bunifu.Framework.UI;
using System.Drawing;

namespace NavegadorWeb.UI
{
    public class AsistimeTourProgressBar : BunifuCircleProgressbar
    {
        public AsistimeTourProgressBar()
        {
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Location = new Point(20, 20);
            Height = 200;
            Width = 200;
            Font = Constants.ProgressBarFont;
            ProgressColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
        }
    }
}
