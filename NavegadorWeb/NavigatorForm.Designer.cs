namespace NavegadorWeb
{
    partial class NavigatorForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.forwardButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.directionBox = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(96, 18);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(75, 23);
            this.forwardButton.TabIndex = 2;
            this.forwardButton.Text = "Adelante";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(177, 18);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Actualizar";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // directionBox
            // 
            this.directionBox.Location = new System.Drawing.Point(258, 20);
            this.directionBox.Name = "directionBox";
            this.directionBox.Size = new System.Drawing.Size(462, 20);
            this.directionBox.TabIndex = 4;
            this.directionBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.directionBox_KeyDown);
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(726, 18);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(72, 23);
            this.goButton.TabIndex = 5;
            this.goButton.Text = "Ir";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(16, 18);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(74, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Atrás";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(1, 58);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(1241, 563);
            this.webBrowser.TabIndex = 6;
            this.webBrowser.Url = new System.Uri("http://www.google.com.ar", System.UriKind.Absolute);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
            // 
            // NavigatorForm
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 633);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.directionBox);
            this.Controls.Add(this.updateButton);
            this.Name = "NavigatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Navegador Web";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NavigatorForm_Load);
            this.Resize += new System.EventHandler(this.NavigatorForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox directionBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button backButton;
        public System.Windows.Forms.WebBrowser webBrowser;
    }
}

