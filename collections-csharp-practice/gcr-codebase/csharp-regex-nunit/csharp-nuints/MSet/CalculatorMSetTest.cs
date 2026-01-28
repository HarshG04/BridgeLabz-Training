using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Testing;

namespace MSet.tests
{
    [TestClass]
    public class CalculatorMSTest
    {
        private Calculator calculator;

        [TestInitialize]
        public void Init()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            int result = calculator.Add(20, 10);
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            int result = calculator.Subtract(20, 10);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            int result = calculator.Multiply(20, 10);
            Assert.AreEqual(200, result);
        }

        [TestMethod]
        public void Divide_TwoNumbers_ReturnsQuotient()
        {
            int result = calculator.Divide(20, 10);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsException()
        {
            try
            {
                calculator.Divide(20, 0);
                Assert.Fail("Expected DivideByZeroException was not thrown.");
            }
            catch (DivideByZeroException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
