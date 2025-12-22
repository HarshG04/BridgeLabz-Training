using System;
class Program
{
    static void Main()
    {   
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if(n<0) Console.WriteLine("The number "+ n+" is not a Positive number");
        else{
            for(int i=6;i<=9;i++) Console.WriteLine($"{n} * {i} =  {n*i}" );
        }
    }
}