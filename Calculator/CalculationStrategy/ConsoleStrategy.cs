using CalculatorLibrary.Providers;

namespace Calculator.CalculationStrategy
{
    public class ConsoleStrategy : IStrategy
    {
        public void Execute()
        {
            TextLineProvider text = new TextLineProvider() ?? throw new ArgumentNullException(nameof(text));

            Console.WriteLine(Resources.Resources.ConCalEnterExpression);

            string expression = Console.ReadLine();
            var result = text.Calculate(expression);

            Console.WriteLine(string.Format(Resources.Resources.ConCalResult, result));
        }
    }
}
