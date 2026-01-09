using System;
using System.Collections.Generic;

class StackSorter
{
    // Main function to sort the stack
    public static void SortStack(Stack<int> stack)
    {
        if (stack.Count <= 1)
            return;

        int top = stack.Pop();

        SortStack(stack);

        InsertSorted(stack, top);
    }

    // Helper function to insert element in sorted order
    private static void InsertSorted(Stack<int> stack, int value)
    {
        if (stack.Count == 0 || stack.Peek() <= value)
        {
            stack.Push(value);
            return;
        }

        int top = stack.Pop();
        InsertSorted(stack, value);
        stack.Push(top);
    }
}

class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(3);
        stack.Push(1);
        stack.Push(4);
        stack.Push(2);

        Console.WriteLine("Original Stack:");
        PrintStack(stack);

        StackSorter.SortStack(stack);

        Console.WriteLine("\nSorted Stack (Ascending):");
        PrintStack(stack);
    }

    static void PrintStack(Stack<int> stack)
    {
        foreach (int item in stack)
            Console.Write(item + " ");
        Console.WriteLine();
    }
}
