using System.Reflection;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class TodoAttribute : Attribute
{
    public string Task;
    public string AssignedTo;
    public string Priority = "MEDIUM";

    public TodoAttribute(string task, string assignedTo)
    {
        Task = task;
        AssignedTo = assignedTo;
    }
}

class Project
{
    [Todo("Add payment gateway", "Harsh", Priority = "HIGH")]
    [Todo("Improve UI", "Riya")]
    public void BuildApp() { }

    [Todo("Fix security bug", "Aman", Priority = "CRITICAL")]
    public void SecurityModule() { }
}


class Program
{
    static void Main()
    {
        foreach (var m in typeof(Project).GetMethods())
        {
            var todos = m.GetCustomAttributes<TodoAttribute>();

            foreach (var t in todos)
            {
                Console.WriteLine($"Method: {m.Name}");
                Console.WriteLine($"Task: {t.Task}");
                Console.WriteLine($"Assigned To: {t.AssignedTo}");
                Console.WriteLine($"Priority: {t.Priority}\n");
            }
        }
    }
}
