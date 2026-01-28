using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace MSet.tests
{
    [TestClass]
    public class DateFormatterMSTests
    {
        private DateFormatter formatter;

        [TestInitialize]
        public void Init()
        {
            formatter = new DateFormatter();
        }

        [TestMethod]
        public void FormatDate_ValidDate_ReturnsFormattedDate()
        {
            string result = formatter.FormatDate("2024-12-31");
            Assert.AreEqual("31-12-2024", result);
        }

        [TestMethod]
        public void FormatDate_InvalidFormat_ThrowsFormatException()
        {
            try
            {
                formatter.FormatDate("31-12-2024");
                Assert.Fail("Expected FormatException was not thrown.");
            }
            catch (FormatException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void FormatDate_InvalidDate_ThrowsFormatException()
        {
            try
            {
                formatter.FormatDate("2024-99-99");
                Assert.Fail("Expected FormatException was not thrown.");
            }
            catch (FormatException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
