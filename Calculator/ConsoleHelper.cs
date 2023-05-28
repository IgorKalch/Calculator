
namespace Calculator
{
    public class ConsoleHelper
    {
        public bool IsUserWantEnterPath()
        {
            Console.WriteLine(Resources.Resources.IsFileCall);
            return Console.ReadKey().Key == ConsoleKey.Y;
        }
    }
}
