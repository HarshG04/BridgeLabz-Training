using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace MSet.tests
{
    [TestClass]
    public class UserRegistrationMSTests
    {
        private UserRegistration registration;

        [TestInitialize]
        public void Init()
        {
            registration = new UserRegistration();
        }

        [TestMethod]
        public void RegisterUser_ValidInput_ReturnsTrue()
        {
            bool result = registration.RegisterUser(
                "alice",
                "alice@example.com",
                "Secure123");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RegisterUser_EmptyUsername_ThrowsArgumentException()
        {
            try
            {
                registration.RegisterUser("", "alice@example.com", "Secure123");
                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void RegisterUser_InvalidEmail_ThrowsArgumentException()
        {
            try
            {
                registration.RegisterUser("alice", "aliceexample.com", "Secure123");
                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void RegisterUser_ShortPassword_ThrowsArgumentException()
        {
            try
            {
                registration.RegisterUser("alice", "alice@example.com", "123");
                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
