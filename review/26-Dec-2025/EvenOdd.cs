using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter size of array: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];
        Console.WriteLine("Enter values: ");
        for(int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int[] even = new int[n];
        int[] odd = new int[n];

        int e = 0, o = 0;
        for(int i = 0; i < n; i++)
        {
            if(arr[i]%2==0) even[e++] = arr[i];
            else odd[o++] = arr[i];
        }

        Console.Write("Even Values: ");
        foreach(int i in even) 
        {
            if(i==0) break;
            Console.Write(i+" ");
        }
        Console.Write("\nOdd Values: ");
        foreach(int i in odd) 
        {
            if(i==0) break;
            Console.Write(i+" ");
        }
    }
}