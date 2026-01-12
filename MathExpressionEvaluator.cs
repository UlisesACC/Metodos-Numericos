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
                // Reemplazar 'x' con el valor actual
                expression = expression.Replace("x", $"({x})");
                expression = expression.Replace("X", $"({x})");

                // Reemplazar constantes
                expression = expression.Replace("PI", Math.PI.ToString());
                expression = expression.Replace("pi", Math.PI.ToString());
                expression = expression.Replace("e", Math.E.ToString());
                expression = expression.Replace("E", Math.E.ToString());

                // Procesar funciones personalizadas antes de usar DataTable
                expression = EvaluateFunctions(expression);

                // Reemplazar ^ por Math.Pow equivalente usando paréntesis
                expression = HandleExponentiation(expression);

                // Usar DataTable solo para operaciones básicas
                var dataTable = new System.Data.DataTable();
                var result = dataTable.Compute(expression, null);
                return Convert.ToDouble(result);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al evaluar la expresión: {ex.Message}");
            }
        }

        private static string EvaluateFunctions(string expression)
        {
            // Procesar funciones de adentro hacia afuera
            // sin(expr) -> evaluar sin(expr)
            expression = ProcessFunction(expression, "sin", (val) => Math.Sin(val));
            expression = ProcessFunction(expression, "cos", (val) => Math.Cos(val));
            expression = ProcessFunction(expression, "tan", (val) => Math.Tan(val));
            expression = ProcessFunction(expression, "sqrt", (val) => Math.Sqrt(val));
            expression = ProcessFunction(expression, "log", (val) => Math.Log10(val));
            expression = ProcessFunction(expression, "ln", (val) => Math.Log(val));
            expression = ProcessFunction(expression, "exp", (val) => Math.Exp(val));
            expression = ProcessFunction(expression, "abs", (val) => Math.Abs(val));

            return expression;
        }

        private static string ProcessFunction(string expression, string funcName, Func<double, double> mathFunc)
        {
            // Patrón para encontrar funciones como sin(x), cos(2*x), etc.
            var pattern = $@"{funcName}\s*\(\s*([^()]*(?:\([^()]*\)[^()]*)*)\s*\)";
            
            while (Regex.IsMatch(expression, pattern, RegexOptions.IgnoreCase))
            {
                var match = Regex.Match(expression, pattern, RegexOptions.IgnoreCase);
                if (!match.Success) break;

                var innerExpr = match.Groups[1].Value;
                
                try
                {
                    // Evaluar recursivamente la expresión interna
                    var innerValue = Evaluate(innerExpr, 0); // Pasamos 0 porque ya está evaluada
                    var result = mathFunc(innerValue);
                    
                    // Reemplazar la función con el resultado
                    expression = expression.Substring(0, match.Index) + result.ToString() + 
                                expression.Substring(match.Index + match.Length);
                }
                catch
                {
                    break;
                }
            }

            return expression;
        }

        private static string HandleExponentiation(string expression)
        {
            // Reemplazar x^n con (x)*(x)*... n veces para valores simples
            // O usar un patrón que DataTable entienda mejor
            // Para potencias simples, usamos multiplicación repetida
            
            var pattern = @"(\d+\.?\d*|\([^)]+\))\s*\^\s*(\d+)";
            var matches = Regex.Matches(expression, pattern);

            foreach (Match match in matches.Cast<Match>().Reverse())
            {
                var baseStr = match.Groups[1].Value;
                var expStr = match.Groups[2].Value;
                
                if (int.TryParse(expStr, out int exponent) && exponent > 0 && exponent <= 10)
                {
                    // Generar multiplicación repetida: x^3 = x*x*x
                    var replacement = string.Join("*", Enumerable.Repeat(baseStr, exponent));
                    expression = expression.Substring(0, match.Index) + replacement + 
                                expression.Substring(match.Index + match.Length);
                }
            }

            return expression;
        }

        public static bool ValidateExpression(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                return false;

            // Verificar paréntesis balanceados
            int parenthesesCount = 0;
            foreach (char c in expression)
            {
                if (c == '(') parenthesesCount++;
                if (c == ')') parenthesesCount--;
                if (parenthesesCount < 0) return false;
            }

            if (parenthesesCount != 0)
                return false;

            // Verificar caracteres válidos
            string validChars = "0123456789.+-*/(^) xXyYsincostaelnpigabsqrtsxp ,";
            foreach (char c in expression)
            {
                if (!validChars.Contains(c))
                    return false;
            }

            return true;
        }
    }
}
