using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace MSet.tests
{
    [TestClass]
    public class ListManagerMSTests
    {
        private ListManager listManager;
        private List<int> list;

        [TestInitialize]
        public void Init()
        {
            listManager = new ListManager();
            list = new List<int>();
        }

        [TestMethod]
        public void AddElement_AddsElementToList()
        {
            listManager.AddElement(list, 20);

            CollectionAssert.Contains(list, 20);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void RemoveElement_RemovesElementFromList()
        {
            list.Add(10);
            list.Add(20);

            listManager.RemoveElement(list, 10);

            CollectionAssert.DoesNotContain(list, 10);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void GetSize_ReturnsCorrectSize()
        {
            list.Add(5);
            list.Add(15);

            int size = listManager.GetSize(list);

            Assert.AreEqual(2, size);
        }
    }
}
