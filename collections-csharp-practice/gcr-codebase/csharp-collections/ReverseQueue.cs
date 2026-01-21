using System;
using System.Collections.Generic;

class ReverseQueue
{
    static void Main()
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(10);
        q.Enqueue(20);
        q.Enqueue(30);

        Reverse(q);

        foreach (int i in q) Console.Write(i + " ");
    }

    static void Reverse(Queue<int> q)
    {
        if (q.Count == 0)
            return;

        int x = q.Dequeue();
        Reverse(q);
        q.Enqueue(x);
    }
}
