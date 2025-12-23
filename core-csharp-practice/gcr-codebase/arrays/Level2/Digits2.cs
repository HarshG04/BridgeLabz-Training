using System;

class Program
{
    static void Main()
    {   
        Console.Write("Enter a num: ");
        long n = Convert.ToInt64(Console.ReadLine());
        
        int maxDigit = 10;
        int[] arr = new int[maxDigit];

        int i = 0;
        while (n > 0)
        {
            if(i==maxDigit) {
                maxDigit += 10;
                int[] tmp = new int[maxDigit];
                for(int j=0;j<arr.Length;j++) tmp[j] = arr[j];
                arr = tmp;

            }
            arr[i++] = (int)(n%10);
            n/=10;
        } 

        int max = -1 , max1 = -1;
        for(i = 0; i < arr.Length; i++)
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