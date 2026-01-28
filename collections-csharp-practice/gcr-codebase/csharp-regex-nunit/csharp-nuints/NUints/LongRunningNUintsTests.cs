using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace NUnit.tests
{
    [TestFixture]
    public class PerformanceNUnitTests
    {
        private PerformanceUtils performanceUtils;

        [SetUp]
        public void Setup()
        {
            performanceUtils = new PerformanceUtils();
        }

        [Test]
        [Timeout(2000)] // 2 seconds
        public void LongRunningTask_ShouldCompleteWithinTime()
        {
            string result = performanceUtils.LongRunningTask();
            Assert.AreEqual("Completed", result);
        }
    }
}
