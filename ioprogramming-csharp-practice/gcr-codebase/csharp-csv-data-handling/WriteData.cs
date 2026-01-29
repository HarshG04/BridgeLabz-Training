using System;
using System.IO;

class Program
{
    static void Main()
    {
        string employeeFile = "employees.csv";

        string[] employees = new string[]
        {
            "ID,Name,Department,Salary",
            "1,Harsh,IT,50000",
            "2,Riya,HR,45000",
            "3,Aman,Finance,55000",
            "4,Neha,Marketing,48000",
            "5,Rahul,IT,60000"
        };

        File.WriteAllLines(employeeFile, employees);

        Console.WriteLine("CSV file created and data written successfully.");
    }
}
