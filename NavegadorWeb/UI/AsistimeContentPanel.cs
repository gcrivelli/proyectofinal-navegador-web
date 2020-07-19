using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public class AsistimeContentPanel : Panel
    {
        public AsistimeContentPanel()
        {
            BackColor = ColorTranslator.FromHtml(Constants.CardContainerBackground);
            //ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Width = 1515;
            Height = 1024;
        }
    }
}
