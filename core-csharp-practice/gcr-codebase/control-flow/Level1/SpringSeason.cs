using System;
class Program
{
    static void Main()
    {   
        Console.Write("Enter month and date: ");
        int month = Convert.ToInt32(Console.ReadLine());
        int day = Convert.ToInt32(Console.ReadLine());
        // if(month>=3 && month <= 6)
        // {
        //     if(month==3 && day<20) Console.WriteLine("Not a Spring Season");
        //     else if(month==6 && day>20) Console.WriteLine("Not a Spring Season");
        //     else Console.WriteLine("Its a Spring Season");

        // }

        if((month==3 && day>=20)|| month==4 || month==5 || (month==6 && day<=20)) Console.WriteLine("Its a Spring Season");
        else Console.WriteLine("Not a Spring Season");
        
    }
}