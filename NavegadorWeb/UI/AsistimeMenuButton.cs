using Bunifu.Framework.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeMenuButton : BunifuFlatButton
    {
        public bool Active;

        public AsistimeMenuButton (AsistimeMenuPanel parent, String text)
        {
            Active = false;
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            ForeColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Normalcolor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            Textcolor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            OnHovercolor = ColorTranslator.FromHtml(Constants.MenuButtonHover);
            OnHoverTextColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Activecolor = ColorTranslator.FromHtml(Constants.MenuButtonHover);
            Width = Constants.MenuWidth;
            Height = Constants.MenuButtonHeight;

            
            //Font = new Font(FontFamily.GenericSansSerif,12.0F, FontStyle.Bold);
            Parent = parent;
            Text = text;
            Click += new EventHandler(this.MenuButtonClick);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            //pevent.Graphics.FillRectangle(new SolidBrush(BackColor), 0, 0, this.Width, this.Height);
            
            //TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            //TextRenderer.DrawText(pevent.Graphics, Text, Font, new Point(this.Width + 3, this.Height / 2), ColorTranslator.FromHtml(Constants.AppSecondaryColour), flags);
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            if (!Active)
            {
                base.OnMouseEnter(e);
                base.BackColor = ColorTranslator.FromHtml(Constants.MenuButtonHover);
            }
                
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (!Active)
            {
                base.OnMouseLeave(e);
                BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.limage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rimage)).BeginInit();
            this.SuspendLayout();
            // 
            // AsistimeMenuButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.Name = "AsistimeMenuButton";
            ((System.ComponentModel.ISupportInitialize)(this.limage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rimage)).EndInit();
            this.ResumeLayout(false);

        }

        public void Activate()
        {
            Active = true;
            BackColor = ColorTranslator.FromHtml(Constants.MenuButtonSelected);
            Normalcolor = ColorTranslator.FromHtml(Constants.MenuButtonSelected);
            Textcolor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            OnHovercolor = ColorTranslator.FromHtml(Constants.MenuButtonSelected);
            OnHoverTextColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            Activecolor = ColorTranslator.FromHtml(Constants.MenuButtonSelected);
        }

        public void DeActivate()
        {
            Active = false;
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            Normalcolor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            Textcolor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            OnHovercolor = ColorTranslator.FromHtml(Constants.MenuButtonHover);
            OnHoverTextColor = ColorTranslator.FromHtml(Constants.AppSecondaryColour);
            Activecolor = ColorTranslator.FromHtml(Constants.MenuButtonHover);
        }

        public void MenuButtonClick(object sender, EventArgs e)
        {
            if (!Active)
            {
                AsistimeMenuPanel menupanel = this.Parent as AsistimeMenuPanel;
                menupanel.ActiveMenu(sender);
            }
        }

    }
}
