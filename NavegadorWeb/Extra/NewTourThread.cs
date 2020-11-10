using NavegadorWeb.Controller;
using NavegadorWeb.UI;
using System.Threading;

namespace NavegadorWeb.Extra
{
    public class NewTourThread
    {

        public static void DoWork()
        {
            while (true)
            {
                Thread.Sleep(60000);

                var notificationController = new NotificationController();
                var notificacion = notificationController.GetNotification().Result;
                if (notificacion.Count > 0)
                {
                    var userController = new UserController();
                    var tourController = new TourController();

                    Constants.user = userController.GetUser().Result;
                    Constants.tours = tourController.GetAllToursAsync().Result;
                }
            }
        }
    }
}
