using NavegadorWeb.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.Responsable
{
    public partial class NavigatorAssistant : NavigatorForm
    {
        AsistimeTourBar tourBar;
        //private Tour tourLoad;
        public int countLoad;
        private string actualURL, lastCorrectURL;
        private int posActual;
        private bool volverAPasoCorrecto;

        public NavigatorAssistant()
        {
            InitializeComponent();
            asistimeAppBar = new AssistantAppBar() { Parent = this };
            asistimeAppBar.Width = this.Width;
            this.Controls.Add(asistimeAppBar);
        }
    }
}
