using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace NUnit.tests
{
    [TestFixture]
    public class UserRegistrationNUnitTests
    {
        private UserRegistration registration;

        [SetUp]
        public void Setup()
        {
            registration = new UserRegistration();
        }

        [Test]
        public void RegisterUser_ValidInput_ReturnsTrue()
        {
            bool result = registration.RegisterUser(
                "john_doe",
                "john@example.com",
                "Password1");

            Assert.IsTrue(result);
        }

        [Test]
        public void RegisterUser_EmptyUsername_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                registration.RegisterUser("", "john@example.com", "Password1"));
        }

        [Test]
        public void RegisterUser_InvalidEmail_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                registration.RegisterUser("john", "johnexample.com", "Password1"));
        }

        [Test]
        public void RegisterUser_ShortPassword_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                registration.RegisterUser("john", "john@example.com", "123"));
        }
    }
}
