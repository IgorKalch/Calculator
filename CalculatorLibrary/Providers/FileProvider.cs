namespace CalculatorLibrary.Providers
{
    public class FileProvider
    {
        public string[] Calculate(string[] content)
        {
            if (content == null || content.Length == 0)
            {
                throw new ArgumentNullException(nameof(content));
            }

            for (int i = 0; i < content.Length; i++)
            {
                var result = string.Concat(" = ", new TextLineProvider().Calculate(content[i]));
                content[i] = string.Concat(content[i], result);
            }
            
            return content;
        }
    }
}
