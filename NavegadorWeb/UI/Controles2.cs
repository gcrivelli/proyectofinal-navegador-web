using NavegadorWeb.Controller;
using NavegadorWeb.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public partial class Controles2 : Form
    {
        public NavigatorForm PreviousForm;
        private AsistimeMenuPanel asistimeMenuPanel;
        private AsistimeCardContainer asistimeCardContainer;

        protected User user;
        public Controles2(User user)
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            WindowState = FormWindowState.Maximized;

            asistimeMenuPanel = new AsistimeMenuPanel(this) { Parent = this };
            asistimeMenuPanel.Location = new System.Drawing.Point(0, 0);
            asistimeCardContainer = new AsistimeCardContainer(user.tours) { Parent = this };
            asistimeCardContainer.Location = new System.Drawing.Point(Constants.MenuWidth, 0);
            this.Controls.Add(asistimeMenuPanel);
            this.Controls.Add(asistimeCardContainer);

            asistimeCardContainer.Hide();

            this.user = user;

            InitializeComponent();
        }

        private void Controles2_Load(object sender, EventArgs e)
        {
            /*var tourController = new TourController();
            user = await tourController.GetAllToursAsync("5f0907dd5d988f31d515dc72");
            int count = user.tours.Count;
            MessageBox.Show("cantidad de tours: " + count);
            asistimeCardContainer.AddCards(user.tours);*/
        }

        /*private async Task<User> GetUserInfo()
        {
            var tourController = new TourController();
            user = await tourController.GetAllToursAsync("5f0907dd5d988f31d515dc72");
            return user;
        }*/

        /*public void ActiveMenu(object sender)
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
        }*/

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
            asistimeCardContainer.Show();
        }

        public void ReturnToNavigation()
        {
            this.Hide();
            PreviousForm.Show();
        }

        public void PlayTour(Tour tour)
        {
            this.Hide();
            //PreviousForm.PlayTour(tour);
        }

    }
}
