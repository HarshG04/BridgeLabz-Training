using System;

class Program
{
    static void Main()
    {
        
        Console.Write("Enter row: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter coloumn: ");
        int m = Convert.ToInt32(Console.ReadLine());

        int[,] arr = new int[n,m];

        Console.WriteLine("Enter Values: ");
        for(int i=0;i<n;i++)
            for(int j=0;j<m;j++) arr[i,j] = Convert.ToInt32(Console.ReadLine());

        int[] arr1 = new int[n*m];

        int idx = 0;
        for(int i=0;i<n;i++)
            for(int j=0;j<m;j++) arr1[idx++] = arr[i,j];

        Console.WriteLine("Elements inside the 1D Array: ");
        for(int i=0;i<arr1.Length;i++) Console.Write(arr1[i]+" ");
        
    }
}