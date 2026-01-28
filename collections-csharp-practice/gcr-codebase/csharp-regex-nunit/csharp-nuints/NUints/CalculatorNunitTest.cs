using NUnit.Framework;
using System;
using Testing;

namespace NUnit.tests
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_TwoNumbers_ReturnsSum()
        {
            int result = calculator.Add(10, 5);
            Assert.AreEqual(15, result);
        }

        [Test]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            int result = calculator.Subtract(10, 5);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            int result = calculator.Multiply(10, 5);
            Assert.AreEqual(50, result);
        }

        [Test]
        public void Divide_TwoNumbers_ReturnsQuotient()
        {
            int result = calculator.Divide(10, 5);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
        }
    }
}