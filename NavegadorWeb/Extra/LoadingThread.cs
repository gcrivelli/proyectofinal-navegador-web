using NavegadorWeb.GeneralDisplay;
using System.Windows.Forms;

namespace NavegadorWeb.Extra
{
    public class LoadingThread
    {
        public static LoadingForm loadingForm;
        public static void ShowLoading()
        {
            loadingForm = new LoadingForm();
            Program.asistimeLogin.Invoke((MethodInvoker)delegate ()
            {
                loadingForm.Show();
            });
        }

        public static void CloseLoading()
        {
            loadingForm.Close();
        }
    }
}
