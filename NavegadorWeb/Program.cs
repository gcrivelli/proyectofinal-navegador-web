using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Responsable;
using System;
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
            //Application.Run(new AsistimeLogin());
            Application.Run(new NavigatorAssistant());
            //Application.Run(new NavWebResponsable());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
