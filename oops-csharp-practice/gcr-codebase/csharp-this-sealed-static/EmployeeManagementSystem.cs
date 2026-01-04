using System;

class Employee
{
    public static string CompanyName = "Goyal Tech House";
    private static int totalEmployees;

    public static void DisplayTotalEmployees()
    {
        Console.WriteLine("\nTotal Employees: " + totalEmployees);
    }


    public string Name;
    public readonly int Id;
    public string Designation;


    public Employee(string Name, int Id, string Designation)
    {
        this.Name = Name;
        this.Id = Id;
        this.Designation = Designation;

        totalEmployees++;
    }


    public static void ShowEmployeeDetails(object obj)
    {
        if (obj is Employee emp)
        {
            Console.WriteLine("\n--- Employee Details ---");
            Console.WriteLine("Company Name : " + CompanyName);
            Console.WriteLine("Name         : " + emp.Name);
            Console.WriteLine("Employee ID  : " + emp.Id);
            Console.WriteLine("Designation  : " + emp.Designation);
        }
        else
        {
            Console.WriteLine("\nGiven object is NOT an Employee");
        }
    }
}

class Program
{
    static void Main()
    {
        Employee e1 = new Employee("Harsh", 101, "SDE");
        Employee e2 = new Employee("Aditya", 102, "QAE");

        Employee.ShowEmployeeDetails(e1);
        Employee.ShowEmployeeDetails(e2);

        Employee.DisplayTotalEmployees();

        // Testing with non-employee object
        Employee.ShowEmployeeDetails("Hello");
    }
}
