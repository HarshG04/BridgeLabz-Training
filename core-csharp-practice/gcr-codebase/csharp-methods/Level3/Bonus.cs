using System;

class Program
{    static void Main()
    {
        double[,] employeeData = GetSalaryAndService();
        double[,] newSalaryData = CalculateBonus(employeeData);

        DisplayTotals(employeeData, newSalaryData);
    }

    static double[,] GetSalaryAndService()
    {   
        Random rnd = new Random();
        double[,] data = new double[10, 2];

        for (int i = 0; i < 10; i++)
        {
            data[i, 0] = rnd.Next(10000, 100000);
            data[i, 1] = rnd.Next(0, 16);
        }

        return data;
    }

    static double[,] CalculateBonus(double[,] data)
    {
        double[,] bonusData = new double[10, 2];

         for (int i = 0; i < 10; i++)
        {
            double salary = data[i, 0];
            double yos = data[i, 1];

            double rate = (yos > 5) ? 0.05 : 0.02;
            double bonus = salary * rate;
            double newSalary = salary + bonus;

            bonusData[i, 0] = bonus;
            bonusData[i, 1] = newSalary;
        }

        return bonusData;
    }

    static void DisplayTotals(double[,] oldData, double[,] newData)
    {
        double totalOld = 0, totalNew = 0, totalBonus = 0;

        for (int i = 0; i < 10; i++)
        {
            double salary = oldData[i, 0];
            double years = oldData[i, 1];
            double bonus = newData[i, 0];
            double newSalary = newData[i, 1];

            totalOld += salary;
            totalBonus += bonus;
            totalNew += newSalary;

            Console.WriteLine($"Salary :{salary}  YOE: {years}  Bonus: {bonus:F2}  New Salary: {newSalary:F2}");
        }

        Console.WriteLine($"\nTotalOldSalary:{totalOld}  Total Bonus:{totalBonus:F2}  Total New Salary:{totalNew:F2}");
    }
}
