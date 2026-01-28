using System;
using System.Diagnostics;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class LogExecutionTimeAttribute : Attribute { }

class Worker
{
    [LogExecutionTime]
    public void FastMethod()
    {
        for (int i = 0; i < 100000; i++) { }
    }

    [LogExecutionTime]
    public void SlowMethod()
    {
        System.Threading.Thread.Sleep(500);
    }
}

class Program
{
    static void Main()
    {
        Worker w = new Worker();

        foreach (var m in typeof(Worker).GetMethods())
        {
            if (m.GetCustomAttribute<LogExecutionTimeAttribute>() != null)
            {
                Stopwatch sw = Stopwatch.StartNew();
                m.Invoke(w, null);
                sw.Stop();

                Console.WriteLine($"{m.Name} took {sw.ElapsedMilliseconds} ms");
            }
        }
    }
}

