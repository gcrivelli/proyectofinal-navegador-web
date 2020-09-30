using NavegadorWeb.Adult;
using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Responsable;
using NavegadorWeb.UI;
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
            //Application.Run(new NavigatorAdult());
            Application.Run(new AsistimeTourCreation());
            //Application.Run(new NavigatorAssistant());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
