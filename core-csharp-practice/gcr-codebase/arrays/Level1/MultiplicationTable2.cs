using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[4];
        for(int i=6;i<=9;i++) arr[i-6] = i*number;

        for(int i = 6; i <= 9; i++) Console.WriteLine($"{number} * {i} = {arr[i-6]}");


    }
}