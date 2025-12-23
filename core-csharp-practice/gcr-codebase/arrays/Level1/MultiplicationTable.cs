using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[10];
        for(int i=1;i<=arr.Length;i++) arr[i-1] = i*number;

        for(int i = 1; i <= arr.Length; i++) Console.WriteLine($"{number} * {i} = {arr[i-1]}");


    }
}