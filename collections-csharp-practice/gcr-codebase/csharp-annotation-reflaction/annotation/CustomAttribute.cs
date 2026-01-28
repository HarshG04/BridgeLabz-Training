using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class TaskInfoAttribute : Attribute
{
    public int Priority;
    public string AssignedTo;

    public TaskInfoAttribute(int priority, string assignedTo)
    {
        Priority = priority;
        AssignedTo = assignedTo;
    }
}

class TaskManager
{
    [TaskInfo(1, "Harsh")]
    public void CompleteTask() { }
}


class Program
{
    static void Main()
    {
        MethodInfo m = typeof(TaskManager).GetMethod("CompleteTask");
        TaskInfoAttribute attr = (TaskInfoAttribute)m.GetCustomAttribute(typeof(TaskInfoAttribute));

        Console.WriteLine("Priority: " + attr.Priority);
        Console.WriteLine("Assigned To: " + attr.AssignedTo);
    }
}
