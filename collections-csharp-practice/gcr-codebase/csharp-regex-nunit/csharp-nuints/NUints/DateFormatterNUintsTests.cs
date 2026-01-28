using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace NUnit.tests
{
    [TestFixture]
    public class DateFormatterNUnitTests
    {
        private DateFormatter formatter;

        [SetUp]
        public void Setup()
        {
            formatter = new DateFormatter();
        }

        [Test]
        public void FormatDate_ValidDate_ReturnsFormattedDate()
        {
            string result = formatter.FormatDate("2025-01-15");
            Assert.AreEqual("15-01-2025", result);
        }

        [Test]
        public void FormatDate_InvalidFormat_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() =>
                formatter.FormatDate("15-01-2025"));
        }

        [Test]
        public void FormatDate_InvalidDate_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() =>
                formatter.FormatDate("2025-13-40"));
        }
    }
}
