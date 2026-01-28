using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace NUnit.tests
{
    [TestFixture]
    public class NumberUtilsNUnitTests
    {
        private NumberUtils numberUtils;

        [SetUp]
        public void Setup()
        {
            numberUtils = new NumberUtils();
        }

        [TestCase(2, true)]
        [TestCase(4, true)]
        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(9, false)]
        public void IsEven_TestCases(int number, bool expected)
        {
            bool result = numberUtils.IsEven(number);

            Assert.AreEqual(expected, result);
        }
    }
}
