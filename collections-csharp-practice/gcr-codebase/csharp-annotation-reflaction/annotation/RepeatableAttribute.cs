using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class BugReportAttribute : Attribute
{
    public string Description;

    public BugReportAttribute(string desc)
    {
        Description = desc;
    }
}


class Developer
{
    [BugReport("Crash on login")]
    [BugReport("UI alignment issue")]
    public void FixCode() { }
}


class Program
{
    static void Main()
    {
        MethodInfo m = typeof(Developer).GetMethod("FixCode");

        var bugs = m.GetCustomAttributes(typeof(BugReportAttribute), false);

        foreach (BugReportAttribute bug in bugs)
            Console.WriteLine("Bug: " + bug.Description);
    }
}
