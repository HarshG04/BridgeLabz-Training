using System;
using System.Collections.Generic;

class SetToSortedList
{
    static void Main()
    {
        HashSet<int> set = new HashSet<int> { 5, 3, 9, 1 };

        List<int> sortedList = new List<int>(set);
        sortedList.Sort();

        foreach (int i in sortedList) Console.Write(i + " ");
    }
}
