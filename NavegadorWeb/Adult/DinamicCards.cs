using System;
using System.Windows.Forms;

namespace NavegadorWeb.Adult
{
    public partial class DinamicCards : Form
    {
        int count = 1;
        public DinamicCards()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count++;
            //Create label
            Label label = new Label();
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.Location = new System.Drawing.Point(12, 16);
            label.Name = "label"+ count;
            label.Size = new System.Drawing.Size(109, 16);
            label.TabIndex = 1;
            label.Text = "Titulo del Tour";

            //Create label2
            Label label2 = new Label();
            label2.Location = new System.Drawing.Point(12, 59);
            label2.Name = "label" + count;
            label2.Size = new System.Drawing.Size(182, 72);
            label2.TabIndex = 2;
            label2.Text = "Aca va toda la informacion respecto del tutorial, como la url, cantidad de pasos," +
                                " veces que lo vimos, entre otras cosas";

            //Create Button
            Button button = new Button();
            button.BackColor = System.Drawing.Color.Honeydew;
            button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            button.Location = new System.Drawing.Point(113, 134);
            button.Name = "button"+ count;
            button.Size = new System.Drawing.Size(75, 23);
            button.TabIndex = 0;
            button.Text = "Ver";
            button.UseVisualStyleBackColor = false;

            //Create GroupBox
            GroupBox groupBox = new GroupBox();
            groupBox.BackColor = System.Drawing.Color.SeaGreen;
            groupBox.Controls.Add(label2);
            groupBox.Controls.Add(label);
            groupBox.Controls.Add(button);
            groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            groupBox.Location = new System.Drawing.Point(53, 36);
            groupBox.Name = "groupBox" + count;
            groupBox.Size = new System.Drawing.Size(194, 166);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;

            //Add control
            this.Controls.Add(groupBox);
            groupBox.Top = 100 ;
            groupBox.Left = 200 * count;
            
        }
    }
}
