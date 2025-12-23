using System;

class Program
{
    static void Main()
    {
        
        Console.WriteLine("Enter players Height: ");

        double[] arr = new double[11];
        double sum = 0.0;
        
        for(int i = 0; i < arr.Length; i++) 
        {   
           arr[i] = Convert.ToDouble(Console.ReadLine());
           sum += arr[i];
        }

        double mean = sum/11.0;

        Console.WriteLine($"Mean Height : {mean}");

    }
}