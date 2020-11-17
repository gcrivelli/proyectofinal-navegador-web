using Bunifu.Framework.UI;
using NavegadorWeb.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeTourCard : BunifuCards
    {
        Tour tourAsociado;
        public AsistimeTourCard(Tour tour, int x, int y)
        {
            color = Color.Transparent;
            BorderRadius = 10;
            BackColor = ColorTranslator.FromHtml(Constants.TourCardBackground);

            //Título
            Label title = new Label();
            title.AutoSize = true;
            title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title.Location = new System.Drawing.Point(12, 16);
            title.Width = Constants.TourCardWidth - 20;
            title.TabIndex = 1;
            title.Text = tour.name;

            //Descripción
            Label description = new Label();
            description.Location = new System.Drawing.Point(12, 59);
            description.Width = Constants.TourCardWidth - 20;
            description.Height = Constants.TourCardHeigth / 2;
            description.TabIndex = 2;
            description.Text = tour.description;

            //Botón de realizar tour
            AsistimeActionButton button = new AsistimeActionButton();
            button.TabIndex = 0;
            button.ButtonText = "Realizar Tour";
            button.Location = new Point(Constants.TourCardWidth - button.Width - 30, 
                Constants.TourCardHeigth - button.Height - 10);
            button.Click += new EventHandler(this.PlayTour);

            //Formato de la tarjeta
            Controls.Add(description);
            Controls.Add(title);
            Controls.Add(button);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = ColorTranslator.FromHtml(Constants.TourCardFontColour);
            Size = new System.Drawing.Size(Constants.TourCardWidth, Constants.TourCardHeigth);
            TabIndex = 0;
            TabStop = false;
            Location = new System.Drawing.Point(x,y);
            tourAsociado = tour;
        }

        private void PlayTour(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show(Constants.InitiateTourConfirmation1
                + tourAsociado.name + Constants.InitiateTourConfirmation2,
                Constants.InitiateTourTitle,
                MessageBoxButtons.YesNo);
            if(result1 == DialogResult.Yes)
            {
                AsistimeCardContainer parent = this.Parent as AsistimeCardContainer;
                parent.PlayTour(this.tourAsociado);
            }
        }
    }

    class AssistantTourCard : BunifuCards
    {
        public Tour tourAsociado;
        public AssistantTourCard(Tour tour, int x, int y)
        {
            color = Color.Transparent;
            BorderRadius = 10;
            BackColor = ColorTranslator.FromHtml(Constants.TourCardBackground);

            //Título
            Label title = new Label();
            title.AutoSize = true;
            title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title.Location = new System.Drawing.Point(12, 16);
            title.Width = Constants.TourCardWidth - 20;
            title.TabIndex = 1;
            title.Text = tour.name;

            //Descripción
            Label description = new Label();
            description.Location = new System.Drawing.Point(12, 59);
            description.Width = Constants.TourCardWidth - 20;
            description.Height = Constants.TourCardHeigth / 2;
            description.TabIndex = 2;
            description.Text = tour.description;

            //Botón de asignar tour
            AsistimeActionButton assignButton = new AsistimeActionButton();
            assignButton.TabIndex = 0;
            assignButton.ButtonText = "Asignar";
            assignButton.Location = new Point(30, Constants.TourCardHeigth - assignButton.Height - 10);
            assignButton.Click += new EventHandler(this.AssignTour);

            //Botón de realizar tour
            AsistimeActionButton button = new AsistimeActionButton();
            button.TabIndex = 0;
            button.ButtonText = "Realizar";
            button.Location = new Point(Constants.TourCardWidth - button.Width - 30,
                Constants.TourCardHeigth - button.Height - 10);
            button.Click += new EventHandler(this.PlayTour);

            //Formato de la tarjeta
            Controls.Add(description);
            Controls.Add(title);
            Controls.Add(assignButton);
            Controls.Add(button);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = ColorTranslator.FromHtml(Constants.TourCardFontColour);
            Size = new System.Drawing.Size(Constants.TourCardWidth, Constants.TourCardHeigth);
            TabIndex = 0;
            TabStop = false;
            Location = new System.Drawing.Point(x, y);
            tourAsociado = tour;
        }

        private void PlayTour(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show(Constants.InitiateTourConfirmation1
                + tourAsociado.name + Constants.InitiateTourConfirmation2,
                Constants.InitiateTourTitle,
                MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                AsistimeCardContainer parent = this.Parent as AsistimeCardContainer;
                parent.PlayTour(this.tourAsociado);
            }
        }

        private void AssignTour(object sender, EventArgs e)
        {
            AsistimeTourAssign assignTourView = new AsistimeTourAssign(this, tourAsociado);
            assignTourView.TopMost = true;
            assignTourView.Show();
        }
    }
}
