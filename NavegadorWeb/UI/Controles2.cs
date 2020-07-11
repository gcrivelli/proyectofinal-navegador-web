using System;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public partial class Controles2 : Form
    {
        private AsistimeMenuPanel asistimeMenuPanel;
        private AsistimeCardContainer asistimeCardContainer;
        public Controles2()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            asistimeMenuPanel = new AsistimeMenuPanel(this);
            asistimeMenuPanel.Location = new System.Drawing.Point(0, 0);
            asistimeCardContainer = new AsistimeCardContainer();
            asistimeCardContainer.Location = new System.Drawing.Point(Constants.MenuWidth, 0);
            this.Controls.Add(asistimeMenuPanel);
            this.Controls.Add(asistimeCardContainer);

            asistimeCardContainer.Hide();

        }

        private void Controles2_Load(object sender, EventArgs e)
        {
            //asistimeCardContainer1.ReSize(this.Width - asistimeMenuPanel1.Width - 16, this.Height);
            //profileMenuButton.AsistimeMenuButton_load("Mi Perfil");
        }

        /*protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            asistimeCardContainer1.ReSize(this.Width - asistimeMenuPanel1.Width - 16, this.Height);
        }

        private void profileMenuButton_Click(object sender, EventArgs e)
        {
            profileMenuButton.Activate();
            asistimeCardContainer1.Show();
        }

        private void myToursMenuButton_Click(object sender, EventArgs e)
        {
            profileMenuButton.DeActivate();
            asistimeCardContainer1.Hide();
        }*/

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
            }
        }


    }
}
