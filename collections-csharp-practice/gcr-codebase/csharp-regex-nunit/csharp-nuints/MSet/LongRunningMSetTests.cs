using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace MSet.tests
{
    [TestClass]
    public class PerformanceMSTests
    {
        private PerformanceUtils performanceUtils;

        [TestInitialize]
        public void Init()
        {
            performanceUtils = new PerformanceUtils();
        }

        [TestMethod]
        [Timeout(2000)] // 2 seconds
        public void LongRunningTask_ShouldCompleteWithinTime()
        {
            string result = performanceUtils.LongRunningTask();
            Assert.AreEqual("Completed", result);
        }
    }
}
