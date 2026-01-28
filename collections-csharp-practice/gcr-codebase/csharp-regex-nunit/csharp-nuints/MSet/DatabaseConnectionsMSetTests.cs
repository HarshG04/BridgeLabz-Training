using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace MSet.tests
{
    [TestClass]
    public class DatabaseConnectionMSTests
    {
        private DatabaseConnection db;

        [TestInitialize]
        public void Init()
        {
            db = new DatabaseConnection();
            db.Connect();
        }

        [TestMethod]
        public void Connection_ShouldBeEstablished_BeforeTest()
        {
            Assert.IsTrue(db.IsConnected);
        }

        [TestCleanup]
        public void Cleanup()
        {
            db.Disconnect();
        }

        [TestMethod]
        public void Connection_ShouldBeClosed_AfterCleanup()
        {
            db.Disconnect();
            Assert.IsFalse(db.IsConnected);
        }
    }
}
