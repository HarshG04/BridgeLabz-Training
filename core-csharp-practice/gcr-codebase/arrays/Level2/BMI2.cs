using System;

class Program
{
    static void Main()
    {   
        Console.Write("Enter no. of persons: ");
        int num = Convert.ToInt32(Console.ReadLine());

        double[][] personData = new double[num][];
        string[] weightStatus = new string[num];

        for (int i = 0; i < num; i++)
        {
            personData[i] = new double[3]; // [0]=weight, [1]=height, [2]=BMI
            double weight=0.0, height=0.0;

            while (weight <= 0 || height <= 0)
            {
                weight = Convert.ToDouble(Console.ReadLine());
                height = Convert.ToDouble(Console.ReadLine());
            }

            personData[i][0] = weight;
            personData[i][1] = height;
        }

        for (int i = 0; i < num; i++)
        {
            double weight = personData[i][0];
            double height = personData[i][1];

            double bmi = weight / (height * height);
            personData[i][2] = bmi;

            if (bmi <= 18.4) weightStatus[i] = "Underweight";
            else if (bmi <= 24.9) weightStatus[i] = "Normal";
            else if (bmi <= 39.9) weightStatus[i] = "Overweight";
            else weightStatus[i] = "Obese";
        }

        for (int i = 0; i < num; i++)
        {
            Console.WriteLine($"Height: {personData[i][1]}  Weight: {personData[i][0]}  BMI: {personData[i][2]:F2}  Status: {weightStatus[i]}");
        }
    }
}
