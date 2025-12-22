using System;
class Program
{
    static void Main()
    {   
        Console.WriteLine("Enter three numbers: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        int l = Convert.ToInt32(Console.ReadLine());
        bool ans1 = false;
        bool ans2 = false;
        bool ans3 = false;
        if(n>m && n>l) ans1 = true;
        if(m>n && m>l) ans2 = true;
        if(l>m && l>n) ans3 = true;
        System.Console.WriteLine("Is the first number the largest? "+ans1);
        System.Console.WriteLine("Is the second number the largest? "+ans2);
        System.Console.WriteLine("Is the third number the largest? "+ans3);
    }
}