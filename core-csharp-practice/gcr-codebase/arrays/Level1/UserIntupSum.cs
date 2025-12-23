using System;

class Program
{
    static void Main()
    {
        
        Console.WriteLine("Enter Numbers: ");

        double[] arr = new double[10];
        double sum = 0.0;
        int i = 0;
        while (true)
        {   
            if(i==10) break;
            double x = Convert.ToDouble(Console.ReadLine());
            if(x<=0) break;
            arr[i] = x;
            i++;

        }

        Console.Write("Your Numbers are : ");
        for(i = 0; i < arr.Length; i++) 
        {   
            if(arr[i]==0) break;
            sum += arr[i];
            Console.Write($"{arr[i]} ");
        }

        Console.WriteLine($"\nTotal : {sum}");

    }
}