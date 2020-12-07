using Bunifu.Framework.UI;
using NavegadorWeb.GeneralDisplay;
using NavegadorWeb.Controller;
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
            this.Width = Constants.TourCardWidth;

            //Título
            Label title = new Label();
            title.AutoSize = true;
            title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            AsistimeActionButton playButton = new AsistimeActionButton();
            playButton.TabIndex = 0;
            playButton.ButtonText = "Realizar Tour";
            //playButton.ReSize();
            //playButton.Location = new Point(Constants.TourCardWidth - playButton.Width - 30, 
            //Constants.TourCardHeigth - playButton.Height - 10);
            int playButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(playButton.ButtonText, playButton.Font);
                size.Width += 40;
                playButtonWidth = (int)size.Width;
            }
            playButton.Location = new Point(Constants.TourCardWidth - playButtonWidth - 10, Constants.TourCardHeigth - playButton.Height - 10);
            playButton.Click += new EventHandler(this.PlayTour);

            //Formato de la tarjeta
            Controls.Add(description);
            Controls.Add(title);
            Controls.Add(playButton);
            Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = ColorTranslator.FromHtml(Constants.TourCardFontColour);
            Size = new System.Drawing.Size(Constants.TourCardWidth, Constants.TourCardHeigth);
            TabIndex = 0;
            TabStop = false;
            Location = new System.Drawing.Point(x,y);
            tourAsociado = tour;
        }

        private void PlayTour(object sender, EventArgs e)
        {
            MenuForm2 parent = this.Parent as MenuForm2;
            parent.PlayTour(this.tourAsociado);
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
            title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            //assignButton.ReSize();
            //assignButton.Location = new Point(30, Constants.TourCardHeigth - assignButton.Height - 10);
            int assignyButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(assignButton.ButtonText, assignButton.Font);
                size.Width += 40;
                assignyButtonWidth = (int)size.Width;
            }
            assignButton.Location = new Point(10, Constants.TourCardHeigth - assignButton.Height - 10);
            assignButton.Click += new EventHandler(this.AssignTour);

            //Botón de borrar tour
            AsistimeActionButton deleteButton = new AsistimeActionButton();
            deleteButton.TabIndex = 0;
            deleteButton.ButtonText = "Borrar";
            //assignButton.ReSize();
            //assignButton.Location = new Point(30, Constants.TourCardHeigth - assignButton.Height - 10);
            int deleteButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(deleteButton.ButtonText, deleteButton.Font);
                size.Width += 40;
                deleteButtonWidth = (int)size.Width;
            }
            deleteButton.Location = new Point(145, Constants.TourCardHeigth - deleteButton.Height - 10);
            deleteButton.Click += new EventHandler(this.DeleteTour);

            //Botón de realizar tour
            AsistimeActionButton playButton = new AsistimeActionButton();
            playButton.TabIndex = 0;
            playButton.ButtonText = "Realizar";
            //playButton.ReSize();
            //playButton.Location = new Point(Constants.TourCardWidth - playButton.Width - 30, 
            //Constants.TourCardHeigth - playButton.Height - 10);
            int playButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(playButton.ButtonText, playButton.Font);
                size.Width += 40;
                playButtonWidth = (int)size.Width;
            }
            playButton.Location = new Point(Constants.TourCardWidth - playButtonWidth - 10, Constants.TourCardHeigth - playButton.Height - 10);
            playButton.Click += new EventHandler(this.PlayTour);

            //Formato de la tarjeta
            Controls.Add(description);
            Controls.Add(title);
            Controls.Add(assignButton);
            Controls.Add(deleteButton);
            Controls.Add(playButton);
            Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                MenuForm2 parent = this.Parent as MenuForm2;
                parent.PlayTour(this.tourAsociado);
            }
        }

        private void AssignTour(object sender, EventArgs e)
        {
            AsistimeTourAssign assignTourView = new AsistimeTourAssign(this, tourAsociado);
            assignTourView.TopMost = true;
            assignTourView.Show();
        }

        async private void DeleteTour(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show(Constants.DeleteTourConfirmation1
                + tourAsociado.name + Constants.DeleteTourConfirmation2,
                Constants.DeleteTourTitle,
                MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                var tourController = new TourController();
                var result = await tourController.DeleteTourAsync(this.tourAsociado._id);
                this.Hide();

            }
        }
    }
}
