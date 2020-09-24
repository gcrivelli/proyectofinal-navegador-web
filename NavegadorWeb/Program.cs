using NavegadorWeb.Extra;
using NavegadorWeb.GeneralDisplay;
using System;
using System.Threading;
using System.Windows.Forms;

namespace NavegadorWeb
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major == 6)
                SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Active notifications 
            Thread threadNotification = new Thread(NotificationThread.DoWork);
            threadNotification.IsBackground = true;
            threadNotification.Start();

            Application.Run(new AsistimeLogin());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
