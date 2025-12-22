using System;
class Program
{
    static void Main()
    {   
        Console.WriteLine("Enter three numbers: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        int l = Convert.ToInt32(Console.ReadLine());
        bool ans = false;
        if(n<m && n<l) ans = true;
        System.Console.WriteLine("Is the first number the smallest?  "+ans);
    }
}