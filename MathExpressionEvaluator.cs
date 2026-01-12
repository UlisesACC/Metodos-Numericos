using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public class MathExpressionEvaluator
    {
        public static double Evaluate(string expression, double x)
        {
            try
            {
                // Replace 'x' with the actual value
                expression = expression.Replace("x", $"({x})");
                expression = expression.Replace("X", $"({x})");

                // Replace mathematical functions
                expression = ReplaceFunctions(expression);

                // Replace ^ with Math.Pow
                expression = Regex.Replace(expression, @"(\d+|\))\s*\^\s*(\d+|\()", "Math.Pow($1,$2)");

                // Use DataTable to evaluate
                var dataTable = new System.Data.DataTable();
                var result = dataTable.Compute(expression, null);
                return Convert.ToDouble(result);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al evaluar la expresión: {ex.Message}");
            }
        }

        private static string ReplaceFunctions(string expression)
        {
            // sin
            expression = Regex.Replace(expression, @"sin\s*\(", "Math.Sin(");
            // cos
            expression = Regex.Replace(expression, @"cos\s*\(", "Math.Cos(");
            // tan
            expression = Regex.Replace(expression, @"tan\s*\(", "Math.Tan(");
            // sqrt
            expression = Regex.Replace(expression, @"sqrt\s*\(", "Math.Sqrt(");
            // log (base 10)
            expression = Regex.Replace(expression, @"log\s*\(", "Math.Log10(");
            // ln (natural logarithm)
            expression = Regex.Replace(expression, @"ln\s*\(", "Math.Log(");
            // exp
            expression = Regex.Replace(expression, @"exp\s*\(", "Math.Exp(");
            // abs
            expression = Regex.Replace(expression, @"abs\s*\(", "Math.Abs(");
            // Convert to radians for trigonometric functions
            // sin, cos, tan already expect radians in .NET
            // PI
            expression = expression.Replace("PI", Math.PI.ToString());
            expression = expression.Replace("pi", Math.PI.ToString());
            // E
            expression = expression.Replace("E", Math.E.ToString());
            expression = expression.Replace("e", Math.E.ToString());

            return expression;
        }

        public static bool ValidateExpression(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                return false;

            // Check for balanced parentheses
            int parenthesesCount = 0;
            foreach (char c in expression)
            {
                if (c == '(') parenthesesCount++;
                if (c == ')') parenthesesCount--;
                if (parenthesesCount < 0) return false;
            }

            if (parenthesesCount != 0)
                return false;

            // Check for valid characters
            string validChars = "0123456789.+-*/(^) xXsincostan sqrtlognexpabsPIpie ";
            foreach (char c in expression)
            {
                if (!validChars.Contains(c))
                    return false;
            }

            return true;
        }
    }
}
