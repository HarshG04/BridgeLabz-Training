using System;
using System.Diagnostics;
using System.Reflection;

class Worker
{
    public void DoWork()
    {
        for (int i = 0; i < 1000000; i++) { }
    }
}

class TimerTool
{
    public static void Measure(object obj, string methodName)
    {
        MethodInfo m = obj.GetType().GetMethod(methodName);

        Stopwatch sw = Stopwatch.StartNew();
        m.Invoke(obj, null);
        sw.Stop();

        Console.WriteLine("Time: " + sw.ElapsedMilliseconds + " ms");
    }
}

class Program
{
    static void Main()
    {
        Worker w = new Worker();
        TimerTool.Measure(w, "DoWork");
    }
}
