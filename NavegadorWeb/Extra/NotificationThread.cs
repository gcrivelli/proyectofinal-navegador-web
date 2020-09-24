using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace NavegadorWeb.Extra
{
    public class NotificationThread
    {

        public static void DoWork()
        {
            while (true)
            {
                notification();
                Thread.Sleep(450000);
            }
        }

        private static void notification()
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Asistime!!";
            popup.TitlePadding = new Padding(50, 20, 20, 20);
            popup.TitleFont = new Font("Arial", 26);
            popup.ContentText = "Notificacion";
            popup.ContentFont = new Font("Arial", 13);
            popup.ContentPadding = new Padding(50, 0, 20, 20);

            popup.ShowCloseButton = true;
            popup.ShowOptionsButton = true;
            popup.Delay = 5000;
            popup.Size = new Size(300, 200);
            popup.Popup();
        }
    }
}
