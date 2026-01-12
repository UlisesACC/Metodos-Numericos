namespace WindowsFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Text = "Métodos Numéricos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;

            // Left sidebar panel with gradient-like appearance
            this.leftPanel = new System.Windows.Forms.Panel();
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Width = 250;
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.Controls.Add(this.leftPanel);

            // Title label in sidebar
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle.Text = "MÉTODOS NUMÉRICOS";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.AutoSize = false;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Width = 250;
            this.lblTitle.Height = 60;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Controls.Add(this.lblTitle);

            // Separator
            this.separator = new System.Windows.Forms.Panel();
            this.separator.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.separator.Height = 2;
            this.separator.Width = 250;
            this.separator.Location = new System.Drawing.Point(0, 60);
            this.leftPanel.Controls.Add(this.separator);

            // Buttons
            this.btnBisection = new System.Windows.Forms.Button();
            this.btnSecant = new System.Windows.Forms.Button();
            this.btnFalsePosition = new System.Windows.Forms.Button();
            this.btnNewton = new System.Windows.Forms.Button();
            this.btnMuller = new System.Windows.Forms.Button();

            this.btnBisection.Text = "Bisección";
            this.btnBisection.Size = new System.Drawing.Size(230, 50);
            this.btnBisection.Location = new System.Drawing.Point(10, 70);
            this.btnBisection.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnBisection.ForeColor = System.Drawing.Color.White;
            this.btnBisection.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.btnBisection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBisection.FlatAppearance.BorderSize = 0;
            this.btnBisection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBisection.Click += new System.EventHandler(this.btnBisection_Click);
            this.leftPanel.Controls.Add(this.btnBisection);

            this.btnSecant.Text = "Secante";
            this.btnSecant.Size = new System.Drawing.Size(230, 50);
            this.btnSecant.Location = new System.Drawing.Point(10, 130);
            this.btnSecant.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnSecant.ForeColor = System.Drawing.Color.White;
            this.btnSecant.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.btnSecant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecant.FlatAppearance.BorderSize = 0;
            this.btnSecant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecant.Click += new System.EventHandler(this.btnSecant_Click);
            this.leftPanel.Controls.Add(this.btnSecant);

            this.btnFalsePosition.Text = "Falsa Posición";
            this.btnFalsePosition.Size = new System.Drawing.Size(230, 50);
            this.btnFalsePosition.Location = new System.Drawing.Point(10, 190);
            this.btnFalsePosition.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnFalsePosition.ForeColor = System.Drawing.Color.White;
            this.btnFalsePosition.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.btnFalsePosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFalsePosition.FlatAppearance.BorderSize = 0;
            this.btnFalsePosition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFalsePosition.Click += new System.EventHandler(this.btnFalsePosition_Click);
            this.leftPanel.Controls.Add(this.btnFalsePosition);

            this.btnNewton.Text = "Newton-Raphson";
            this.btnNewton.Size = new System.Drawing.Size(230, 50);
            this.btnNewton.Location = new System.Drawing.Point(10, 250);
            this.btnNewton.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnNewton.ForeColor = System.Drawing.Color.White;
            this.btnNewton.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.btnNewton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewton.FlatAppearance.BorderSize = 0;
            this.btnNewton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewton.Click += new System.EventHandler(this.btnNewton_Click);
            this.leftPanel.Controls.Add(this.btnNewton);

            this.btnMuller.Text = "Müller";
            this.btnMuller.Size = new System.Drawing.Size(230, 50);
            this.btnMuller.Location = new System.Drawing.Point(10, 310);
            this.btnMuller.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnMuller.ForeColor = System.Drawing.Color.White;
            this.btnMuller.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.btnMuller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuller.FlatAppearance.BorderSize = 0;
            this.btnMuller.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMuller.Click += new System.EventHandler(this.btnMuller_Click);
            this.leftPanel.Controls.Add(this.btnMuller);

            // Main panel where method forms will be shown
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.Controls.Add(this.mainPanel);
        }

        #endregion

        // New controls
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel separator;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBisection;
        private System.Windows.Forms.Button btnSecant;
        private System.Windows.Forms.Button btnFalsePosition;
        private System.Windows.Forms.Button btnNewton;
        private System.Windows.Forms.Button btnMuller;
    }
}

