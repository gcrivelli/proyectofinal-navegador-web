using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public class AsistimeContentPanel : Panel
    {
        public AsistimeContentPanel()
        {
            BackColor = ColorTranslator.FromHtml(Constants.ContentPanelBackground);
            Location = new Point(Constants.MenuWidth, 0);
            Width = 1920 - Constants.MenuWidth;
            Height = 1024;
            AutoScroll = true;
        }

        public void ShowControl(Control control)
        {
            foreach (Control X in this.Controls)
            {
                X.Hide();
            }

            control.Show();
        }
    }
}
