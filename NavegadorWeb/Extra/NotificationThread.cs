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
                Thread.Sleep(30000);

                var notificationController = new NotificationController();
                var notificacion = notificationController.GetNotification().Result;
                if (notificacion.Count > 0)
                {
                    notificacion.ForEach(n =>
                    {
                        Program.asistimeLogin.Invoke((MethodInvoker)delegate ()
                        {
                            new PopupNotification( n.evento, n.message);
                        });
                      
                    });
                }
            }
        }
    }
}
