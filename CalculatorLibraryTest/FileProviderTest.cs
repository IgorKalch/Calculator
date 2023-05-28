using CalculatorLibrary;
using CalculatorLibrary.Providers;

namespace CalculatorLibraryTest
{
    [TestClass]
    public class FileProviderTest
    {
        [TestMethod]
        public async Task Calculate_Success()
        {
            string[] input = new string[7] { "2+2*3", "2/0", "1+2*(3+2)", "1+x+4", "2+15/3+4*2", "", "rrew" };
            string[] expected = new string[7] { "2+2*3 = 8"
                ,"2/0 = DivideByZeroException"
                ,"1+2*(3+2) = 11"
                ,"1+x+4 = InvalidOperationException"
                ,"2+15/3+4*2 = 15"
                ," = ArgumentNullException"
                ,"rrew = InvalidOperationException" 
            };
            
            FileProvider file = new FileProvider();

            var result = file.Calculate(input);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Calculate_ErrorArrayNull()
        {
            FileProvider file = new FileProvider();

            file.Calculate(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Calculate_ErrorArrayEmpty()
        {
            FileProvider file = new FileProvider();

            string[] array = new string[0];

            file.Calculate(array);
        }
    }
}