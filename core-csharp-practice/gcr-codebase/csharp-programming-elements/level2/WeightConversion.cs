using System;

class WeightConversion
{
    static void Main()
    {
        Console.Write("Enter weight in pounds: ");
        double weightInPounds = double.Parse(Console.ReadLine());

        double weightInKg = weightInPounds / 2.2;

        Console.WriteLine("The weight of the person in pounds is " +weightInPounds +" and in kg is " + weightInK);
    }
}
