using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NavegadorWeb.UI
{
    public partial class AsistimeModalForm : Form
    {
        protected int initControlsHeight = 350;
        protected int spaceBetweenTextBoxes = 150;
        protected int spaceBeforeTextBox = 30;
        protected int spaceBeforeActionButtons = 100;
        protected int spaceBetweeActionButtons = 100;
        protected int spaceAfterControls = 150;

        public AsistimeModalForm()
        {

            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            this.AllowTransparency = true;
            this.BackColor = Color.White;

            this.Width = 700;
            this.Height = 900;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            AsistimeRoundButton exitButton = new AsistimeRoundButton(44, 44, Constants.CloseImage, Constants.CloseHoverImage, Constants.CloseClickedImage) { Parent = this.Parent };
            exitButton.Location = new Point(this.Width - 56, 10);
            exitButton.Click += new EventHandler(Exit);
            this.Controls.Add(exitButton);

            PictureBox logo = new PictureBox();
            logo.Image = Constants.AsistimeLogo; ;
            this.Controls.Add(logo);
            logo.Width = 500;
            logo.Height = 200;
            logo.Location = new Point(101, 70);
            logo.BringToFront();
            
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        protected extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        protected extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        protected void AsistimeModalForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        protected static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        protected void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected void FinalizeLoading()
        {
            this.Width = 700;
            this.Height += spaceAfterControls;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}
