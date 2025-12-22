using System;
class Program
{
    static void Main()
    {   
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if(n<0) Console.WriteLine("The number "+ n+" is not a natural number");
        else{
            for(int i = 1; i <= n; i++)
            {
                if(i%2==0) Console.WriteLine(i + " :Even");
                else Console.WriteLine(i + " :Odd");
            }
        }
    }
}