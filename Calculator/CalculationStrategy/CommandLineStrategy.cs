using CalculatorLibrary.FileOperations;
using CalculatorLibrary.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.CalculationStrategy
{
    public class CommandLineStrategy : IStrategy
    {
        public void Execute()
        {
            string path = null;
            string[] lineArgs = Environment.GetCommandLineArgs();

            if (lineArgs.Length > 1)
            {
                path = lineArgs[1];
            }
            else
            {
                Console.WriteLine(Resources.Resources.FileCalInputMessage);
                path = Console.ReadLine();
            }

            FileProvider file = new FileProvider() ?? throw new ArgumentNullException(nameof(file));
            FileOperation operation =new FileOperation() ?? throw new ArgumentNullException(nameof(operation));

            var content = operation.ReadFileAsync(path).Result;
            var calculatedContent = file.Calculate(content);
            var taskWrite = operation.WriteFileAsync(path, calculatedContent);

            if (taskWrite.IsCompletedSuccessfully)
            {
                Console.WriteLine(Resources.Resources.FileCalІSuccess);
            }
            else
            {
                Console.WriteLine(Resources.Resources.FileCalFail);
            }
        }
    }
}
