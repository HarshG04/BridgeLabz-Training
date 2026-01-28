using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class PerformanceUtils
    {
        public string LongRunningTask()
        {
            // Simulate long processing
            Thread.Sleep(3000); // 3 seconds
            return "Completed";
        }
    }
}
