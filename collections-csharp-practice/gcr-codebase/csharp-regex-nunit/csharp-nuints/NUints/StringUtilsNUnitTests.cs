using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace NUnit.tests
{
    [TestFixture]
    public class StringUtilsNUnitTests
    {
        private StringUtils stringUtils;

        [SetUp]
        public void Setup()
        {
            stringUtils = new StringUtils();
        }

        [Test]
        public void Reverse_ValidString_ReturnsReversedString()
        {
            string result = stringUtils.Reverse("hello");
            Assert.AreEqual("olleh", result);
        }

        [Test]
        public void IsPalindrome_PalindromeString_ReturnsTrue()
        {
            bool result = stringUtils.IsPalindrome("madam");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_NonPalindromeString_ReturnsFalse()
        {
            bool result = stringUtils.IsPalindrome("hello");
            Assert.IsFalse(result);
        }

        [Test]
        public void ToUpperCase_ValidString_ReturnsUpperCase()
        {
            string result = stringUtils.ToUpperCase("hello");
            Assert.AreEqual("HELLO", result);
        }
    }
}
