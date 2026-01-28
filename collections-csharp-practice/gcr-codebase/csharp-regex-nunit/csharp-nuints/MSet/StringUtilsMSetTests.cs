using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace MSet.tests
{
    [TestClass]
    public class StringUtilsMSTests
    {
        private StringUtils stringUtils;

        [TestInitialize]
        public void Init()
        {
            stringUtils = new StringUtils();
        }

        [TestMethod]
        public void Reverse_ValidString_ReturnsReversedString()
        {
            string result = stringUtils.Reverse("world");
            Assert.AreEqual("dlrow", result);
        }

        [TestMethod]
        public void IsPalindrome_PalindromeString_ReturnsTrue()
        {
            bool result = stringUtils.IsPalindrome("level");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPalindrome_NonPalindromeString_ReturnsFalse()
        {
            bool result = stringUtils.IsPalindrome("test");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ToUpperCase_ValidString_ReturnsUpperCase()
        {
            string result = stringUtils.ToUpperCase("test");
            Assert.AreEqual("TEST", result);
        }
    }
}
