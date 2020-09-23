namespace NavegadorWeb
{
    partial class NavigatorForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigatorForm2));
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
            this.forwardButton.Location = new System.Drawing.Point(144, 28);
            this.forwardButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(112, 35);
            this.forwardButton.TabIndex = 2;
            this.forwardButton.Text = "Adelante";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(266, 28);
            this.updateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(112, 35);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Actualizar";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // directionBox
            // 
            this.directionBox.Location = new System.Drawing.Point(387, 31);
            this.directionBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.directionBox.Name = "directionBox";
            this.directionBox.Size = new System.Drawing.Size(691, 26);
            this.directionBox.TabIndex = 4;
            this.directionBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.directionBox_KeyDown);
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(1089, 28);
            this.goButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(108, 35);
            this.goButton.TabIndex = 5;
            this.goButton.Text = "Ir";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(24, 28);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(111, 35);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Atrás";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(2, 89);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.webBrowser.MinimumSize = new System.Drawing.Size(30, 31);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(1862, 866);
            this.webBrowser.TabIndex = 6;
            this.webBrowser.Url = new System.Uri("http://www.google.com.ar", System.UriKind.Absolute);
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            // 
            // NavigatorForm2
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 974);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.directionBox);
            this.Controls.Add(this.updateButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NavigatorForm2";
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

