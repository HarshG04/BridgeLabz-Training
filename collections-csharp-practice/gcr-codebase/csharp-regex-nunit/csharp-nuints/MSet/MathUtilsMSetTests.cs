using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace MSet.tests
{
    [TestClass]
    public class MathUtilsMSTests
    {
        private MathUtils mathUtils;

        [TestInitialize]
        public void Init()
        {
            mathUtils = new MathUtils();
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            try
            {
                mathUtils.Divide(10, 0);
                Assert.Fail("Expected ArithmeticException was not thrown.");
            }
            catch (ArithmeticException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
