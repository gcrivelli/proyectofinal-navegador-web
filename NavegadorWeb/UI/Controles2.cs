using NavegadorWeb.Adult;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public partial class Controles2 : Form
    {
        public NavigatorForm PreviousForm;
        private AsistimeMenuPanel asistimeMenuPanel;
        private AsistimeCardContainer asistimeCardContainer;
        public Controles2()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            asistimeMenuPanel = new AsistimeMenuPanel(this) { Parent = this };
            asistimeMenuPanel.Location = new System.Drawing.Point(0, 0);
            asistimeCardContainer = new AsistimeCardContainer() { Parent = this };
            asistimeCardContainer.Location = new System.Drawing.Point(Constants.MenuWidth, 0);
            this.Controls.Add(asistimeMenuPanel);
            this.Controls.Add(asistimeCardContainer);

            asistimeCardContainer.Hide();

        }

        private void Controles2_Load(object sender, EventArgs e)
        {
            
        }


        public void ActiveMenu(object sender)
        {
            AsistimeMenuButton botonActivo = sender as AsistimeMenuButton;

            switch (botonActivo.Text)
            {
                case Constants.profileMenuButton:
                    asistimeCardContainer.Hide();
                    break;
                case Constants.newToursMenuButton:
                    asistimeCardContainer.Hide();
                    break;
                case Constants.myToursMenuButton:
                    asistimeCardContainer.Show();
                    break;
                case Constants.backMenuButton:
                    this.Hide();
                    PreviousForm.Show();
                    break;
            }
        }

        private void Controles2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void ShowProfile()
        {

        }

        public void ShowNewTours()
        {

        }

        public void ShowMyTours()
        {

        }

        public void ReturnToNavigation()
        {
            this.Hide();
            PreviousForm.Show();
        }

    }
}
