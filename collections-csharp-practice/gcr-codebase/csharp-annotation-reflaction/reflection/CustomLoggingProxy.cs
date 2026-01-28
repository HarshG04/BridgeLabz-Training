using System;
using System.Reflection;

interface IGreeting
{
    void SayHello();
}

class Greeting : IGreeting
{
    public void SayHello() => Console.WriteLine("Hello!");
}

class LogProxy<T> : DispatchProxy
{
    public T Target;

    protected override object Invoke(MethodInfo method, object[] args)
    {
        Console.WriteLine("Calling Method: " + method.Name);
        return method.Invoke(Target, args);
    }
}

class Program
{
    static void Main()
    {
        IGreeting proxy = DispatchProxy.Create<IGreeting, LogProxy<IGreeting>>();
        ((LogProxy<IGreeting>)proxy).Target = new Greeting();

        proxy.SayHello();
    }
}
