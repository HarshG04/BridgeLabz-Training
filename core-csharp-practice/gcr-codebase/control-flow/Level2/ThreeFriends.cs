using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Amar's age: ");
        int amarAge = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Amar's height: ");
        double amarHeight = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Akbar's age: ");
        int akbarAge = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Akbar's height: ");
        double akbarHeight = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Anthony's age: ");
        int anthonyAge = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Anthony's height: ");
        double anthonyHeight = Convert.ToDouble(Console.ReadLine());

        int youngestAge = amarAge;
        string youngest = "Amar";

        if(akbarAge < youngestAge) 
        { 
            youngestAge = akbarAge; 
            youngest = "Akbar"; 
        }
        if(anthonyAge < youngestAge) 
        { 
            youngestAge = anthonyAge; 
            youngest = "Anthony"; 
        }

        double tallestHeight = amarHeight;
        string tallest = "Amar";

        if (akbarHeight > tallestHeight)
        { 
            tallestHeight = akbarHeight; 
            tallest = "Akbar"; 
        }
        if (anthonyHeight > tallestHeight) 
        { tallestHeight = anthonyHeight;
          tallest = "Anthony"; 
        }

        Console.WriteLine($"Youngest Friend: {youngest}");
        Console.WriteLine($"Tallest Friend: {tallest}");
    }
}
