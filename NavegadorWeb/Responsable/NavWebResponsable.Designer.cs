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
            this.endTutorialBtn = new System.Windows.Forms.Button();
            this.addStepBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addStepBntt
            // 
            this.addStepBntt.Location = new System.Drawing.Point(990, 18);
            this.addStepBntt.Name = "addStepBntt";
            this.addStepBntt.Size = new System.Drawing.Size(88, 22);
            this.addStepBntt.TabIndex = 8;
            this.addStepBntt.Text = "Grabar Tutorial";
            this.addStepBntt.UseVisualStyleBackColor = true;
            this.addStepBntt.Click += new System.EventHandler(this.addStepBntt_Click);
            // 
            // endTutorialBtn
            // 
            this.endTutorialBtn.Location = new System.Drawing.Point(1173, 18);
            this.endTutorialBtn.Name = "endTutorialBtn";
            this.endTutorialBtn.Size = new System.Drawing.Size(56, 22);
            this.endTutorialBtn.TabIndex = 9;
            this.endTutorialBtn.Text = "Terminar";
            this.endTutorialBtn.UseVisualStyleBackColor = true;
            this.endTutorialBtn.Visible = false;
            this.endTutorialBtn.Click += new System.EventHandler(this.endTutorialBtn_Click);
            // 
            // addStepBtn
            // 
            this.addStepBtn.Location = new System.Drawing.Point(1084, 17);
            this.addStepBtn.Name = "addStepBtn";
            this.addStepBtn.Size = new System.Drawing.Size(83, 23);
            this.addStepBtn.TabIndex = 10;
            this.addStepBtn.Text = "Agregar Paso";
            this.addStepBtn.UseVisualStyleBackColor = true;
            this.addStepBtn.Visible = false;
            this.addStepBtn.Click += new System.EventHandler(this.addStepBtn_Click);
            // 
            // NavWebResponsable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 681);
            this.Controls.Add(this.addStepBtn);
            this.Controls.Add(this.endTutorialBtn);
            this.Controls.Add(this.addStepBntt);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NavWebResponsable";
            this.Text = "NavWebResponsable";
            this.Controls.SetChildIndex(this.addStepBntt, 0);
            this.Controls.SetChildIndex(this.endTutorialBtn, 0);
            this.Controls.SetChildIndex(this.addStepBtn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addStepBntt;
        private System.Windows.Forms.Button endTutorialBtn;
        public System.Windows.Forms.Button addStepBtn;
    }
}