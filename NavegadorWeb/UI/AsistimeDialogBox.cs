using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public partial class AsistimeDialogBox : Form
    {
        Label lblMessage;
        Timer closeTime;
        public AsistimeDialogBox(String message)
        {
            FormBorderStyle = FormBorderStyle.None;
            Width = 400;
            Height = 100;

            lblMessage = new Label() { Text = message };
            closeTime = new Timer() { Interval = 1000 };
            Controls.Add(lblMessage);
            lblMessage.Height = 50;
            lblMessage.Width = this.Width - 20;
            lblMessage.Location = new System.Drawing.Point(10,this.Height/2-lblMessage.Height/2);
            lblMessage.BringToFront();
            
            Font = Constants.ProgressBarFont;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            Opacity = 0.7;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AsistimeDialogBox
            // 
            //this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "AsistimeDialogBox";
            this.Load += new System.EventHandler(this.AsistimeDialogBox_Load);
            this.ResumeLayout(false);
            this.StartPosition = FormStartPosition.Manual;
            this.closeTime.Tick += new System.EventHandler(this.AsistimeDialogBox_CloseTime);
            this.Click += new System.EventHandler(this.AsistimeDialogBox_CloseTime);

        }

        private void AsistimeDialogBox_Load(object sender, EventArgs e)
        {
            closeTime.Start();
        }

        private void AsistimeDialogBox_CloseTime(object sender, EventArgs e)
        {
            this.Dispose();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
    }

    public class ConfirmationMessage : AsistimeDialogBox
    {
        public ConfirmationMessage(String message) : base(message)
        {
            BackColor = Constants.ConfirmationMessageBackColor;
            ForeColor = Constants.ConfirmationMessageForeColor;
        }
    }

    public class WarningMessage : AsistimeDialogBox
    {
        public WarningMessage(String message) : base(message)
        {
            BackColor = Constants.WarningMessageBackColor;
            ForeColor = Constants.WarningMessageForeColor;
        }
    }

    public class ErrorMessage : AsistimeDialogBox
    {
        public ErrorMessage(String message) : base(message)
        {
            BackColor = Constants.ErrorMessageBackColor;
            ForeColor = Constants.ErrorMessageForeColor;
        }
    }
}
