using CalculatorLibrary;
using CalculatorLibrary.Providers;

namespace CalculatorLibraryTest
{
    [TestClass]
    public class TextLineProviderTest
    {
        [TestMethod]
        [DataRow("2+2*3", "8")]
        [DataRow("1+2*(3+2)", "11")]
        [DataRow("2+15/3+4*2", "15")]
        public void Calculate_Success(string initial, string expected)
        {
            TextLineProvider text = new TextLineProvider();

            var result = text.Calculate(initial);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("2/0", "DivideByZeroException")]
        public void Calculate_Success_ExceptionDivideByZero(string initial, string expected)
        {
            TextLineProvider text = new TextLineProvider();

            var result = text.Calculate(initial);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("rrew", "InvalidOperationException")]
        [DataRow("1 + x + 4", "InvalidOperationException")]
        public void Calculate_Success_ExceptionInvalidOperation(string initial, string expected)
        {
            TextLineProvider text = new TextLineProvider();

            var result = text.Calculate(initial);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("", "ArgumentNullException")]
        public void Calculate_Success_ExceptionArgumentNull(string initial, string expected)
        {
            TextLineProvider text = new TextLineProvider();

            var result = text.Calculate(initial);

            Assert.AreEqual(expected, result);
        }
    }
}