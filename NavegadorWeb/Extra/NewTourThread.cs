using NavegadorWeb.Controller;
using NavegadorWeb.UI;
using System.Threading;
using System.Windows;

namespace NavegadorWeb.Extra
{
    public class NewTourThread
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
                    var userController = new UserController();
                    var tourController = new TourController();

                    Constants.user = userController.GetUser().Result;
                    Constants.tours = tourController.GetAllToursAsync().Result;
                    MessageBox.Show("Tenes un nuevo tour disponible.","Nuevo Tour", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
