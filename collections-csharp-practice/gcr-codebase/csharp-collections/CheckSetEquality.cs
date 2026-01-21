using System;
using System.Collections.Generic;

class CheckSetEquality
{

    static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 2, 1 };

        Console.WriteLine(AreSetsEqual(set1, set2));
    }
    
    public static bool AreSetsEqual(HashSet<int> set1, HashSet<int> set2)
    {
        return set1.SetEquals(set2);
    }
}
