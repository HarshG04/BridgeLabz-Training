using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter 5 numbers: ");
        int[] num = new int[5];
        for(int i=0;i<num.Length;i++) num[i] = Convert.ToInt32(Console.ReadLine());

        for(int i = 0; i < num.Length; i++)
        {
            if(num[i]<0) Console.WriteLine($"{num[i]} : Negative");
            else if (num[i] > 0)
            {
                if(num[i]%2==0) Console.WriteLine($"{num[i]} : Positive and Even");
                else Console.WriteLine($"{num[i]} : Positive and Odd");

            }
            else Console.WriteLine($"{num[i]} : Zero");
        }

        if(num[0]==num[num.Length-1]) Console.WriteLine($"first numer {num[0]} and last number {num[num.Length-1]} are EQUAL");
        if(num[0]>num[num.Length-1]) Console.WriteLine($"first numer {num[0]} Is Greater than last number {num[num.Length-1]}");
        else Console.WriteLine($"first numer {num[0]} is Lesser Than last number {num[num.Length-1]}");
    }
}