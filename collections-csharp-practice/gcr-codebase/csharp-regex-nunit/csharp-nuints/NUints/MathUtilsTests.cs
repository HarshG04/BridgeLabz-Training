using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace NUnit.tests
{
    [TestFixture]
    public class MathUtilsNUnitTests
    {
        private MathUtils mathUtils;

        [SetUp]
        public void Setup()
        {
            mathUtils = new MathUtils();
        }

        [Test]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            Assert.Throws<ArithmeticException>(() => mathUtils.Divide(10, 0));
        }
    }
}
