using System;
class Program
{
    static void Main()
    {   
        double[] salary = new double[10];
        double[] yoe = new double[10];

        double[] newSalary = new double[10];
        double[] bonus = new double[10];

        double totalSalary = 0.0 , totalBonus = 0.0, totalNewSalary = 0.0;

        Console.WriteLine("Enter 10 employess salary and yoe");
        for(int i = 0; i < 10; i++)
        {   
            double s = Convert.ToDouble(Console.ReadLine());
            double y = Convert.ToDouble(Console.ReadLine());

            if(s<=0 || y < 0)
            {
                Console.WriteLine("Invalid Numbers Try again !! ");
                i--;
                continue;
            }

            salary[i] = s;
            yoe[i] = y;

            totalSalary+=salary[i];
        }

        for(int i = 0; i < 10; i++)
        {   
            double b = 0.0;
            if(yoe[i]>=5) b = 0.05;
            else b = 0.02;

            bonus[i] = salary[i]*b;
            newSalary[i] = salary[i]+bonus[i];

            totalBonus+=bonus[i];
            totalNewSalary+=newSalary[i];
        }


        Console.WriteLine($"Total salary : {totalSalary}\nTotal Bonus: {totalBonus}\nTotal New Salary : {totalNewSalary}");

        
    }
}