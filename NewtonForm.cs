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
    public partial class NewtonForm : UserControl
    {
        public NewtonForm()
        {
            InitializeComponent();
        }

        private void CreateUI()
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
            lblTitle.Text = "Método de Newton-Raphson";
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

            var lblHelper = new Label();
            lblHelper.Text = "Ejemplo: x^3 - 2*x - 5 | sin(x) | cos(x) | sqrt(x) | log(x) | ln(x)";
            lblHelper.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblHelper.ForeColor = Color.FromArgb(100, 100, 100);
            lblHelper.AutoSize = true;
            lblHelper.Location = new Point(0, yPos + 25);
            mainPanel.Controls.Add(lblHelper);

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

            var lblDerivative = new Label();
            lblDerivative.Text = "Derivada f'(x):";
            lblDerivative.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblDerivative.AutoSize = true;
            lblDerivative.Location = new Point(0, yPos);
            mainPanel.Controls.Add(lblDerivative);

            var txtDerivative = new TextBox();
            txtDerivative.Name = "txtDerivative";
            txtDerivative.Width = 300;
            txtDerivative.Height = 35;
            txtDerivative.Location = new Point(0, yPos + 30);
            txtDerivative.Text = "3*x^2 - 2";
            txtDerivative.Font = new Font("Segoe UI", 10);
            mainPanel.Controls.Add(txtDerivative);

            var btnDerivativeEquation = new Button();
            btnDerivativeEquation.Text = "?? Insertar Ecuación";
            btnDerivativeEquation.Width = 150;
            btnDerivativeEquation.Height = 35;
            btnDerivativeEquation.Location = new Point(310, yPos + 30);
            btnDerivativeEquation.BackColor = Color.FromArgb(0, 150, 136);
            btnDerivativeEquation.ForeColor = Color.White;
            btnDerivativeEquation.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnDerivativeEquation.FlatStyle = FlatStyle.Flat;
            btnDerivativeEquation.FlatAppearance.BorderSize = 0;
            btnDerivativeEquation.Cursor = Cursors.Hand;
            btnDerivativeEquation.Click += (s, e) =>
            {
                using (var dialog = new EquationInputDialog(txtDerivative.Text))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        txtDerivative.Text = dialog.Expression;
                    }
                }
            };
            mainPanel.Controls.Add(btnDerivativeEquation);

            yPos += 80;

            var lblX0 = new Label();
            lblX0.Text = "Aproximación inicial (x0):";
            lblX0.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblX0.AutoSize = true;
            lblX0.Location = new Point(0, yPos);
            mainPanel.Controls.Add(lblX0);

            var txtX0 = new TextBox();
            txtX0.Name = "txtX0";
            txtX0.Width = 150;
            txtX0.Height = 30;
            txtX0.Location = new Point(0, yPos + 30);
            txtX0.Text = "2.5";
            mainPanel.Controls.Add(txtX0);

            yPos += 80;

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
            btnCalculate.Click += (s, e) => CalculateNewton(mainPanel, txtFunction, txtDerivative, txtX0, txtTolerance, txtMaxIterations);
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
            dgvResults.Width = 900;
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

        private void CalculateNewton(Panel mainPanel, TextBox txtFunction, TextBox txtDerivative, TextBox txtX0, TextBox txtTolerance, TextBox txtMaxIterations)
        {
            try
            {
                if (!MathExpressionEvaluator.ValidateExpression(txtFunction.Text))
                {
                    MessageBox.Show("Expresión inválida. Verifique la sintaxis.\n\nEjemplos válidos:\n• x^3 - 2*x - 5\n• sin(x) - x/2\n• cos(x) - x", "Error de Sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!MathExpressionEvaluator.ValidateExpression(txtDerivative.Text))
                {
                    MessageBox.Show("Expresión de derivada inválida. Verifique la sintaxis.", "Error de Sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dgv = mainPanel.Controls["dgvResults"] as DataGridView;
                dgv.Columns.Clear();
                dgv.Columns.Add("Iteración", "Iteración");
                dgv.Columns.Add("xn", "xn");
                dgv.Columns.Add("f(xn)", "f(xn)");
                dgv.Columns.Add("f'(xn)", "f'(xn)");
                dgv.Columns.Add("xn+1", "xn+1");
                dgv.Columns.Add("Error", "Error");

                if (!double.TryParse(txtX0.Text, out double x) || 
                    !double.TryParse(txtTolerance.Text, out double tolerance) ||
                    !int.TryParse(txtMaxIterations.Text, out int maxIter))
                {
                    MessageBox.Show("Ingrese valores numéricos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string function = txtFunction.Text;
                string derivative = txtDerivative.Text;
                int iteration = 0;
                double error = double.MaxValue;

                while (error > tolerance && iteration < maxIter)
                {
                    double fx = MathExpressionEvaluator.Evaluate(function, x);
                    double fpx = MathExpressionEvaluator.Evaluate(derivative, x);

                    if (Math.Abs(fpx) < 1e-10)
                    {
                        MessageBox.Show("La derivada es muy cercana a cero. No se puede continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    double xNext = x - fx / fpx;
                    error = Math.Abs(xNext - x);

                    dgv.Rows.Add(iteration + 1, Math.Round(x, 6), Math.Round(fx, 6), Math.Round(fpx, 6), Math.Round(xNext, 6), Math.Round(error, 6));

                    x = xNext;
                    iteration++;
                }

                MessageBox.Show($"? Raíz encontrada: {Math.Round(x, 6)}\nIteraciones: {iteration}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
