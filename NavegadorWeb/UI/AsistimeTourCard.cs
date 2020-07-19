using Bunifu.Framework.UI;
using NavegadorWeb.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeTourCard : BunifuCards
    {
        public int count = 1;
        Tour tourAsociado;
        public AsistimeTourCard(Tour tour, int x, int y)
        {
            color = Color.Transparent;
            BorderRadius = 10;
            BackColor = ColorTranslator.FromHtml(Constants.AppPrimaryColour);

            //Título
            Label title = new Label();
            title.AutoSize = true;
            title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title.Location = new System.Drawing.Point(12, 16);
            //title.Name = "TourTitle" + count;
            title.Size = new System.Drawing.Size(109, 16);
            title.TabIndex = 1;
            title.Text = tour.name;

            //Descripción
            Label description = new Label();
            description.Location = new System.Drawing.Point(12, 59);
            //description.Name = "label" + count;
            description.Size = new System.Drawing.Size(182, 72);
            description.TabIndex = 2;
            description.Text = tour.description;

            //Botón de realizar tour
            AsistimeActionButton button = new AsistimeActionButton();
            //button.BackColor = Color.White;
            //button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            button.Location = new System.Drawing.Point(113, 134);
            //button.Name = "button" + count;
            //button.Size = new System.Drawing.Size(75, 23);
            button.TabIndex = 0;
            //button.Text = "Realizar Tour";
            button.ButtonText = "Realizar Tour";
            //button.UseVisualStyleBackColor = false;
            button.Click += new EventHandler(this.PlayTour);

            //Formato de la tarjeta
            //BackColor = System.Drawing.Color.SeaGreen;
            Controls.Add(description);
            Controls.Add(title);
            Controls.Add(button);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            Location = new System.Drawing.Point(53, 36);
            //Name = "groupBox" + count;
            Size = new System.Drawing.Size(400, 300);
            TabIndex = 0;
            TabStop = false;
            Location = new System.Drawing.Point(x,y);
            tourAsociado = tour;
        }

        private void PlayTour(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Tas seguro?",
                                                    "Important Question",
                                                    MessageBoxButtons.YesNo);
            if(result1 == DialogResult.Yes)
            {
                AsistimeCardContainer parent = this.Parent as AsistimeCardContainer;
                //Controles2 parent = this.Parent as Controles2;
                parent.PlayTour(this.tourAsociado);
            }
        }
    }
}
