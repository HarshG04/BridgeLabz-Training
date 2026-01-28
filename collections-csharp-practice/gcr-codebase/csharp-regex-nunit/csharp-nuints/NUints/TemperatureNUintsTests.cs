using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace NUnit.tests
{
    [TestFixture]
    public class TemperatureConverterNUnitTests
    {
        private TemperatureConverter converter;

        [SetUp]
        public void Setup()
        {
            converter = new TemperatureConverter();
        }

        [Test]
        public void CelsiusToFahrenheit_ZeroCelsius_Returns32F()
        {
            double result = converter.CelsiusToFahrenheit(0);
            Assert.AreEqual(32, result);
        }

        [Test]
        public void CelsiusToFahrenheit_OneHundredCelsius_Returns212F()
        {
            double result = converter.CelsiusToFahrenheit(100);
            Assert.AreEqual(212, result);
        }

        [Test]
        public void FahrenheitToCelsius_ThirtyTwoF_ReturnsZeroC()
        {
            double result = converter.FahrenheitToCelsius(32);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void FahrenheitToCelsius_TwoHundredTwelveF_Returns100C()
        {
            double result = converter.FahrenheitToCelsius(212);
            Assert.AreEqual(100, result);
        }
    }
}
