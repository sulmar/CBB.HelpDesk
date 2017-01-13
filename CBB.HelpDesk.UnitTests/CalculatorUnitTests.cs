using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CBB.PekaoCalculator;

namespace CBB.HelpDesk.UnitTests
{
    [TestClass]
    public class CalculatorUnitTests
    {
        [TestMethod]
        public void CalculateTest()
        {
            // Parametry

            decimal amount = 1000m;
            byte period = 12;
            decimal rate = 0.1m; // % roczne

            // Akcja

            ICalculator calculator = new PekaoCalculator.Calculator();

            var result = calculator.Calculate(amount, period, rate);

            Assert.AreEqual(1100, result);


        }


        [TestMethod]
        public void CalculateTest2()
        {
            // Parametry

            decimal amount = 2000m;
            byte period = 12;
            decimal rate = 0.2m; // % roczne

            // Akcja

            ICalculator calculator = new PekaoCalculator.Calculator();

            var result = calculator.Calculate(amount, period, rate);

            Assert.AreEqual(2400, result);


        }
    }
}
