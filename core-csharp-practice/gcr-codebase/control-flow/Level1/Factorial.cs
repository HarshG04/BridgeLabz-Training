using System;
class Program
{
    static void Main()
    {   
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if(n<0) Console.WriteLine("The number "+ n+" is not a Positive number");
        else{
            int fact = 1;
            while(n>0) fact *= (n--);
            System.Console.WriteLine("Fact is: "+fact);
        }
    }
}