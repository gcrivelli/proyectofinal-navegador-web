using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Threading;

namespace NavegadorWeb.UI
{
    class AsistimeRoundButton : Button
    {
        private string normalImage;
        private string hoverImage;
        private string clickImage;
        public AsistimeRoundButton(int width, int height, string image, string hoverImage, string clickImage)
        {
            this.Width = width;
            this.Height = height;
            this.Image = Image.FromFile(image);
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
            this.Image = Image.FromFile(this.hoverImage);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Image = Image.FromFile(this.normalImage);
            base.OnMouseLeave(e);
        }

        protected override void OnClick(EventArgs e)
        {
            this.Image = Image.FromFile(this.clickImage);
            base.OnClick(e);
        }


    }


    public sealed class NavButtons : Control
    {
        private static AsistimeRoundButton NavBackButton = null;
        private static AsistimeRoundButton NavRefreshButton = null;
        private static AsistimeRoundButton NavForwardButton = null;
        private static AsistimeRoundButton NavProfileButton = null;
        public Control GetNavBackButton(int x, int y)
        {
            if (NavBackButton == null)
            {
                NavBackButton = new AsistimeRoundButton(98, 98, Constants.NavBackImage, Constants.NavBackHoverImage, Constants.NavBackClickedImage) { Parent = this.Parent };
                NavBackButton.Location = new Point(x, y);
            }
            return NavBackButton;
        }

        public Control GetNavRefreshButton(int x, int y)
        {
            if (NavRefreshButton == null)
            {
                NavRefreshButton = new AsistimeRoundButton(128, 128, Constants.NavRefreshImage, Constants.NavRefreshHoverImage, Constants.NavRefreshClickedImage) { Parent = this.Parent };
                NavRefreshButton.Location = new Point(x, y);
            }
            return NavRefreshButton;
        }

        public Control GetNavForwardButton(int x, int y)
        {
            if (NavForwardButton == null)
            {
                NavForwardButton = new AsistimeRoundButton(98, 98, Constants.NavForwardImage, Constants.NavForwardHoverImage, Constants.NavForwardClickedImage) { Parent = this.Parent };
                NavForwardButton.Location = new Point(x, y);
            }
            return NavForwardButton;
        }

        public Control GetNavProfileButton(int x, int y)
        {
            if (NavProfileButton == null)
            {
                NavProfileButton = new AsistimeRoundButton(128, 128, Constants.NavProfileImage, Constants.NavProfileHoverImage, Constants.NavProfileClickedImage) {Parent = this.Parent };
                NavProfileButton.Location = new Point(x, y);
            }
            return NavProfileButton;
        }

        public void BringFrontRefreshButton()
        {
            NavRefreshButton.BringToFront();
        }
    }


}
