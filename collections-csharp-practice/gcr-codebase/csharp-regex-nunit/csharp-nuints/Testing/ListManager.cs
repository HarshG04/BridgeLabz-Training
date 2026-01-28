using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class ListManager
    {
        public void AddElement(List<int> list, int element)
        {
            list.Add(element);
        }

        public void RemoveElement(List<int> list, int element)
        {
            list.Remove(element);
        }

        public int GetSize(List<int> list)
        {
            return list.Count;
        }
    }
}
