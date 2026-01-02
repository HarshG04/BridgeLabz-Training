class Employee
{
    public int employeeID;
    protected string department;
    private double salary;

    public Employee(int id, string dept, double salary)
    {
        this.employeeID = id;
        this.department = dept;
        this.salary = salary;
    }

    public void SetSalary(double salary)
    {
        this.salary = salary;
    }

    public double GetSalary()
    {
        return salary;
    }

    public void ShowEmployee()
    {
        Console.WriteLine(employeeID);
        Console.WriteLine(department);
        Console.WriteLine(salary);
    }
}


class Program
{
    static void Main()
    {
        Employee e = new Employee(7, "IT", 60000);
        e.ShowEmployee();
        e.SetSalary(80000);
        Console.WriteLine(e.GetSalary());
    }
}