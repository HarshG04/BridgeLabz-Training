using System;

public class Person
{
    public string name;
    public int id;
}

public interface IWorker
{
    void PerformDuties();
}

public class Chef : Person, IWorker
{
    public void PerformDuties()
    {
        Console.WriteLine($"Chef {name} is cooking");
    }
}

public class Waiter : Person, IWorker
{
    public void PerformDuties()
    {
        Console.WriteLine($"Waiter {name} is serving");
    }
}

public class Program
{
    public static void Main()
    {
        IWorker chef = new Chef { name = "harsh", id = 1 };
        IWorker waiter = new Waiter { name = "aditya", id = 2 };
        chef.PerformDuties();
        waiter.PerformDuties();
    }
}
