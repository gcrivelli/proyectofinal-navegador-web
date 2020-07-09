namespace NavegadorWeb.Adult
{
    partial class NavWebAdult
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
            this.viewTutorialBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // viewTutorialBtn
            // 
            this.viewTutorialBtn.Location = new System.Drawing.Point(1091, 20);
            this.viewTutorialBtn.Name = "viewTutorialBtn";
            this.viewTutorialBtn.Size = new System.Drawing.Size(74, 23);
            this.viewTutorialBtn.TabIndex = 7;
            this.viewTutorialBtn.Text = "Ver Tutorial";
            this.viewTutorialBtn.UseVisualStyleBackColor = true;
            this.viewTutorialBtn.Click += new System.EventHandler(this.viewTutorialBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1042, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(43, 20);
            this.textBox1.TabIndex = 8;
            // 
            // NavWebAdult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 643);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.viewTutorialBtn);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "NavWebAdult";
            this.Text = "NavWebAdult";
            this.Controls.SetChildIndex(this.viewTutorialBtn, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button viewTutorialBtn;
        private System.Windows.Forms.TextBox textBox1;
    }
}