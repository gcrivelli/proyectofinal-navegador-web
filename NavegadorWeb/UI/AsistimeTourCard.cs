using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavegadorWeb.UI
{
    class AsistimeTourCard : GroupBox
    {
        int count = 1;
        public AsistimeTourCard()
        {
            //Título
            Label title = new Label();
            title.AutoSize = true;
            title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title.Location = new System.Drawing.Point(12, 16);
            title.Name = "title" + count;
            title.Size = new System.Drawing.Size(109, 16);
            title.TabIndex = 1;
            title.Text = "Titulo del Tour";

            //Descripción
            Label description = new Label();
            description.Location = new System.Drawing.Point(12, 59);
            description.Name = "label" + count;
            description.Size = new System.Drawing.Size(182, 72);
            description.TabIndex = 2;
            description.Text = "Aca va toda la informacion respecto del tutorial, como la url, cantidad de pasos," +
                                " veces que lo vimos, entre otras cosas";

            //Botón de realizar tour
            Button button = new Button();
            button.BackColor = System.Drawing.Color.Honeydew;
            button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            button.Location = new System.Drawing.Point(113, 134);
            button.Name = "button" + count;
            button.Size = new System.Drawing.Size(75, 23);
            button.TabIndex = 0;
            button.Text = "Ver";
            button.UseVisualStyleBackColor = false;

            //Formato de la tarjeta
            BackColor = System.Drawing.Color.SeaGreen;
            Controls.Add(description);
            Controls.Add(title);
            Controls.Add(button);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            Location = new System.Drawing.Point(53, 36);
            Name = "groupBox" + count;
            Size = new System.Drawing.Size(194, 166);
            TabIndex = 0;
            TabStop = false;
        }
    }
}
