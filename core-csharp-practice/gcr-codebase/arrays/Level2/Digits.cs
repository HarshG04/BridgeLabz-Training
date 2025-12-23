using System;

class Program
{
    static void Main()
    {   
        Console.Write("Enter a num: ");
        int n = Convert.ToInt32(Console.ReadLine());
        
        int maxDigit = 10;
        int[] arr = new int[maxDigit];

        int i = 0;
        while (n > 0)
        {
            if(i==maxDigit) break;
            arr[i++] = n%10;
            n/=10;
        } 

        int max = -1 , max1 = max;
        for(i = 0; i < 10; i++)
        {
            Console.Write(arr[i]+" ");
            if (arr[i] > max)
            {
                max1 = max;
                max = arr[i];
            }
            else if(arr[i]<max && arr[i]>max1) max1 = arr[i];
        }

        Console.WriteLine($"Largest Number : {max}\nSecond Largest Number : {max1}");





    }
}