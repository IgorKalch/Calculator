using Calculator;
using Calculator.CalculationStrategy;
using Calculator.Resources;

const int Success = 1;
const int Failure = -1;

var result = Success;

try
{
    Console.WriteLine(string.Format(Resources.Greeting));

    ConsoleHelper hepler = new ConsoleHelper();

    string[] lineArgs = Environment.GetCommandLineArgs();


    IStrategy strategy = new ConsoleStrategy();
    if (lineArgs.Length >= 1 || hepler.IsUserWantEnterPath())
    {
        strategy = new CommandLineStrategy();
    }

    strategy.Execute();
    Environment.Exit(1);
}
catch
{
    Console.WriteLine(Resources.ApplicationError);
    result = Failure;
}
Environment.Exit(result);