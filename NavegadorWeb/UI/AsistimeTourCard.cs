﻿using Bunifu.Framework.UI;
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
            BorderRadius = 20;

            if (tour.viewFlag)
            {
                BackColor = ColorTranslator.FromHtml(Constants.TourCardNew);
                PictureBox newImage = new PictureBox();
                newImage.Image = Constants.NewImage;
                this.Controls.Add(newImage);
                newImage.Width = 100;
                newImage.Height = 40;
                newImage.Location = new Point(Constants.TourCardWidth-100, 0);
                newImage.BringToFront();
            }
            else
            {
                BackColor = ColorTranslator.FromHtml(Constants.TourCardBackground);
            }

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
            tourAsociado.viewFlag = false;
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
            BorderRadius = 20;
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
            int assignButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(assignButton.ButtonText, assignButton.Font);
                size.Width += 40;
                assignButtonWidth = (int)size.Width;
            }
            //assignButton.Location = new Point(10, Constants.TourCardHeigth - assignButton.Height - 10);
            assignButton.Click += new EventHandler(this.AssignTour);
            assignButton.Location = new Point(Constants.TourCardWidth - assignButtonWidth - 10, Constants.TourCardHeigth - assignButton.Height - 10);

            //Botón de borrar tour
            AsistimeRoundButton exitButton = new AsistimeRoundButton(44, 44, Constants.DestroyImage, Constants.DestroyHoverImage, Constants.DestroyClickedImage) { Parent = this.Parent };
            exitButton.Location = new Point(Constants.TourCardWidth - 56, 10);
            exitButton.Click += new EventHandler(DeleteTour);
            this.Controls.Add(exitButton);

            //Botón de realizar tour
            /*AsistimeActionButton playButton = new AsistimeActionButton();
            playButton.TabIndex = 0;
            playButton.ButtonText = "Realizar";
            int playButtonWidth;
            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(playButton.ButtonText, playButton.Font);
                size.Width += 40;
                playButtonWidth = (int)size.Width;
            }
            playButton.Location = new Point(Constants.TourCardWidth - playButtonWidth - 10, Constants.TourCardHeigth - playButton.Height - 10);
            playButton.Click += new EventHandler(this.PlayTour);*/

            //Formato de la tarjeta
            Controls.Add(description);
            Controls.Add(title);
            Controls.Add(assignButton);
            //Controls.Add(playButton);
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
                Constants.tours = tourController.GetAllToursAsync().Result;
                this.Hide();
                MenuForm2 parent = this.Parent as MenuForm2;
                parent.ArrangeCardGrid();
            }
        }
    }
}
