using Bunifu.Framework.UI;
using JMetroTextBox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace NavegadorWeb.UI
{
    class AsistimeSearchBox : JMetroTextBox.JMetroTextBox //BunifuMetroTextbox
    {
        
        public AsistimeSearchBox()
        {
            this.BorderRadius = Constants.SearchBoxCornerRadius;
            this.Height = Constants.SearchBoxButtonHeight;
            this.Width = 700;
        }
    }
}
