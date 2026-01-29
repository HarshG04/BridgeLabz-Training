using System;
using System.IO;

class Program
{
    static void Main()
    {
        string employees = "employees.csv";
        Console.Write("Enter employee name to search: ");
        string name = Console.ReadLine();

        if (File.Exists(employees))
        {
            string[] employee = File.ReadAllLines(employees);
            bool found = false;

            for (int i = 1; i < employee.Length; i++)
            {
                string[] data = employee[i].Split(',');

                if (data[1].Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Department: " + data[2]);
                    Console.WriteLine("Salary: " + data[3]);
                    found = true;
                    break;
                }
            }

            if (!found)
                Console.WriteLine("Employee not found.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
