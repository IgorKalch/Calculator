namespace CalculatorLibrary.Providers
{
    public class TextLineProvider
    {
        public string Calculate(string expression)
        {
            try
            {
                return new Calculator().Calculate(expression).ToString();
            }
            catch (Exception ex)
            {
                return ex.GetType().Name;
            }
        }
    }
}
