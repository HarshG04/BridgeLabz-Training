using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace MSet.tests
{
    [TestClass]
    public class PasswordValidatorMSTests
    {
        private PasswordValidator validator;

        [TestInitialize]
        public void Init()
        {
            validator = new PasswordValidator();
        }

        [TestMethod]
        public void ValidPassword_ReturnsTrue()
        {
            bool result = validator.IsValid("Secure123");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MissingUppercase_ReturnsFalse()
        {
            bool result = validator.IsValid("secure123");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MissingDigit_ReturnsFalse()
        {
            bool result = validator.IsValid("SecurePass");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PasswordTooShort_ReturnsFalse()
        {
            bool result = validator.IsValid("Sec1");
            Assert.IsFalse(result);
        }
    }
}
