using System;
using System.Collections.Generic;

class StockSpan
{
    public static int[] CalculateSpan(int[] prices)
    {
        int n = prices.Length;
        int[] span = new int[n];
        Stack<int> stack = new Stack<int>(); // stores indices

        for (int i = 0; i < n; i++)
        {
            // Pop indices with price <= current price
            while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
            {
                stack.Pop();
            }

            // Calculate span
            span[i] = (stack.Count == 0) ? (i + 1) : (i - stack.Peek());

            // Push current index
            stack.Push(i);
        }

        return span;
    }

    static void Main()
    {
        int[] prices = { 100, 80, 60, 70, 60, 75, 85 };

        int[] span = CalculateSpan(prices);

        Console.WriteLine("Stock Prices:");
        foreach (int p in prices)
            Console.Write(p + " ");

        Console.WriteLine("\n\nStock Span:");
        foreach (int s in span)
            Console.Write(s + " ");
    }
}
