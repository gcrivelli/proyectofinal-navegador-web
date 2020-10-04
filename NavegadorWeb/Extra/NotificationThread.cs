using NavegadorWeb.Controller;
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
                var notificationController = new NotificationController();
                var notificacion = notificationController.GetNotification().Result;
                if (notificacion.Count > 0)
                {
                    notificacion.ForEach(n =>
                    {
                        var popup = new PopupNotification(n.evento, n.message);
                        MessageBox.Show("");
                    });
                }
                Thread.Sleep(45000);
            }
        }
    }
}
