using System;

interface IDepartment
{
    void AssignDepartment(string deptName);
    void GetDepartmentDetails();
}

abstract class Employee
{
    private int employeeId;
    private string name;
    private double baseSalary;
    private string departmentName;

    public Employee(int employeeId, string name, double baseSalary)
    {
        this.employeeId = employeeId;
        this.name = name;
        this.baseSalary = baseSalary;
    }

    public void SetDepartment(string deptName)
    {
        departmentName = deptName;
    }

    protected double GetBaseSalary()
    {
        return baseSalary;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Employee ID  : " + employeeId);
        Console.WriteLine("Name         : " + name);
        Console.WriteLine("Base Salary  : " + baseSalary);
        Console.WriteLine("Department   : " + departmentName);
    }

    public abstract double CalculateSalary();
}


class FullTimeEmployee : Employee, IDepartment
{
    private double fixedSalary;

    public FullTimeEmployee(int id, string name, double baseSalary, double fixedSalary)
        : base(id, name, baseSalary)
    {
        this.fixedSalary = fixedSalary;
    }

    public void AssignDepartment(string deptName)
    {
        SetDepartment(deptName);
    }

    public void GetDepartmentDetails()
    {
        Console.WriteLine("Department Assigned Successfully.");
    }

    public override double CalculateSalary()
    {
        return GetBaseSalary() + fixedSalary;
    }
}


class PartTimeEmployee : Employee, IDepartment
{
    private int workHours;
    private double hourlyRate;

    public PartTimeEmployee(int id, string name, double baseSalary, int workHours, double hourlyRate)
        : base(id, name, baseSalary)
    {
        this.workHours = workHours;
        this.hourlyRate = hourlyRate;
    }

    public void AssignDepartment(string deptName)
    {
        SetDepartment(deptName);
    }

    public void GetDepartmentDetails()
    {
        Console.WriteLine("Department Assigned Successfully.");
    }

    public override double CalculateSalary()
    {
        return GetBaseSalary() + (workHours * hourlyRate);
    }
}


class Program
{
    static void Main()
    {
        Employee e1 = new FullTimeEmployee(101, "Harsh", 5000, 20000);
        Employee e2 = new PartTimeEmployee(102, "Kartik", 3000, 40, 200);

        Console.WriteLine("\n--- Employee 1 ---");
        e1.DisplayDetails();
        Console.WriteLine("Total Salary: " + e1.CalculateSalary());

        Console.WriteLine("\n--- Employee 2 ---");
        e2.DisplayDetails();
        Console.WriteLine("Total Salary: " + e2.CalculateSalary());
    }
}
