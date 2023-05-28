using CalculatorLibrary;
using System.Globalization;

namespace CalculatorLibraryTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        [DataRow("5,3*2", 10.6)]
        [DataRow("5*3-2*2", 11.0)]
        [DataRow("5*(3+2)*2", 50.0)]
        [DataRow("5*5", 25.0)]
        [DataRow("5+5", 10.0)]
        [DataRow("5-5", 0.0)]
        [DataRow("-5-5", -10.0)]
        [DataRow("-5+-5", -10.0)]
        [DataRow("5/5", 1.0)]
        [DataRow("45/5", 9.0)]
        [DataRow("1000/20", 50.0)]
        [DataRow("5*(1+1)", 10.0)]
        [DataRow("((2*2)+0)+(1+1)", 6.0)]
        [DataRow("5*(1-1)", 0.0)]
        [DataRow("(5*(1-1))", 0.0)]
        [DataRow("(5*(1-1)+(2/1))", 2.0)]
        [DataRow("(1+3+10)*10-(100/4)*-1+20", 185.0)]
        [DataRow("2	+	6*(100/4)	-3 ", 149)]
        [DataRow("(3-(28,5*3-(38,6/6,25-6)/3,2)*(-2,5))/-2", -108.30625)]
        public void Calculate_Success_FrCulture(string initial, double expected)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            ICalculator calculator = new Calculator();

            var result = calculator.Calculate(initial);

            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        [DataRow("5.3*2", 10.6)]
        [DataRow("5*3-2*2", 11.0)]
        [DataRow("5*(3+2)*2", 50.0)]
        [DataRow("5*5", 25.0)]
        [DataRow("5+5", 10.0)]
        [DataRow("5-5", 0.0)]
        [DataRow("-5-5", -10.0)]
        [DataRow("-5+-5", -10.0)]
        [DataRow("5/5", 1.0)]
        [DataRow("45/5", 9.0)]
        [DataRow("1000/20", 50.0)]
        [DataRow("5*(1+1)", 10.0)]
        [DataRow("((2*2)+0)+(1+1)", 6.0)]
        [DataRow("5*(1-1)", 0.0)]
        [DataRow("(5*(1-1))", 0.0)]
        [DataRow("(5*(1-1)+(2/1))", 2.0)]
        [DataRow("(1+3+10)*10-(100/4)*-1+20", 185.0)]
        [DataRow("2	+	6*(100/4)	-3 ", 149)]
        [DataRow("(3-(28.5*3-(38.6/6.25-6)/3.2)*(-2.5))/-2", -108.30625)]
        public void Calculate_Success_EnCulture(string initial, double expected)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            ICalculator calculator = new Calculator();

            var result = calculator.Calculate(initial);

            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Calculate_ErrorNull()
        {
            ICalculator calculator = new Calculator();
            calculator.Calculate("");
        }

    }
}