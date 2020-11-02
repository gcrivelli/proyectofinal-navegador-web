using NavegadorWeb.Controller;
using System.Threading;
using System.Windows.Forms;

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
                        new PopupNotification(n.message, n.evento);
                        MessageBox.Show( n.message, n.evento, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                }

                Thread.Sleep(60000);
            }
        }
    }
}
