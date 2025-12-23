using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a num: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] weight = new double[n];
        double[] height = new double[n];
        double[] bmi = new double[n];
        string[] status = new string[n];

        Console.Write("Enter weight and height: ");
        for (int i = 0; i < n; i++)
        {
            weight[i] = Convert.ToDouble(Console.ReadLine());
            height[i] = Convert.ToDouble(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            bmi[i] = weight[i] / (height[i] * height[i]);

            if (bmi[i] <= 18.4)
                status[i] = "Underweight";
            else if (bmi[i] <= 24.9)
                status[i] = "Normal";
            else if (bmi[i] <= 39.9)
                status[i] = "Overweight";
            else
                status[i] = "Obese";
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(
                $"Height: {height[i]}  Weight: {weight[i]}  BMI: {bmi[i]:F2}  Status: {status[i]}"
            );
        }
    }
}
