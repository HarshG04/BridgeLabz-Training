using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace NUnit.tests
{
    [TestFixture]
    public class PasswordValidatorNUnitTests
    {
        private PasswordValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new PasswordValidator();
        }

        [Test]
        public void ValidPassword_ReturnsTrue()
        {
            bool result = validator.IsValid("Password1");
            Assert.IsTrue(result);
        }

        [Test]
        public void PasswordWithoutUppercase_ReturnsFalse()
        {
            bool result = validator.IsValid("password1");
            Assert.IsFalse(result);
        }

        [Test]
        public void PasswordWithoutDigit_ReturnsFalse()
        {
            bool result = validator.IsValid("Password");
            Assert.IsFalse(result);
        }

        [Test]
        public void PasswordTooShort_ReturnsFalse()
        {
            bool result = validator.IsValid("Pass1");
            Assert.IsFalse(result);
        }
    }
}
