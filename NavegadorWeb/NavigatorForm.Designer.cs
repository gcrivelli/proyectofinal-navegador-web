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
            this.panel1 = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.whoAreButton = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(92, 12);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(75, 23);
            this.forwardButton.TabIndex = 2;
            this.forwardButton.Text = "Adelante";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(173, 12);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Actualizar";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // directionBox
            // 
            this.directionBox.Location = new System.Drawing.Point(254, 14);
            this.directionBox.Name = "directionBox";
            this.directionBox.Size = new System.Drawing.Size(462, 20);
            this.directionBox.TabIndex = 4;
            this.directionBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.directionBox_KeyDown);
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(722, 12);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(72, 23);
            this.goButton.TabIndex = 5;
            this.goButton.Text = "Ir";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.whoAreButton);
            this.panel1.Controls.Add(this.goButton);
            this.panel1.Controls.Add(this.forwardButton);
            this.panel1.Controls.Add(this.directionBox);
            this.panel1.Controls.Add(this.updateButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 46);
            this.panel1.TabIndex = 6;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(74, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Atrás";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // whoAreButton
            // 
            this.whoAreButton.Location = new System.Drawing.Point(850, 11);
            this.whoAreButton.Name = "whoAreButton";
            this.whoAreButton.Size = new System.Drawing.Size(100, 23);
            this.whoAreButton.TabIndex = 6;
            this.whoAreButton.Text = "Quienes somos?";
            this.whoAreButton.UseVisualStyleBackColor = true;
            this.whoAreButton.Click += new System.EventHandler(this.whoAreButton_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(0, 52);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(957, 483);
            this.webBrowser.TabIndex = 7;
            this.webBrowser.Url = new System.Uri("http://www.google.com.ar", System.UriKind.Absolute);
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            // 
            // NavigatorForm
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 530);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.panel1);
            this.Name = "NavigatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Navegador Web";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.NavigatorForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox directionBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button whoAreButton;
        private System.Windows.Forms.Button backButton;
    }
}

