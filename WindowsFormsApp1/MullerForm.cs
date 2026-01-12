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
    public partial class MullerForm : UserControl
    {
        private TextBox txtFunction;
        private TextBox txtX0;
        private TextBox txtX1;
        private TextBox txtX2;
        private TextBox txtTolerance;
        private TextBox txtMaxIterations;
        private DataGridView dgvResults;
        private Label lblStatus;

        public MullerForm()
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
            lblTitle.Text = "Método de Müller";
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

            var lblX0 = new Label();
            lblX0.Text = "Tres aproximaciones iniciales:";
            lblX0.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblX0.AutoSize = true;
            lblX0.Location = new Point(0, yPos);
            inputContainer.Controls.Add(lblX0);

            txtX0 = new TextBox();
            txtX0.Name = "txtX0";
            txtX0.Width = 150;
            txtX0.Height = 30;
            txtX0.Location = new Point(0, yPos + 30);
            txtX0.Text = "1";
            inputContainer.Controls.Add(txtX0);

            var lblX0Label = new Label();
            lblX0Label.Text = "x0";
            lblX0Label.Font = new Font("Segoe UI", 9);
            lblX0Label.ForeColor = Color.Gray;
            lblX0Label.AutoSize = true;
            lblX0Label.Location = new Point(0, yPos + 65);
            inputContainer.Controls.Add(lblX0Label);

            txtX1 = new TextBox();
            txtX1.Name = "txtX1";
            txtX1.Width = 150;
            txtX1.Height = 30;
            txtX1.Location = new Point(170, yPos + 30);
            txtX1.Text = "2";
            inputContainer.Controls.Add(txtX1);

            var lblX1Label = new Label();
            lblX1Label.Text = "x1";
            lblX1Label.Font = new Font("Segoe UI", 9);
            lblX1Label.ForeColor = Color.Gray;
            lblX1Label.AutoSize = true;
            lblX1Label.Location = new Point(170, yPos + 65);
            inputContainer.Controls.Add(lblX1Label);

            txtX2 = new TextBox();
            txtX2.Name = "txtX2";
            txtX2.Width = 150;
            txtX2.Height = 30;
            txtX2.Location = new Point(340, yPos + 30);
            txtX2.Text = "3";
            inputContainer.Controls.Add(txtX2);

            var lblX2Label = new Label();
            lblX2Label.Text = "x2";
            lblX2Label.Font = new Font("Segoe UI", 9);
            lblX2Label.ForeColor = Color.Gray;
            lblX2Label.AutoSize = true;
            lblX2Label.Location = new Point(340, yPos + 65);
            inputContainer.Controls.Add(lblX2Label);

            yPos += 100;

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
            btnCalculate.Click += (s, e) => CalculateMuller();
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

        private void CalculateMuller()
        {
            try
            {
                lblStatus.Text = "";
                dgvResults.Rows.Clear();
                dgvResults.Columns.Clear();

                // Validate expression
                if (!MathExpressionEvaluator.ValidateExpression(txtFunction.Text))
                {
                    MessageBox.Show("Expresión inválida. Verifique la sintaxis.", 
                        "Error de Sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Parse input values
                if (!double.TryParse(txtX0.Text, out double x0) ||
                    !double.TryParse(txtX1.Text, out double x1) ||
                    !double.TryParse(txtX2.Text, out double x2))
                {
                    MessageBox.Show("Las aproximaciones iniciales deben ser números válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dgvResults.Columns.Add("x0", "x0");
                dgvResults.Columns.Add("x1", "x1");
                dgvResults.Columns.Add("x2", "x2");
                dgvResults.Columns.Add("x3", "x3 (nuevo)");
                dgvResults.Columns.Add("Error", "Error |x3 - x2|");

                // Müller algorithm
                string function = txtFunction.Text;
                int iteration = 0;
                double error = tolerance + 1;

                while (error > tolerance && iteration < maxIter)
                {
                    double f0 = MathExpressionEvaluator.Evaluate(function, x0);
                    double f1 = MathExpressionEvaluator.Evaluate(function, x1);
                    double f2 = MathExpressionEvaluator.Evaluate(function, x2);

                    // Divided differences
                    double h1 = x1 - x0;
                    double h2 = x2 - x1;
                    double d1 = (f1 - f0) / h1;
                    double d2 = (f2 - f1) / h2;
                    double c = (d2 - d1) / (h2 + h1);

                    // Coefficients of quadratic
                    double a = c;
                    double b = d2 + h2 * c;
                    double discr = b * b - 4 * a * f2;

                    double x3;
                    if (discr < 0)
                    {
                        MessageBox.Show("Error: Discriminante negativo en el cálculo de Müller.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    double denom = (Math.Abs(b + Math.Sqrt(discr)) > Math.Abs(b - Math.Sqrt(discr))) 
                        ? b + Math.Sqrt(discr) 
                        : b - Math.Sqrt(discr);

                    x3 = x2 - (2 * f2) / denom;
                    error = Math.Abs(x3 - x2);

                    // Add row to DataGridView
                    dgvResults.Rows.Add(
                        iteration + 1,
                        Math.Round(x0, 6),
                        Math.Round(x1, 6),
                        Math.Round(x2, 6),
                        Math.Round(x3, 6),
                        Math.Round(error, 8)
                    );

                    x0 = x1;
                    x1 = x2;
                    x2 = x3;
                    iteration++;
                }

                // Final result
                double resultValue = MathExpressionEvaluator.Evaluate(function, x2);

                lblStatus.Text = $"? Raíz encontrada: {Math.Round(x2, 6)} | f(raíz) = {Math.Round(resultValue, 8)} | Iteraciones: {iteration}";
                lblStatus.ForeColor = Color.Green;

                MessageBox.Show(
                    $"? Cálculo completado exitosamente\n\n" +
                    $"Raíz encontrada: {Math.Round(x2, 6)}\n" +
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
