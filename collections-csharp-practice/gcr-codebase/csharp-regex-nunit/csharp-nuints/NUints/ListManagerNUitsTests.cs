using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace NUnit.tests
{
    [TestFixture]
    public class ListManagerNUnitTests
    {
        private ListManager listManager;
        private List<int> list;

        [SetUp]
        public void Setup()
        {
            listManager = new ListManager();
            list = new List<int>();
        }

        [Test]
        public void AddElement_AddsElementToList()
        {
            listManager.AddElement(list, 10);

            Assert.Contains(10, list);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void RemoveElement_RemovesElementFromList()
        {
            list.Add(5);
            list.Add(10);

            listManager.RemoveElement(list, 5);

            Assert.IsFalse(list.Contains(5));
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void GetSize_ReturnsCorrectSize()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);

            int size = listManager.GetSize(list);

            Assert.AreEqual(3, size);
        }
    }
}
