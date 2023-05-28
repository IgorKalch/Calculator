using CalculatorLibrary.FileOperations;

namespace CalculatorLibraryTest
{
    [TestClass]
    public class FileOperationTest
    {
        [TestMethod]
        public async Task ReadFileAsync_PathToFile()
        {
            string[]? expected = new string[1] { "AbCd" };

            FileOperation file = new FileOperation();
            var res = await file.ReadFileAsync("Files\\ReadFileAsync_PathToFileTest.txt");

            CollectionAssert.AreEqual(expected, res);

        }

        [TestMethod]
        public void ReadFileAsync_EmptyFile()
        {
            FileOperation file = new FileOperation();
            var res = file.ReadFileAsync("Files\\ReadFileAsync_EmptyFileTest.txt");
            Assert.IsTrue(res.Result.Length == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public async Task ReadFileAsync_FileNotFoundException()
        {
            FileOperation file = new FileOperation();

            await file.ReadFileAsync("  ");            
        }

        [TestMethod]
        public  async Task WriteFileAsync_FileExist()
        {
            const string filePath = "Files\\WriteFileAsync_FileExist.txt";
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string fileNameForWritting = string.Format("{0}_{1}", fileName, DateTime.Now.ToString("yyyy_MM_dd_mm_ss"));
            string fullPath = filePath.Replace(fileName, fileNameForWritting);

            string[] content = new string[1] { "333" };

            FileOperation file = new FileOperation();

            file.WriteFileAsync(filePath, content).Wait();

            Assert.IsTrue(File.Exists(fullPath));
        }
    }
}