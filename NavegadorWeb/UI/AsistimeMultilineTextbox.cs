using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeMultilineTextbox : Control
    {
        public AsistimeMultilineTextbox()
        {
            AsistimeSearchBox box = new AsistimeSearchBox();
            box.Width = 400;
            box.Height = 300;
            this.Controls.Add(box);
            box.BringToFront();

            TextBox textbox = new TextBox();
            textbox.Multiline = true;
            textbox.Width = 380; //20 menos que el ancho del searchbox
            textbox.Height = 280; //20 menos que la altura del searchbox
            textbox.Location = new Point(10, 10);
            this.Controls.Add(textbox);
            textbox.BorderStyle = BorderStyle.None;
            textbox.Font = Constants.TextBoxFont;
            textbox.BringToFront();
        }
    }
}
