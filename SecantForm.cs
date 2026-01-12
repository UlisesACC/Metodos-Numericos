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
    public partial class SecantForm : UserControl
    {
        public SecantForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
            this.AutoScroll = true;

            // Main container
            var mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(20);
            this.Controls.Add(mainPanel);

            // Title
            var lblTitle = new Label();
            lblTitle.Text = "Método de Secante";
            lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 122, 204);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(0, 0);
            mainPanel.Controls.Add(lblTitle);

            // Separator
            var separator = new Panel();
            separator.BackColor = Color.FromArgb(0, 122, 204);
            separator.Height = 3;
            separator.Width = 100;
            separator.Location = new Point(0, 35);
            mainPanel.Controls.Add(separator);

            // Input section
            int yPos = 60;

            var lblFunction = new Label();
            lblFunction.Text = "Función f(x):";
            lblFunction.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblFunction.AutoSize = true;
            lblFunction.Location = new Point(0, yPos);
            mainPanel.Controls.Add(lblFunction);

            var txtFunction = new TextBox();
            txtFunction.Name = "txtFunction";
            txtFunction.Width = 300;
            txtFunction.Height = 35;
            txtFunction.Location = new Point(0, yPos + 30);
            txtFunction.Text = "x^3 - 2*x - 5";
            txtFunction.Font = new Font("Segoe UI", 10);
            mainPanel.Controls.Add(txtFunction);

            var btnEquation = new Button();
            btnEquation.Text = "?? Insertar Ecuación";
            btnEquation.Width = 150;
            btnEquation.Height = 35;
            btnEquation.Location = new Point(310, yPos + 30);
            btnEquation.BackColor = Color.FromArgb(0, 150, 136);
            btnEquation.ForeColor = Color.White;
            btnEquation.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnEquation.FlatStyle = FlatStyle.Flat;
            btnEquation.FlatAppearance.BorderSize = 0;
            btnEquation.Cursor = Cursors.Hand;
            btnEquation.Click += (s, e) =>
            {
                using (var dialog = new EquationInputDialog(txtFunction.Text))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        txtFunction.Text = dialog.Expression;
                    }
                }
            };
            mainPanel.Controls.Add(btnEquation);

            yPos += 80;

            var lblX0 = new Label();
            lblX0.Text = "Aproximaciones iniciales (x0, x1):";
            lblX0.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblX0.AutoSize = true;
            lblX0.Location = new Point(0, yPos);
            mainPanel.Controls.Add(lblX0);

            var txtX0 = new TextBox();
            txtX0.Name = "txtX0";
            txtX0.Width = 150;
            txtX0.Height = 30;
            txtX0.Location = new Point(0, yPos + 30);
            txtX0.Text = "2";
            mainPanel.Controls.Add(txtX0);

            var lblX0Label = new Label();
            lblX0Label.Text = "x0";
            lblX0Label.Font = new Font("Segoe UI", 9);
            lblX0Label.ForeColor = Color.Gray;
            lblX0Label.AutoSize = true;
            lblX0Label.Location = new Point(0, yPos + 65);
            mainPanel.Controls.Add(lblX0Label);

            var txtX1 = new TextBox();
            txtX1.Name = "txtX1";
            txtX1.Width = 150;
            txtX1.Height = 30;
            txtX1.Location = new Point(170, yPos + 30);
            txtX1.Text = "2.5";
            mainPanel.Controls.Add(txtX1);

            var lblX1Label = new Label();
            lblX1Label.Text = "x1";
            lblX1Label.Font = new Font("Segoe UI", 9);
            lblX1Label.ForeColor = Color.Gray;
            lblX1Label.AutoSize = true;
            lblX1Label.Location = new Point(170, yPos + 65);
            mainPanel.Controls.Add(lblX1Label);

            yPos += 100;

            var lblTolerance = new Label();
            lblTolerance.Text = "Tolerancia (?):";
            lblTolerance.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTolerance.AutoSize = true;
            lblTolerance.Location = new Point(0, yPos);
            mainPanel.Controls.Add(lblTolerance);

            var txtTolerance = new TextBox();
            txtTolerance.Name = "txtTolerance";
            txtTolerance.Width = 150;
            txtTolerance.Height = 30;
            txtTolerance.Location = new Point(0, yPos + 30);
            txtTolerance.Text = "0.0001";
            mainPanel.Controls.Add(txtTolerance);

            yPos += 80;

            var lblMaxIterations = new Label();
            lblMaxIterations.Text = "Máximo de iteraciones:";
            lblMaxIterations.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblMaxIterations.AutoSize = true;
            lblMaxIterations.Location = new Point(0, yPos);
            mainPanel.Controls.Add(lblMaxIterations);

            var txtMaxIterations = new TextBox();
            txtMaxIterations.Name = "txtMaxIterations";
            txtMaxIterations.Width = 150;
            txtMaxIterations.Height = 30;
            txtMaxIterations.Location = new Point(0, yPos + 30);
            txtMaxIterations.Text = "100";
            mainPanel.Controls.Add(txtMaxIterations);

            yPos += 80;

            // Calculate button
            var btnCalculate = new Button();
            btnCalculate.Text = "Calcular";
            btnCalculate.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnCalculate.BackColor = Color.FromArgb(0, 122, 204);
            btnCalculate.ForeColor = Color.White;
            btnCalculate.Width = 150;
            btnCalculate.Height = 40;
            btnCalculate.Location = new Point(0, yPos);
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.FlatAppearance.BorderSize = 0;
            btnCalculate.Cursor = Cursors.Hand;
            btnCalculate.Click += (s, e) => CalculateSecant(mainPanel, txtFunction, txtX0, txtX1, txtTolerance, txtMaxIterations);
            mainPanel.Controls.Add(btnCalculate);

            yPos += 60;

            // Results section
            var lblResults = new Label();
            lblResults.Text = "Resultados:";
            lblResults.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblResults.ForeColor = Color.FromArgb(0, 122, 204);
            lblResults.AutoSize = true;
            lblResults.Location = new Point(0, yPos);
            mainPanel.Controls.Add(lblResults);

            yPos += 40;

            var dgvResults = new DataGridView();
            dgvResults.Name = "dgvResults";
            dgvResults.Width = 800;
            dgvResults.Height = 300;
            dgvResults.Location = new Point(0, yPos);
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvResults.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvResults.BackgroundColor = Color.White;
            dgvResults.GridColor = Color.LightGray;
            mainPanel.Controls.Add(dgvResults);
        }

        private void CalculateSecant(Panel mainPanel, TextBox txtFunction, TextBox txtX0, TextBox txtX1, TextBox txtTolerance, TextBox txtMaxIterations)
        {
            try
            {
                if (!MathExpressionEvaluator.ValidateExpression(txtFunction.Text))
                {
                    MessageBox.Show("Expresión inválida. Verifique la sintaxis.\n\nEjemplos válidos:\n• x^3 - 2*x - 5\n• sin(x) - x/2\n• cos(x) - x", "Error de Sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dgv = mainPanel.Controls["dgvResults"] as DataGridView;
                dgv.Columns.Clear();
                dgv.Columns.Add("Iteración", "Iteración");
                dgv.Columns.Add("x0", "x0");
                dgv.Columns.Add("x1", "x1");
                dgv.Columns.Add("f(x1)", "f(x1)");
                dgv.Columns.Add("x2", "x2");
                dgv.Columns.Add("Error", "Error");

                if (!double.TryParse(txtX0.Text, out double x0) || 
                    !double.TryParse(txtX1.Text, out double x1) ||
                    !double.TryParse(txtTolerance.Text, out double tolerance) ||
                    !int.TryParse(txtMaxIterations.Text, out int maxIter))
                {
                    MessageBox.Show("Ingrese valores numéricos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string function = txtFunction.Text;
                int iteration = 0;
                double error = double.MaxValue;

                while (error > tolerance && iteration < maxIter)
                {
                    double fx0 = MathExpressionEvaluator.Evaluate(function, x0);
                    double fx1 = MathExpressionEvaluator.Evaluate(function, x1);
                    
                    if (Math.Abs(fx1 - fx0) < 1e-10)
                    {
                        MessageBox.Show("Error: Denominador muy cercano a cero. No se puede continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    double x2 = x1 - (fx1 * (x1 - x0)) / (fx1 - fx0);
                    error = Math.Abs(x2 - x1);

                    dgv.Rows.Add(iteration + 1, Math.Round(x0, 6), Math.Round(x1, 6), Math.Round(fx1, 6), Math.Round(x2, 6), Math.Round(error, 6));

                    x0 = x1;
                    x1 = x2;
                    iteration++;
                }

                MessageBox.Show($"? Raíz encontrada: {Math.Round(x1, 6)}\nIteraciones: {iteration}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
