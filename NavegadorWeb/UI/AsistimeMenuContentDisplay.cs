using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeMenuContentDisplay : Form
    {
        public AsistimeMenuContentDisplay()
        {
            BackColor = ColorTranslator.FromHtml(Constants.CardContainerBackground);
            Width = 1515;
            Height = 1024;
        }

        public void ReSize(int new_width, int new_height)
        {
            this.Height = new_height;
            this.Width = new_width;
            this.Dock = DockStyle.Right;
        }
    }
}
