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
        private System.Drawing.Color primaryColor = System.Drawing.Color.FromArgb(52, 152, 219);
        private System.Drawing.Color hoverColor = System.Drawing.Color.FromArgb(41, 128, 185);
        private System.Drawing.Color darkSidebar = System.Drawing.Color.FromArgb(31, 47, 61);
        private System.Drawing.Color lightGray = System.Drawing.Color.FromArgb(189, 195, 199);

        private BisectionForm bisectionForm;
        private SecantForm secantForm;
        private FalsePositionForm falsePositionForm;
        private NewtonForm newtonForm;
        private MullerForm mullerForm;

        private Button btnAccordion;
        private Panel accordionPanel;
        private bool isAccordionExpanded = true;

        public Form1()
        {
            InitializeComponent();
            InitializeMethodForms();
            SetupButtonHoverEffects();
            CreateAccordionUI();
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

        private void CreateAccordionUI()
        {
            // Crear el botón acordeón
            btnAccordion = new Button();
            btnAccordion.Text = "▼ Solución de ecuaciones de 1 variable";
            btnAccordion.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAccordion.BackColor = primaryColor;
            btnAccordion.ForeColor = Color.White;
            btnAccordion.Width = 230;
            btnAccordion.Height = 50;
            btnAccordion.Location = new Point(10, 90);
            btnAccordion.FlatStyle = FlatStyle.Flat;
            btnAccordion.FlatAppearance.BorderSize = 0;
            btnAccordion.Cursor = Cursors.Hand;
            btnAccordion.Click += BtnAccordion_Click;

            // Crear el panel del acordeón que contendrá los botones de métodos
            accordionPanel = new Panel();
            accordionPanel.Location = new Point(10, 140);
            accordionPanel.Width = 230;
            accordionPanel.Height = 0;
            accordionPanel.AutoScroll = true;
            accordionPanel.BackColor = lightGray;

            // Crear botones de métodos dinámicamente
            int yPosition = 5;
            var methods = new[]
            {
                ("Bisección", (EventHandler)btnBisection_Click),
                ("Secante", (EventHandler)btnSecant_Click),
                ("Falsa Posición", (EventHandler)btnFalsePosition_Click),
                ("Newton-Raphson", (EventHandler)btnNewton_Click),
                ("Müller", (EventHandler)btnMuller_Click)
            };

            foreach (var (name, clickHandler) in methods)
            {
                var btn = new Button();
                btn.Text = name;
                btn.Location = new Point(5, yPosition);
                btn.Width = 220;
                btn.Height = 45;
                btn.BackColor = lightGray;
                btn.ForeColor = Color.FromArgb(52, 73, 94);
                btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.FromArgb(149, 165, 166);
                btn.Cursor = Cursors.Hand;
                btn.Click += clickHandler;

                // Eventos de hover
                btn.MouseEnter += (s, e) =>
                {
                    btn.BackColor = primaryColor;
                    btn.ForeColor = Color.White;
                };
                btn.MouseLeave += (s, e) =>
                {
                    btn.BackColor = lightGray;
                    btn.ForeColor = Color.FromArgb(52, 73, 94);
                };

                accordionPanel.Controls.Add(btn);
                yPosition += 50;
            }

            // Agregar controles a leftPanel
            leftPanel.Controls.Add(accordionPanel);
            leftPanel.Controls.Add(btnAccordion);
        }

        private void BtnAccordion_Click(object sender, EventArgs e)
        {
            isAccordionExpanded = !isAccordionExpanded;

            if (isAccordionExpanded)
            {
                accordionPanel.Height = 260;
                btnAccordion.Text = "▼ Solución de ecuaciones de 1 variable";
            }
            else
            {
                accordionPanel.Height = 0;
                btnAccordion.Text = "► Solución de ecuaciones de 1 variable";
            }
        }

        private void SetupButtonHoverEffects()
        {
            // Este método se puede dejar vacío o remover, ya que el hover se configura en CreateAccordionUI
        }

        private void ShowWelcome()
        {
            this.mainPanel.Controls.Clear();

            var panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.White;

            // Logo/Icon area
            var logoPanel = new Panel();
            logoPanel.Height = 120;
            logoPanel.Dock = DockStyle.Top;
            logoPanel.BackColor = Color.FromArgb(52, 152, 219);
            panel.Controls.Add(logoPanel);

            var lblWelcome = new Label();
            lblWelcome.Text = "🔢 Bienvenido a Métodos Numéricos";
            lblWelcome.Font = new Font("Segoe UI", 26, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.AutoSize = false;
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcome.Width = logoPanel.Width;
            lblWelcome.Height = 120;
            lblWelcome.Dock = DockStyle.Fill;
            logoPanel.Controls.Add(lblWelcome);

            // Content area
            var contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Color.White;
            contentPanel.Padding = new Padding(40);
            panel.Controls.Add(contentPanel);

            var lblDescription = new Label();
            lblDescription.Text = "Selecciona un método numérico de la barra lateral para comenzar\n\n" +
                "Esta aplicación te permite calcular raíces de ecuaciones utilizando diferentes métodos numéricos.";
            lblDescription.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            lblDescription.ForeColor = Color.FromArgb(52, 73, 94);
            lblDescription.AutoSize = false;
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            lblDescription.Width = contentPanel.Width;
            lblDescription.Height = 100;
            lblDescription.Location = new Point(0, 40);
            contentPanel.Controls.Add(lblDescription);

            // Methods grid
            var gridPanel = new Panel();
            gridPanel.AutoSize = true;
            gridPanel.Location = new Point(0, 150);
            gridPanel.Width = contentPanel.Width;
            contentPanel.Controls.Add(gridPanel);

            string[] methods = { "Bisección", "Secante", "Falsa Posición", "Newton-Raphson", "Müller" };
            int x = 0;
            int y = 0;

            foreach (var method in methods)
            {
                var methodCard = new Panel();
                methodCard.Width = 200;
                methodCard.Height = 120;
                methodCard.Location = new Point(x, y);
                methodCard.BackColor = Color.FromArgb(236, 240, 241);
                methodCard.BorderStyle = BorderStyle.FixedSingle;
                methodCard.Cursor = Cursors.Hand;
                gridPanel.Controls.Add(methodCard);

                var lblMethod = new Label();
                lblMethod.Text = method;
                lblMethod.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lblMethod.ForeColor = Color.FromArgb(52, 152, 219);
                lblMethod.AutoSize = false;
                lblMethod.TextAlign = ContentAlignment.MiddleCenter;
                lblMethod.Width = 200;
                lblMethod.Height = 120;
                lblMethod.Dock = DockStyle.Fill;
                methodCard.Controls.Add(lblMethod);

                // Hover effect
                methodCard.MouseEnter += (s, e) =>
                {
                    methodCard.BackColor = Color.FromArgb(52, 152, 219);
                    lblMethod.ForeColor = Color.White;
                };
                methodCard.MouseLeave += (s, e) =>
                {
                    methodCard.BackColor = Color.FromArgb(236, 240, 241);
                    lblMethod.ForeColor = Color.FromArgb(52, 152, 219);
                };

                x += 220;
                if (x > contentPanel.Width - 240)
                {
                    x = 0;
                    y += 140;
                }
            }

            this.mainPanel.Controls.Add(panel);
        }

        private void ShowMethodForm(UserControl form, string methodName)
        {
            this.mainPanel.Controls.Clear();

            // Create a container that will hold both top bar and content
            var containerPanel = new Panel();
            containerPanel.Dock = DockStyle.Fill;
            containerPanel.BackColor = Color.FromArgb(236, 240, 241);

            // Create a professional top bar
            var topPanel = new Panel();
            topPanel.BackColor = Color.FromArgb(52, 152, 219);
            topPanel.Height = 70;
            topPanel.Dock = DockStyle.Top;
            containerPanel.Controls.Add(topPanel);

            // Back button
            var btnBack = new Button();
            btnBack.Text = "◄ Atrás";
            btnBack.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnBack.BackColor = Color.Transparent;
            btnBack.ForeColor = Color.White;
            btnBack.Width = 100;
            btnBack.Height = 50;
            btnBack.Location = new Point(15, 10);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Cursor = Cursors.Hand;
            btnBack.MouseEnter += (s, e) => ((Button)s).BackColor = Color.FromArgb(41, 128, 185);
            btnBack.MouseLeave += (s, e) => ((Button)s).BackColor = Color.Transparent;
            btnBack.Click += (s, e) => ExpandLeftPanel();
            topPanel.Controls.Add(btnBack);

            // Method title
            var lblMethodTitle = new Label();
            lblMethodTitle.Text = "▶ " + methodName;
            lblMethodTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblMethodTitle.ForeColor = Color.White;
            lblMethodTitle.AutoSize = true;
            lblMethodTitle.Location = new Point(130, 20);
            topPanel.Controls.Add(lblMethodTitle);

            // Create content panel that will hold the form
            var contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Color.FromArgb(236, 240, 241);
            contentPanel.AutoScroll = true;
            form.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(form);
            containerPanel.Controls.Add(contentPanel);

            this.mainPanel.Controls.Add(containerPanel);
        }

        private void CompressLeftPanel()
        {
            // Cambiar el tamaño de la barra lateral a 0
            this.leftPanel.Width = 0;
        }

        private void ExpandLeftPanel()
        {
            // Expandir la barra lateral nuevamente
            this.leftPanel.Width = 250;
            ShowWelcome();
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
