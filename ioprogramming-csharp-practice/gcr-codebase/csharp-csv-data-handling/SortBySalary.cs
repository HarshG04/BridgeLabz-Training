using System;
using System.IO;

class Program
{
    static void Main()
    {
        string employeesFile = "employees.csv";

        if (File.Exists(employeesFile))
        {
            string[] data = File.ReadAllLines(employeesFile);

            int count = data.Length - 1;
            string[][] employees = new string[count][];

            for (int i = 1; i < data.Length; i++)
            {
                employees[i - 1] = data[i].Split(',');
            }

            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    double salary1 = double.Parse(employees[j][3]);
                    double salary2 = double.Parse(employees[j + 1][3]);

                    if (salary1 < salary2)
                    {
                        string[] temp = employees[j];
                        employees[j] = employees[j + 1];
                        employees[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Top 5 Highest Paid Employees:\n");

            int limit = count < 5 ? count : 5;

            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine("ID: " + employees[i][0] +
                                  ", Name: " + employees[i][1] +
                                  ", Dept: " + employees[i][2] +
                                  ", Salary: " + employees[i][3]);
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
