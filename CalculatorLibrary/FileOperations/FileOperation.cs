namespace CalculatorLibrary.FileOperations
{
    public class FileOperation
    {
        public async Task<string[]> ReadFileAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(nameof(filePath));
            }

            using (var fileText = File.ReadAllLinesAsync(filePath))

                return await fileText;
        }

        public async Task WriteFileAsync(string filePath, string[] content)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string fileNameForWritting = string.Format("{0}_{1}", fileName, DateTime.Now.ToString("yyyy_MM_dd_mm_ss"));
            string fullPath = filePath.Replace(fileName, fileNameForWritting);

            await File.WriteAllLinesAsync(fullPath, content);
        }
    }
}