using System.Drawing;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace NavegadorWeb.Extra
{
    public class PopupNotification
    {
        public PopupNotification( string title, string body)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = title;
            popup.TitlePadding = new Padding(20, 20, 20, 20);
            popup.TitleFont = new Font("Gadugi", 20);
            popup.ContentText = body;
            popup.ContentFont = new Font("Gadugi", 13);
            popup.ContentPadding = new Padding(20, 0, 20, 20);

            popup.ShowCloseButton = true;
            popup.Delay = 5000;
            popup.Size = new Size(300, 180);
            popup.Popup();
        }
    }
}
