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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.whoAreButton = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(123, 15);
            this.forwardButton.Margin = new System.Windows.Forms.Padding(4);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(100, 28);
            this.forwardButton.TabIndex = 2;
            this.forwardButton.Text = "Adelante";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(231, 15);
            this.updateButton.Margin = new System.Windows.Forms.Padding(4);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(100, 28);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Actualizar";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // directionBox
            // 
            this.directionBox.Location = new System.Drawing.Point(339, 17);
            this.directionBox.Margin = new System.Windows.Forms.Padding(4);
            this.directionBox.Name = "directionBox";
            this.directionBox.Size = new System.Drawing.Size(615, 22);
            this.directionBox.TabIndex = 4;
            this.directionBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.directionBox_KeyDown);
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(963, 15);
            this.goButton.Margin = new System.Windows.Forms.Padding(4);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(96, 28);
            this.goButton.TabIndex = 5;
            this.goButton.Text = "Ir";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.whoAreButton);
            this.panel1.Controls.Add(this.goButton);
            this.panel1.Controls.Add(this.forwardButton);
            this.panel1.Controls.Add(this.directionBox);
            this.panel1.Controls.Add(this.updateButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1283, 57);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1066, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Reescribir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1066, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Mostrar IDs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(16, 15);
            this.backButton.Margin = new System.Windows.Forms.Padding(4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(99, 28);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Atrás";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // whoAreButton
            // 
            this.whoAreButton.Location = new System.Drawing.Point(1133, 14);
            this.whoAreButton.Margin = new System.Windows.Forms.Padding(4);
            this.whoAreButton.Name = "whoAreButton";
            this.whoAreButton.Size = new System.Drawing.Size(133, 28);
            this.whoAreButton.TabIndex = 6;
            this.whoAreButton.Text = "Quienes somos?";
            this.whoAreButton.UseVisualStyleBackColor = true;
            this.whoAreButton.Click += new System.EventHandler(this.whoAreButton_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(0, 64);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(4);
            this.webBrowser.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(1276, 594);
            this.webBrowser.TabIndex = 7;
            this.webBrowser.Url = new System.Uri("http://www.google.com.ar", System.UriKind.Absolute);
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            // 
            // NavigatorForm
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 652);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NavigatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Navegador Web";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NavigatorForm_Load);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

