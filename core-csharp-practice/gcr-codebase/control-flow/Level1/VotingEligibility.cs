using System;
class Divisibility
{
    static void Main()
    {   
        Console.Write("Enter ur age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        if(age<18) Console.WriteLine("The person's age is "+age+" and cannot vote. ");
        else Console.WriteLine("The person's age is "+age+" and can vote. ");
        
    }
}