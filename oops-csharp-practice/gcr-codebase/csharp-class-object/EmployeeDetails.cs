class Employee
{
    private string name;
    private int id;
    private float salary;

    public Employee(){}

    public Employee(string name,int id,float salary)
    {
        this.name = name;
        this.id = id;
        this.salary = salary;
    }

    public void SetDetails()
    {
        Console.Write("Enter name : ");
        this.name = Console.ReadLine();

        Console.Write("Enter id : ");
        this.id = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter salary : ");
        this.salary = float.Parse(Console.ReadLine());
        
    }


    public void Display()
    {
        Console.WriteLine($"Employee Name : {this.name}");
        Console.WriteLine($"Employee Id : {this.id}");
        Console.WriteLine($"Employee salary : {this.salary}");
    }

}

class Program
{
    static void Main()
    {
        Employee emp1 = new Employee("harsh",123,25000);
        emp1.Display();

        Employee emp2 = new Employee();
        emp2.SetDetails();
        emp2.Display();
        
    }
}