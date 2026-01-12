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
        private TextBox txtFunction;
        private TextBox txtDerivative;
        private TextBox txtX0;
        private TextBox txtTolerance;
        private TextBox txtMaxIterations;
        private DataGridView dgvResults;
        private Label lblStatus;

        public NewtonForm()
        {
            InitializeComponent();
            CreateUI();
        }

        private void CreateUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
            this.AutoScroll = true;

            // Main container with FlowLayoutPanel
            var mainPanel = new FlowLayoutPanel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(20);
            mainPanel.AutoScroll = true;
            mainPanel.WrapContents = false;
            mainPanel.FlowDirection = FlowDirection.TopDown;
            this.Controls.Add(mainPanel);

            // Title
            var lblTitle = new Label();
            lblTitle.Text = "Método de Newton-Raphson";
            lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 122, 204);
            lblTitle.AutoSize = true;
            mainPanel.Controls.Add(lblTitle);

            // Separator
            var separator = new Panel();
            separator.BackColor = Color.FromArgb(0, 122, 204);
            separator.Height = 3;
            separator.Width = 100;
            mainPanel.Controls.Add(separator);

            // Input section container
            var inputContainer = new Panel();
            inputContainer.AutoSize = true;
            inputContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            inputContainer.Width = 500;
            mainPanel.Controls.Add(inputContainer);

            int yPos = 0;

            var lblFunction = new Label();
            lblFunction.Text = "Función f(x):";
            lblFunction.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblFunction.AutoSize = true;
            lblFunction.Location = new Point(0, yPos);
            inputContainer.Controls.Add(lblFunction);

            txtFunction = new TextBox();
            txtFunction.Name = "txtFunction";
            txtFunction.Width = 300;
            txtFunction.Height = 35;
            txtFunction.Location = new Point(0, yPos + 30);
            txtFunction.Text = "x^3 - 2*x - 5";
            txtFunction.Font = new Font("Segoe UI", 10);
            inputContainer.Controls.Add(txtFunction);

            var btnEquation = new Button();
            btnEquation.Text = "? Insertar Ecuación";
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
            inputContainer.Controls.Add(btnEquation);

            yPos += 80;

            var lblDerivative = new Label();
            lblDerivative.Text = "Derivada f'(x):";
            lblDerivative.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblDerivative.AutoSize = true;
            lblDerivative.Location = new Point(0, yPos);
            inputContainer.Controls.Add(lblDerivative);

            txtDerivative = new TextBox();
            txtDerivative.Name = "txtDerivative";
            txtDerivative.Width = 300;
            txtDerivative.Height = 35;
            txtDerivative.Location = new Point(0, yPos + 30);
            txtDerivative.Text = "3*x^2 - 2";
            txtDerivative.Font = new Font("Segoe UI", 10);
            inputContainer.Controls.Add(txtDerivative);

            yPos += 80;

            var lblX0 = new Label();
            lblX0.Text = "Aproximación inicial (x0):";
            lblX0.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblX0.AutoSize = true;
            lblX0.Location = new Point(0, yPos);
            inputContainer.Controls.Add(lblX0);

            txtX0 = new TextBox();
            txtX0.Name = "txtX0";
            txtX0.Width = 150;
            txtX0.Height = 30;
            txtX0.Location = new Point(0, yPos + 30);
            txtX0.Text = "2.5";
            inputContainer.Controls.Add(txtX0);

            yPos += 80;

            var lblTolerance = new Label();
            lblTolerance.Text = "Tolerancia (?):";
            lblTolerance.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTolerance.AutoSize = true;
            lblTolerance.Location = new Point(0, yPos);
            inputContainer.Controls.Add(lblTolerance);

            txtTolerance = new TextBox();
            txtTolerance.Name = "txtTolerance";
            txtTolerance.Width = 150;
            txtTolerance.Height = 30;
            txtTolerance.Location = new Point(0, yPos + 30);
            txtTolerance.Text = "0.0001";
            inputContainer.Controls.Add(txtTolerance);

            yPos += 80;

            var lblMaxIterations = new Label();
            lblMaxIterations.Text = "Máximo de iteraciones:";
            lblMaxIterations.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblMaxIterations.AutoSize = true;
            lblMaxIterations.Location = new Point(0, yPos);
            inputContainer.Controls.Add(lblMaxIterations);

            txtMaxIterations = new TextBox();
            txtMaxIterations.Name = "txtMaxIterations";
            txtMaxIterations.Width = 150;
            txtMaxIterations.Height = 30;
            txtMaxIterations.Location = new Point(0, yPos + 30);
            txtMaxIterations.Text = "100";
            inputContainer.Controls.Add(txtMaxIterations);

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
            btnCalculate.Click += (s, e) => CalculateNewton();
            inputContainer.Controls.Add(btnCalculate);

            yPos += 60;

            // Status label
            lblStatus = new Label();
            lblStatus.Text = "";
            lblStatus.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblStatus.ForeColor = Color.Green;
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(0, yPos);
            inputContainer.Controls.Add(lblStatus);

            // Results section
            var lblResults = new Label();
            lblResults.Text = "Resultados:";
            lblResults.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblResults.ForeColor = Color.FromArgb(0, 122, 204);
            lblResults.AutoSize = true;
            mainPanel.Controls.Add(lblResults);

            dgvResults = new DataGridView();
            dgvResults.Name = "dgvResults";
            dgvResults.Width = 1000;
            dgvResults.Height = 400;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.ReadOnly = true;
            dgvResults.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvResults.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvResults.BackgroundColor = Color.White;
            dgvResults.GridColor = Color.LightGray;
            dgvResults.RowHeadersVisible = false;
            mainPanel.Controls.Add(dgvResults);
        }

        private void CalculateNewton()
        {
            try
            {
                lblStatus.Text = "";
                dgvResults.Rows.Clear();
                dgvResults.Columns.Clear();

                // Validate expressions
                if (!MathExpressionEvaluator.ValidateExpression(txtFunction.Text) || 
                    !MathExpressionEvaluator.ValidateExpression(txtDerivative.Text))
                {
                    MessageBox.Show("Expresión inválida. Verifique la sintaxis.", 
                        "Error de Sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Parse input values
                if (!double.TryParse(txtX0.Text, out double x0))
                {
                    MessageBox.Show("El valor de 'x0' no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtX0.Focus();
                    return;
                }

                if (!double.TryParse(txtTolerance.Text, out double tolerance) || tolerance <= 0)
                {
                    MessageBox.Show("La tolerancia debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTolerance.Focus();
                    return;
                }

                if (!int.TryParse(txtMaxIterations.Text, out int maxIter) || maxIter <= 0)
                {
                    MessageBox.Show("El máximo de iteraciones debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaxIterations.Focus();
                    return;
                }

                // Initialize DataGridView columns
                dgvResults.Columns.Add("Iteración", "Iteración");
                dgvResults.Columns.Add("x", "x");
                dgvResults.Columns.Add("f(x)", "f(x)");
                dgvResults.Columns.Add("f'(x)", "f'(x)");
                dgvResults.Columns.Add("x_nuevo", "x_nuevo");
                dgvResults.Columns.Add("Error", "Error |x_nuevo - x|");

                // Newton-Raphson algorithm
                string function = txtFunction.Text;
                string derivative = txtDerivative.Text;
                int iteration = 0;
                double error = tolerance + 1;
                double x = x0;

                while (error > tolerance && iteration < maxIter)
                {
                    double fx = MathExpressionEvaluator.Evaluate(function, x);
                    double fpx = MathExpressionEvaluator.Evaluate(derivative, x);

                    if (Math.Abs(fpx) < 1e-10)
                    {
                        MessageBox.Show("Error: La derivada es muy pequeña (división por cero).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    double xNew = x - (fx / fpx);
                    error = Math.Abs(xNew - x);

                    // Add row to DataGridView
                    dgvResults.Rows.Add(
                        iteration + 1,
                        Math.Round(x, 6),
                        Math.Round(fx, 8),
                        Math.Round(fpx, 8),
                        Math.Round(xNew, 6),
                        Math.Round(error, 8)
                    );

                    x = xNew;
                    iteration++;
                }

                // Final result
                double resultValue = MathExpressionEvaluator.Evaluate(function, x);

                lblStatus.Text = $"? Raíz encontrada: {Math.Round(x, 6)} | f(raíz) = {Math.Round(resultValue, 8)} | Iteraciones: {iteration}";
                lblStatus.ForeColor = Color.Green;

                MessageBox.Show(
                    $"? Cálculo completado exitosamente\n\n" +
                    $"Raíz encontrada: {Math.Round(x, 6)}\n" +
                    $"f(raíz) = {Math.Round(resultValue, 8)}\n" +
                    $"Iteraciones realizadas: {iteration}\n" +
                    $"Error final: {Math.Round(error, 8)}\n" +
                    $"Tolerancia: {tolerance}",
                    "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "";
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
