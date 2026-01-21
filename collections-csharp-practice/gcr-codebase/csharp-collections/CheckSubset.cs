using System;
using System.Collections.Generic;

class CheckSubset
{
    static void Main()
    {
        HashSet<int> s1 = new HashSet<int> { 2, 3 };
        HashSet<int> s2 = new HashSet<int> { 1, 2, 3, 4 };

        Console.WriteLine(s1.IsSubsetOf(s2));
    }
}
