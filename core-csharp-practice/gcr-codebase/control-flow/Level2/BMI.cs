using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter ur weight: ");
        double w = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter ur height: ");
        double h = Convert.ToDouble(Console.ReadLine());

        double hM = h / 100;
        double bmi = w / (hM * hM);

        Console.WriteLine($"BMI: {bmi:F1}");

        if (bmi <= 18.4) Console.WriteLine("Status: Underweight");
        else if (bmi >= 18.5 && bmi <= 24.9) Console.WriteLine("Status: Normal");
        else if (bmi >= 25.0 && bmi <= 39.9) Console.WriteLine("Status: Overweight");
        else Console.WriteLine("Status: Obese");
        
    }
}