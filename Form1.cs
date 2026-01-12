using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private System.Drawing.Color primaryColor = System.Drawing.Color.FromArgb(0, 122, 204);
        private System.Drawing.Color hoverColor = System.Drawing.Color.FromArgb(0, 90, 158);

        private BisectionForm bisectionForm;
        private SecantForm secantForm;
        private FalsePositionForm falsePositionForm;
        private NewtonForm newtonForm;
        private MullerForm mullerForm;

        public Form1()
        {
            InitializeComponent();
            InitializeMethodForms();
            SetupButtonHoverEffects();
            ShowWelcome();
        }

        private void InitializeMethodForms()
        {
            bisectionForm = new BisectionForm();
            secantForm = new SecantForm();
            falsePositionForm = new FalsePositionForm();
            newtonForm = new NewtonForm();
            mullerForm = new MullerForm();
        }

        private void SetupButtonHoverEffects()
        {
            var buttons = new[] { btnBisection, btnSecant, btnFalsePosition, btnNewton, btnMuller };

            foreach (var btn in buttons)
            {
                btn.MouseEnter += (s, e) => ((Button)s).BackColor = hoverColor;
                btn.MouseLeave += (s, e) => ((Button)s).BackColor = primaryColor;
            }
        }

        private void ShowWelcome()
        {
            this.mainPanel.Controls.Clear();
            this.leftPanel.Visible = true;

            var panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.White;

            var lblWelcome = new Label();
            lblWelcome.Text = "Bienvenido a Métodos Numéricos";
            lblWelcome.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(45, 45, 48);
            lblWelcome.AutoSize = false;
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcome.Width = this.mainPanel.Width;
            lblWelcome.Height = 80;
            lblWelcome.Location = new Point(0, 80);

            var lblDescription = new Label();
            lblDescription.Text = "Selecciona un método numérico de la barra lateral para comenzar";
            lblDescription.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            lblDescription.ForeColor = Color.FromArgb(100, 100, 100);
            lblDescription.AutoSize = false;
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            lblDescription.Width = this.mainPanel.Width;
            lblDescription.Height = 40;
            lblDescription.Location = new Point(0, 170);

            panel.Controls.Add(lblWelcome);
            panel.Controls.Add(lblDescription);
            this.mainPanel.Controls.Add(panel);
        }

        private void ShowMethodForm(UserControl form, string methodName)
        {
            this.mainPanel.Controls.Clear();
            this.leftPanel.Visible = false;

            // Create a back button container
            var topPanel = new Panel();
            topPanel.BackColor = Color.FromArgb(45, 45, 48);
            topPanel.Height = 60;
            topPanel.Dock = DockStyle.Top;
            this.mainPanel.Controls.Add(topPanel);

            var btnBack = new Button();
            btnBack.Text = "← Atrás";
            btnBack.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnBack.BackColor = primaryColor;
            btnBack.ForeColor = Color.White;
            btnBack.Width = 100;
            btnBack.Height = 40;
            btnBack.Location = new Point(15, 10);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += (s, e) => ShowWelcome();
            topPanel.Controls.Add(btnBack);

            var lblMethodTitle = new Label();
            lblMethodTitle.Text = methodName;
            lblMethodTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblMethodTitle.ForeColor = Color.White;
            lblMethodTitle.AutoSize = true;
            lblMethodTitle.Location = new Point(130, 18);
            topPanel.Controls.Add(lblMethodTitle);

            // Create container for the method form
            var contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Color.White;
            form.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(form);
            this.mainPanel.Controls.Add(contentPanel);
        }

        private void btnBisection_Click(object sender, EventArgs e)
        {
            ShowMethodForm(bisectionForm, "Método de Bisección");
        }

        private void btnSecant_Click(object sender, EventArgs e)
        {
            ShowMethodForm(secantForm, "Método de Secante");
        }

        private void btnFalsePosition_Click(object sender, EventArgs e)
        {
            ShowMethodForm(falsePositionForm, "Método de Falsa Posición");
        }

        private void btnNewton_Click(object sender, EventArgs e)
        {
            ShowMethodForm(newtonForm, "Método de Newton-Raphson");
        }

        private void btnMuller_Click(object sender, EventArgs e)
        {
            ShowMethodForm(mullerForm, "Método de Müller");
        }
    }
}
