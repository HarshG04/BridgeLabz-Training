using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a num: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int count = 0;
        int x = n;
        while(x>0)
        {
            count++;
            x/=10;
        }

        int[] arr = new int[count];
        int idx = 0;
        while (n > 0)
        {
            arr[idx++] = n%10;
            n /= 10;
        }

        for(int i=0;i<count;i++) Console.Write(arr[i]+" ");
    }
}