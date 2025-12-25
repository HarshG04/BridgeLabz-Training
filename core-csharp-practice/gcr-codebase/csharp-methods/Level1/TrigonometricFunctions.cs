using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter Angle in degree: ");
        double degree = Convert.ToDouble(Console.ReadLine());
        double radian = degree*Math.PI/180;

        double[] ans = CalculateTrigonometricFunctions(radian);

        Console.WriteLine($"Sin({degree}) = {ans[0]:F2}");
        Console.WriteLine($"Cos({degree}) = {ans[1]:F2}");
        Console.WriteLine($"Tan({degree}) = {ans[2]:F2}");


    }

    static double[] CalculateTrigonometricFunctions(double angle)
    {
        double[] ans = new double[3];
        ans[0] = Math.Sin(angle);
        ans[1] = Math.Cos(angle);
        ans[2] = Math.Tan(angle);

        return ans;
    }

}