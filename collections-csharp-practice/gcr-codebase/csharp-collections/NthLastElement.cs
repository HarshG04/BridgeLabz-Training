using System;
using System.Collections.Generic;

class NthLastElement
{

    static void Main()
    {
        LinkedList<string> list = new LinkedList<string>();
        list.AddLast("A");
        list.AddLast("B");
        list.AddLast("C");
        list.AddLast("D");
        list.AddLast("E");

        Console.WriteLine(FindElement(list, 2));
    
    }
    
    public static string FindElement(LinkedList<string> list, int n)
    {
        LinkedListNode<string> fast = list.First;
        LinkedListNode<string> slow = list.First;

        for (int i = 0; i < n; i++)
        {
            if (fast == null)
                return null;
            fast = fast.Next;
        }

        while (fast != null)
        {
            fast = fast.Next;
            slow = slow.Next;
        }

        return slow.Value;
    }
}
