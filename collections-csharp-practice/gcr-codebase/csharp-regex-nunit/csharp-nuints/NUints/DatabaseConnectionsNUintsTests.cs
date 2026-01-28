using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace NUnit.tests
{
    [TestFixture]
    public class DatabaseConnectionNUnitTests
    {
        private DatabaseConnection db;

        [SetUp]
        public void SetUp()
        {
            db = new DatabaseConnection();
            db.Connect();
        }

        [Test]
        public void Connection_ShouldBeEstablished_BeforeTest()
        {
            Assert.IsTrue(db.IsConnected);
        }

        [TearDown]
        public void TearDown()
        {
            db.Disconnect();
        }

        [Test]
        public void Connection_ShouldBeClosed_AfterTearDown()
        {
            db.Disconnect();
            Assert.IsFalse(db.IsConnected);
        }
    }
}
