namespace NavegadorWeb.GeneralDisplay
{
    partial class Login
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
            this.responsableBnt = new System.Windows.Forms.Button();
            this.adultBtn = new System.Windows.Forms.Button();
            this.adminBnt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // responsableBnt
            // 
            this.responsableBnt.Location = new System.Drawing.Point(114, 44);
            this.responsableBnt.Name = "responsableBnt";
            this.responsableBnt.Size = new System.Drawing.Size(102, 33);
            this.responsableBnt.TabIndex = 0;
            this.responsableBnt.Text = "Responsable";
            this.responsableBnt.UseVisualStyleBackColor = true;
            this.responsableBnt.Click += new System.EventHandler(this.responsableBnt_Click);
            // 
            // adultBtn
            // 
            this.adultBtn.Location = new System.Drawing.Point(114, 125);
            this.adultBtn.Name = "adultBtn";
            this.adultBtn.Size = new System.Drawing.Size(102, 33);
            this.adultBtn.TabIndex = 1;
            this.adultBtn.Text = "Adulto Mayor";
            this.adultBtn.UseVisualStyleBackColor = true;
            this.adultBtn.Click += new System.EventHandler(this.adultBtn_Click);
            // 
            // adminBnt
            // 
            this.adminBnt.Location = new System.Drawing.Point(114, 210);
            this.adminBnt.Name = "adminBnt";
            this.adminBnt.Size = new System.Drawing.Size(102, 33);
            this.adminBnt.TabIndex = 2;
            this.adminBnt.Text = "Administrador";
            this.adminBnt.UseVisualStyleBackColor = true;
            this.adminBnt.Click += new System.EventHandler(this.adminBnt_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 300);
            this.Controls.Add(this.adminBnt);
            this.Controls.Add(this.adultBtn);
            this.Controls.Add(this.responsableBnt);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button responsableBnt;
        private System.Windows.Forms.Button adultBtn;
        private System.Windows.Forms.Button adminBnt;
    }
}