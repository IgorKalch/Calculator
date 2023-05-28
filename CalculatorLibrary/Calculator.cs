using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;

namespace CalculatorLibrary
{
    public class Calculator : ICalculator
    {
        private readonly char[] Operators = { '(', '*', '/', '+', '-' };

        private bool IsNegativeValue = false;
        private char DecimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        public decimal Calculate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentNullException();
            }

            expression = Regex.Replace(expression, @"\s", string.Empty);

            Stack<decimal> vStack = new Stack<decimal>();
            Stack<char> opStack = new Stack<char>();

            int position = 0;
            while (position < expression.Length)
            {
                if (expression[position] == '(')
                {
                    opStack.Push(expression[position]);
                    position++;
                }
                else if (expression[position] == ')')
                {
                    ProcessClosingParenthesis(vStack, opStack);
                    position++;
                }
                else if (expression[position] >= '0' && expression[position] <= '9')
                {
                    position = ProcessInputNumber(expression, position, vStack, opStack);
                }
                else
                {
                    ProcessInputOperator(expression, position, vStack, opStack);
                    position++;
                }
            }

            while (opStack.Count > 0)
            {
                ExecuteOperation(vStack, opStack);
            }

            return vStack.Pop();
        }

        private void ProcessClosingParenthesis(Stack<decimal> vStack, Stack<char> opStack)
        {
            while (opStack.Count != 0 && opStack.Peek() != '(')
            {
                ExecuteOperation(vStack, opStack);
            }

            if (opStack.Count != 0 && opStack.Peek() == '(')
            {
                opStack.Pop();
            }
        }

        private int ProcessInputNumber(string expression, int position, Stack<decimal> vStack, Stack<char> opStack)
        {
            decimal value = 0;
            bool hasDecimal = false;
            decimal decimalPlace = 0.1m;

            while (position < expression.Length && char.IsDigit(expression[position])
                || position < expression.Length && expression[position] == DecimalSeparator)
            {
                if (expression[position] == DecimalSeparator)
                {
                    if (hasDecimal)
                    {
                        throw new ArgumentException("Invalid input");
                    }
                    hasDecimal = true;
                    position++;
                }
                else
                {
                    if (hasDecimal)
                    {
                        value += (expression[position++] - '0') * decimalPlace;
                        decimalPlace *= 0.1m;
                    }
                    else
                    {
                        value = 10 * value + (expression[position++] - '0');
                    }
                }
            }

            if (IsNegativeValue)
            {
                value *= -1;
                IsNegativeValue = false;
            }

            vStack.Push(value);

            return position;
        }

        private void ProcessInputOperator(string expression, int position, Stack<decimal> vStack, Stack<char> opStack)
        {
            if (expression[position] == '-' && (position == 0 || Operators.Contains(expression[position - 1])))
            {
                IsNegativeValue = true;
                return;
            }

            while (opStack.Count > 0 && OperatorCausesEvaluation(expression[position], opStack.Peek()))
            {
                ExecuteOperation(vStack, opStack);
            }

            opStack.Push(expression[position]);
        }

        private bool OperatorCausesEvaluation(char op, char prevOp)
        {
            bool evaluate = false;

            switch (op)
            {
                case '+':
                case '-':
                    evaluate = prevOp != '(';
                    break;
                case '*':
                case '/':
                    evaluate = prevOp == '*' || prevOp == '/';
                    break;
            }
            return evaluate;
        }

        private void ExecuteOperation(Stack<decimal> vStack, Stack<char> opStack)
        {
            decimal rightOperand = vStack.Pop();
            decimal leftOperand = vStack.Pop();
            char op = opStack.Pop();

            decimal result = 0;
            switch (op)
            {
                case '+':
                    result = leftOperand + rightOperand;
                    break;
                case '-':
                    result = leftOperand - rightOperand;
                    break;
                case '*':
                    result = leftOperand * rightOperand;
                    break;
                case '/':
                    if (rightOperand == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    result = leftOperand / rightOperand;
                    break;
            }

            vStack.Push(Math.Round(result, 9));
        }
    }
}
