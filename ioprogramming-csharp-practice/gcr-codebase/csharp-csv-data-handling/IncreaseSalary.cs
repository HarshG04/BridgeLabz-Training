using System;
using System.IO;

class Program
{
    static void Main()
    {
        string employeesFile = "employees.csv";
        string newEmployeesFile = "updated_employees.csv";

        if (File.Exists(employeesFile))
        {
            string[] employees = File.ReadAllLines(employeesFile);

            for (int i = 1; i < employees.Length; i++)
            {
                string[] employee = employees[i].Split(',');

                if (employee[2] == "IT")
                {
                    double salary = double.Parse(employee[3]);
                    salary = salary + (salary * 0.10);
                    employee[3] = salary.ToString();
                    employees[i] = string.Join(",", employee);
                }
            }

            File.WriteAllLines(newEmployeesFile, employees);
            Console.WriteLine("Updated file saved as " + newEmployeesFile);
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
