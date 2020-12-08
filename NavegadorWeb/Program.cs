using NavegadorWeb.GeneralDisplay;
using System;
using System.Windows.Forms;

namespace NavegadorWeb
{
    public static class Program
    {
        public static AsistimeLogin asistimeLogin;
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
            asistimeLogin = new AsistimeLogin();

            Application.Run(asistimeLogin);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
