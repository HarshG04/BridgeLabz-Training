using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace MSet.tests
{
    [TestClass]
    public class NumberUtilsMSTests
    {
        private NumberUtils numberUtils;

        [TestInitialize]
        public void Init()
        {
            numberUtils = new NumberUtils();
        }

        [DataTestMethod]
        [DataRow(2, true)]
        [DataRow(4, true)]
        [DataRow(6, true)]
        [DataRow(7, false)]
        [DataRow(9, false)]
        public void IsEven_DataRows(int number, bool expected)
        {
            bool result = numberUtils.IsEven(number);

            Assert.AreEqual(expected, result);
        }
    }
}
