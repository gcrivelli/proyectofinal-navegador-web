using NavegadorWeb.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.Responsable
{
    class AssistantAppBar : AsistimeAppBar
    {
        public static AsistimeRoundButton AddTourButton = null;

        public AssistantAppBar()
        {
            this.Controls.Add(this.GetAddTourButton(this.ClientSize.Width - 300, 15));

            Label addTourLabel = new Label() { Text = "Crear tour", ForeColor = Color.White, Font = Constants.H1LabelFont, Height = 40 };
            Center_With(addTourLabel, AddTourButton);
            this.Controls.Add(addTourLabel);
        }

        protected Control GetAddTourButton(int x, int y)
        {
            if (AddTourButton == null)
            {
                AddTourButton = new AsistimeRoundButton(98, 98, Constants.AddTourImage, Constants.AddTourHoverImage, Constants.AddTourClickImage) { Parent = this.Parent };
                AddTourButton.Location = new Point(x, y);
            }
            AddTourButton.Click += new EventHandler(this.AddTour);
            return AddTourButton;
        }

        protected void AddTour(object sender, EventArgs e)
        {
            NavigatorAssistant control = this.Parent as NavigatorAssistant;
            control.AddTour();
        }
    }
}
