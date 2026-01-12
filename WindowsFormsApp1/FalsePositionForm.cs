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
    public partial class FalsePositionForm : UserControl
    {
        private TextBox txtFunction;
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtTolerance;
        private TextBox txtMaxIterations;
        private DataGridView dgvResults;
        private Label lblStatus;

        public FalsePositionForm()
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
            lblTitle.Text = "Método de Falsa Posición";
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

            var lblA = new Label();
            lblA.Text = "Intervalo [a, b]:";
            lblA.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblA.AutoSize = true;
            lblA.Location = new Point(0, yPos);
            inputContainer.Controls.Add(lblA);

            txtA = new TextBox();
            txtA.Name = "txtA";
            txtA.Width = 150;
            txtA.Height = 30;
            txtA.Location = new Point(0, yPos + 30);
            txtA.Text = "2";
            inputContainer.Controls.Add(txtA);

            var lblALabel = new Label();
            lblALabel.Text = "a";
            lblALabel.Font = new Font("Segoe UI", 9);
            lblALabel.ForeColor = Color.Gray;
            lblALabel.AutoSize = true;
            lblALabel.Location = new Point(0, yPos + 65);
            inputContainer.Controls.Add(lblALabel);

            txtB = new TextBox();
            txtB.Name = "txtB";
            txtB.Width = 150;
            txtB.Height = 30;
            txtB.Location = new Point(170, yPos + 30);
            txtB.Text = "3";
            inputContainer.Controls.Add(txtB);

            var lblBLabel = new Label();
            lblBLabel.Text = "b";
            lblBLabel.Font = new Font("Segoe UI", 9);
            lblBLabel.ForeColor = Color.Gray;
            lblBLabel.AutoSize = true;
            lblBLabel.Location = new Point(170, yPos + 65);
            inputContainer.Controls.Add(lblBLabel);

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
            btnCalculate.Click += (s, e) => CalculateFalsePosition();
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

        private void CalculateFalsePosition()
        {
            try
            {
                lblStatus.Text = "";
                dgvResults.Rows.Clear();
                dgvResults.Columns.Clear();

                // Validate expression
                if (!MathExpressionEvaluator.ValidateExpression(txtFunction.Text))
                {
                    MessageBox.Show("Expresión inválida. Verifique la sintaxis.\n\nEjemplos válidos:\n• x^3 - 2*x - 5\n• sin(x) - x/2\n• cos(x) - x", 
                        "Error de Sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Parse input values
                if (!double.TryParse(txtA.Text, out double a))
                {
                    MessageBox.Show("El valor de 'a' no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtA.Focus();
                    return;
                }

                if (!double.TryParse(txtB.Text, out double b))
                {
                    MessageBox.Show("El valor de 'b' no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtB.Focus();
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

                // Verify that f(a) and f(b) have opposite signs
                double fa = MathExpressionEvaluator.Evaluate(txtFunction.Text, a);
                double fb = MathExpressionEvaluator.Evaluate(txtFunction.Text, b);

                if (fa * fb >= 0)
                {
                    MessageBox.Show($"Error: f(a) y f(b) deben tener signos opuestos.\n\nf({a}) = {fa:F6}\nf({b}) = {fb:F6}\n\nIntente con otro intervalo.", 
                        "Error de Intervalo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Initialize DataGridView columns
                dgvResults.Columns.Add("Iteración", "Iteración");
                dgvResults.Columns.Add("a", "a");
                dgvResults.Columns.Add("b", "b");
                dgvResults.Columns.Add("c", "c (punto falsa posición)");
                dgvResults.Columns.Add("f(c)", "f(c)");
                dgvResults.Columns.Add("Error", "Error |b-a|");

                // False Position algorithm
                string function = txtFunction.Text;
                int iteration = 0;
                double error = Math.Abs(b - a);
                double c = 0;

                while (error > tolerance && iteration < maxIter)
                {
                    fa = MathExpressionEvaluator.Evaluate(function, a);
                    fb = MathExpressionEvaluator.Evaluate(function, b);

                    c = a - (fa * (b - a)) / (fb - fa);
                    double fc = MathExpressionEvaluator.Evaluate(function, c);

                    error = Math.Abs(b - a);

                    // Add row to DataGridView
                    dgvResults.Rows.Add(
                        iteration + 1,
                        Math.Round(a, 6),
                        Math.Round(b, 6),
                        Math.Round(c, 6),
                        Math.Round(fc, 8),
                        Math.Round(error, 8)
                    );

                    if (fa * fc < 0)
                        b = c;
                    else
                        a = c;

                    iteration++;
                }

                // Final result
                double resultValue = MathExpressionEvaluator.Evaluate(function, c);

                lblStatus.Text = $"? Raíz encontrada: {Math.Round(c, 6)} | f(raíz) = {Math.Round(resultValue, 8)} | Iteraciones: {iteration}";
                lblStatus.ForeColor = Color.Green;

                MessageBox.Show(
                    $"? Cálculo completado exitosamente\n\n" +
                    $"Raíz encontrada: {Math.Round(c, 6)}\n" +
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
