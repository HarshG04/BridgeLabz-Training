using System;

class Program
{
    static void Main()
    {
        double[,] data = new double[10, 3]; // [weight, height(cm), bmi]
        string[] bmiData;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Enter details for Person {i + 1}");

            Console.Write("Weight (kg): ");
            data[i, 0] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Height (cm): ");
            data[i, 1] = Convert.ToDouble(Console.ReadLine());
        }

        CalculateBMI(data);
        bmiData = GetBMIData(data);

        for (int i = 0; i < 10; i++)
        {   
            Console.WriteLine($"Data Of Person {i+1}");
            Console.WriteLine($"Height : {data[i,1]:F2} Weight : {data[i,0]:F2} BMI: {data[i,2]:F2} Status: {bmiData[i]}");
        }
    }

    static void CalculateBMI(double[,] data)
    {
        for (int i = 0; i < 10; i++)
        {
            double heightInMeters = data[i, 1] / 100;
            data[i, 2] = data[i, 0] / (heightInMeters * heightInMeters);
        }
    }

    static string[] GetBMIData(double[,] data)
    {
        string[] bmiData = new string[10];

        for (int i = 0; i < 10; i++)
        {
            double bmi = data[i, 2];

            if (bmi <= 18.4) bmiData[i] = "Underweight";
            else if (bmi <= 24.9) bmiData[i] = "Normal";
            else if (bmi <= 39.9) bmiData[i] = "Overweight";
            else bmiData[i] = "Obese";
        }

        return bmiData;
    }
}
