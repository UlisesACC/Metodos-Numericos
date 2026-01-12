using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class EquationInputDialog : Form
    {
        private TextBox txtExpression;
        private Label lblPreview;

        public string Expression { get; set; }

        public EquationInputDialog(string initialExpression = "")
        {
            InitializeComponent();
            Expression = initialExpression;
            LoadExpression(initialExpression);
        }

        private void InitializeComponent()
        {
            this.Text = "Insertar Ecuación";
            this.Width = 900;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Main panel
            var mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(15);
            mainPanel.BackColor = Color.White;
            this.Controls.Add(mainPanel);

            // Title
            var lblTitle = new Label();
            lblTitle.Text = "Ingrese la ecuación:";
            lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(0, 0);
            mainPanel.Controls.Add(lblTitle);

            // Expression textbox
            txtExpression = new TextBox();
            txtExpression.Width = 850;
            txtExpression.Height = 40;
            txtExpression.Location = new Point(0, 30);
            txtExpression.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            txtExpression.BackColor = Color.FromArgb(240, 240, 240);
            txtExpression.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(txtExpression);

            // Preview label
            lblPreview = new Label();
            lblPreview.Text = "Ejemplo: x^3 - 2*x - 5 | sin(x) | cos(x) | sqrt(x)";
            lblPreview.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblPreview.ForeColor = Color.FromArgb(100, 100, 100);
            lblPreview.AutoSize = true;
            lblPreview.Location = new Point(0, 75);
            mainPanel.Controls.Add(lblPreview);

            // Keyboard panel
            int yPos = 110;
            var keyboardLabel = new Label();
            keyboardLabel.Text = "Teclado matemático:";
            keyboardLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            keyboardLabel.AutoSize = true;
            keyboardLabel.Location = new Point(0, yPos);
            mainPanel.Controls.Add(keyboardLabel);

            yPos += 35;
            CreateKeyboard(mainPanel, yPos);

            // Buttons panel
            var btnPanel = new Panel();
            btnPanel.Height = 50;
            btnPanel.Dock = DockStyle.Bottom;
            btnPanel.BackColor = Color.FromArgb(245, 245, 245);
            this.Controls.Add(btnPanel);

            var btnOK = new Button();
            btnOK.Text = "Aceptar";
            btnOK.Width = 100;
            btnOK.Height = 35;
            btnOK.Location = new Point(700, 8);
            btnOK.BackColor = Color.FromArgb(0, 122, 204);
            btnOK.ForeColor = Color.White;
            btnOK.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.Cursor = Cursors.Hand;
            btnOK.Click += (s, e) => { Expression = txtExpression.Text; this.DialogResult = DialogResult.OK; this.Close(); };
            btnPanel.Controls.Add(btnOK);

            var btnCancel = new Button();
            btnCancel.Text = "Cancelar";
            btnCancel.Width = 100;
            btnCancel.Height = 35;
            btnCancel.Location = new Point(810, 8);
            btnCancel.BackColor = Color.FromArgb(220, 220, 220);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnPanel.Controls.Add(btnCancel);
        }

        private void CreateKeyboard(Panel parent, int startY)
        {
            int yPos = startY;
            int xPos = 0;
            int btnWidth = 70;
            int btnHeight = 40;
            int spacing = 5;

            // Fila 1
            CreateKeyboardButton(parent, "x", xPos, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "y", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "?", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "e", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "7", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "8", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "9", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "*", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "/", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);

            // Fila 2
            xPos = 0;
            yPos += btnHeight + spacing;
            CreateKeyboardButton(parent, "x²", xPos, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "x³", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "?", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "??", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "4", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "5", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "6", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "+", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "-", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);

            // Fila 3
            xPos = 0;
            yPos += btnHeight + spacing;
            CreateKeyboardButton(parent, "sin", xPos, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "cos", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "tan", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "log", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "1", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "2", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "3", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "=", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "DEL", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);

            // Fila 4
            xPos = 0;
            yPos += btnHeight + spacing;
            CreateKeyboardButton(parent, "ln", xPos, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "exp", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "abs", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "^", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "0", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, ".", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "(", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, ")", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
            CreateKeyboardButton(parent, "C", xPos += btnWidth + spacing, yPos, btnWidth, btnHeight);
        }

        private void CreateKeyboardButton(Panel parent, string text, int x, int y, int width, int height)
        {
            var btn = new Button();
            btn.Text = text;
            btn.Width = width;
            btn.Height = height;
            btn.Location = new Point(x, y);
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.BackColor = Color.FromArgb(230, 230, 230);
            btn.ForeColor = Color.Black;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.LightGray;
            btn.Cursor = Cursors.Hand;

            btn.Click += (s, e) => HandleKeyboardInput(text);

            parent.Controls.Add(btn);
        }

        private void HandleKeyboardInput(string key)
        {
            int cursorPos = txtExpression.SelectionStart;

            if (key == "DEL")
            {
                if (txtExpression.Text.Length > 0)
                {
                    txtExpression.Text = txtExpression.Text.Substring(0, txtExpression.Text.Length - 1);
                    txtExpression.SelectionStart = txtExpression.Text.Length;
                }
            }
            else if (key == "C")
            {
                txtExpression.Text = "";
            }
            else if (key == "x²")
            {
                InsertAtCursor("x^2");
            }
            else if (key == "x³")
            {
                InsertAtCursor("x^3");
            }
            else if (key == "?")
            {
                InsertAtCursor("sqrt(");
            }
            else if (key == "??")
            {
                InsertAtCursor("sqrt(");
            }
            else if (key == "?")
            {
                InsertAtCursor("PI");
            }
            else if (key == "sin")
            {
                InsertAtCursor("sin(");
            }
            else if (key == "cos")
            {
                InsertAtCursor("cos(");
            }
            else if (key == "tan")
            {
                InsertAtCursor("tan(");
            }
            else if (key == "log")
            {
                InsertAtCursor("log(");
            }
            else if (key == "ln")
            {
                InsertAtCursor("ln(");
            }
            else if (key == "exp")
            {
                InsertAtCursor("exp(");
            }
            else if (key == "abs")
            {
                InsertAtCursor("abs(");
            }
            else
            {
                InsertAtCursor(key);
            }

            UpdatePreview();
        }

        private void InsertAtCursor(string text)
        {
            int selectionStart = txtExpression.SelectionStart;
            int selectionLength = txtExpression.SelectionLength;

            txtExpression.Text = txtExpression.Text.Substring(0, selectionStart) +
                                 text +
                                 txtExpression.Text.Substring(selectionStart + selectionLength);

            txtExpression.SelectionStart = selectionStart + text.Length;
        }

        private void UpdatePreview()
        {
            if (string.IsNullOrEmpty(txtExpression.Text))
            {
                lblPreview.Text = "Ejemplo: x^3 - 2*x - 5 | sin(x) | cos(x) | sqrt(x)";
            }
            else
            {
                lblPreview.Text = "Expresión: " + txtExpression.Text;
                lblPreview.ForeColor = Color.FromArgb(0, 122, 204);
            }
        }

        private void LoadExpression(string expression)
        {
            if (!string.IsNullOrEmpty(expression))
            {
                txtExpression.Text = expression;
                UpdatePreview();
            }
        }
    }
}
