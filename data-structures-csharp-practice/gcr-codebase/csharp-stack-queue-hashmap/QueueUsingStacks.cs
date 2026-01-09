using System;
using System.Collections.Generic;

class QueueUsingStacks
{
    private Stack<int> stackEnq = new Stack<int>();
    private Stack<int> stackDq = new Stack<int>();

    // Enqueue operation
    public void Enqueue(int data)
    {
        stackEnq.Push(data);
        Console.WriteLine($"Enqueued: {data}");
    }

    // Dequeue operation
    public void Dequeue()
    {
        if (stackDq.Count == 0)
        {
            while (stackEnq.Count > 0)
            {
                stackDq.Push(stackEnq.Pop());
            }
        }

        if (stackDq.Count == 0)
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        Console.WriteLine($"Dequeued: {stackDq.Pop()}");
    }

    // Display queue elements
    public void Display()
    {
        if (stackEnq.Count == 0 && stackDq.Count == 0)
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        Console.Write("Queue elements: ");

        // Elements in dequeue stack (top to bottom)
        foreach (int item in stackDq)
            Console.Write(item + " ");

        // Elements in enqueue stack (bottom to top)
        int[] temp = stackEnq.ToArray();
        for (int i = temp.Length - 1; i >= 0; i--)
            Console.Write(temp[i] + " ");

        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        QueueUsingStacks queue = new QueueUsingStacks();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        queue.Display();

        queue.Dequeue();
        queue.Display();

        queue.Enqueue(40);
        queue.Display();

        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue(); // empty case
    }
}
