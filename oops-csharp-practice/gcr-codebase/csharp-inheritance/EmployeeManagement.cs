using System;


public class Employee
{
    public string name;
    public int id;
    public double salary;
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Name: {name}, Id: {id}, Salary: {salary}");
    }
}

public class Manager : Employee
{
    public int teamSize;
    public override void DisplayDetails()
    {
        Console.WriteLine($"Name: {name}, Id: {id}, Salary: {salary}, TeamSize: {teamSize}");
    }
}

public class Developer : Employee
{
    public string programmingLanguage;
    public override void DisplayDetails()
    {
        Console.WriteLine($"Name: {name}, Id: {id}, Salary: {salary}, ProgrammingLanguage: {programmingLanguage}");
    }
}

public class Intern : Employee
{
    public string internshipDuration;
    public override void DisplayDetails()
    {
        Console.WriteLine($"Name: {name}, Id: {id}, Salary: {salary}, InternshipDuration: {internshipDuration}");
    }
}

public class Program
{
    public static void Main()
    {
        Employee manager = new Manager { name = "harsh", id = 1, salary = 90000, teamSize = 5 };
        Employee developer = new Developer { name = "aditya", id = 2, salary = 80000, programmingLanguage = "C#" };
        Employee intern = new Intern { name = "aryan", id = 3, salary = 20000, internshipDuration = "3 months" };
        manager.DisplayDetails();
        developer.DisplayDetails();
        intern.DisplayDetails();
    }
}

