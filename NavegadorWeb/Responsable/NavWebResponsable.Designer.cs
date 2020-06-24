namespace NavegadorWeb.Responsable
{
    partial class NavWebResponsable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addStepBntt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addStepBntt
            // 
            this.addStepBntt.Location = new System.Drawing.Point(1087, 20);
            this.addStepBntt.Name = "addStepBntt";
            this.addStepBntt.Size = new System.Drawing.Size(138, 22);
            this.addStepBntt.TabIndex = 8;
            this.addStepBntt.Text = "Agregar Paso";
            this.addStepBntt.UseVisualStyleBackColor = true;
            this.addStepBntt.Click += new System.EventHandler(this.addStepBntt_Click);
            // 
            // NavWebResponsable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 681);
            this.Controls.Add(this.addStepBntt);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NavWebResponsable";
            this.Text = "NavWebResponsable";
            this.Controls.SetChildIndex(this.addStepBntt, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addStepBntt;
    }
}