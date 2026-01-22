using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace StreamAssignment
{
    class Employee
    {
        public int Id;
        public string Name;
        public string Department;
        public double Salary;
    }

    internal class EmployeeSerialization
    {
        static void Main(string[] args)
        {
            string file = "employees.json";

            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Amit", Department = "IT", Salary = 50000 },
                new Employee { Id = 2, Name = "Riya", Department = "HR", Salary = 45000 }
            };

            string json = JsonSerializer.Serialize(employees);
            File.WriteAllText(file, json);

            string readJson = File.ReadAllText(file);
            List<Employee> list = JsonSerializer.Deserialize<List<Employee>>(readJson);

            foreach (var emp in list)
            {
                Console.WriteLine(emp.Id + " " + emp.Name + " " + emp.Department + " " + emp.Salary);
            }
        }
    }
}
