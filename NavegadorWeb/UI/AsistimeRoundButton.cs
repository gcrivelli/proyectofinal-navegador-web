using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace NavegadorWeb.UI
{
    public class AsistimeRoundButton : Button
    {
        private Image normalImage;
        private Image hoverImage;
        private Image clickImage;
        public AsistimeRoundButton(int width, int height, Image image, Image hoverImage, Image clickImage)
        {
            this.Width = width;
            this.Height = height;
            this.Image = image;
            this.FlatAppearance.BorderColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            this.BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            this.ForeColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackgroundImageLayout = ImageLayout.Center;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.UseVisualStyleBackColor = false;
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new System.Drawing.Region(grPath);

            this.normalImage = image;
            this.hoverImage = hoverImage;
            this.clickImage = clickImage;

        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.Image = this.hoverImage;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Image = normalImage;
            base.OnMouseLeave(e);
        }

        protected override void OnClick(EventArgs e)
        {
            this.Image = this.clickImage;
            base.OnClick(e);
        }

    }

}
