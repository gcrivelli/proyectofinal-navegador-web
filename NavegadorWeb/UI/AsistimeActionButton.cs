using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    public class AsistimeActionButton : BunifuThinButton2
    {
        public AsistimeActionButton()
        {
            this.BackgroundImage = null;            
            this.Height = Constants.ActionButtonHeight;
            this.IdleCornerRadius = Constants.ActionButtonCornerRadius;
            this.ActiveCornerRadius = Constants.ActionButtonCornerRadius;

            //this.IdleLineColor = this.ActiveLineColor;
            this.BackColor = Color.Transparent;
            this.ForeColor = ColorTranslator.FromHtml(Constants.ActionButtonForeColor);
            this.ActiveForecolor = ColorTranslator.FromHtml(Constants.ActionButtonForeColor);
            this.IdleForecolor = ColorTranslator.FromHtml(Constants.ActionButtonForeColor);
            this.ActiveFillColor = ColorTranslator.FromHtml(Constants.ActionButtonHoverFillColor);
            this.IdleFillColor = ColorTranslator.FromHtml(Constants.ActionButtonFillColor);
            this.IdleLineColor = ColorTranslator.FromHtml(Constants.ActionButtonFillColor);
            this.ActiveLineColor = ColorTranslator.FromHtml(Constants.ActionButtonHoverFillColor);
            this.ReSize();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(this.ButtonText, this.Font);
                size.Width += 40;
                Width = (int)size.Width;
            }
            base.OnPaint(e);
        }

        public void ReSize()
        {
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(this.ButtonText, this.Font);
                size.Width += 40;
                Width = (int)size.Width;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
        }
    }

}
