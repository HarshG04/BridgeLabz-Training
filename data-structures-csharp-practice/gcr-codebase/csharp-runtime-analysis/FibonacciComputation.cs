using System.Diagnostics;

class Program
{
    public static void Main(string[] args)
    {
        int n = 35;
        Stopwatch watch = new Stopwatch();

        watch.Start();
        RecursiveFibo(n);
        watch.Stop();

        Console.WriteLine($"Recursive Approach Time : {watch.ElapsedMilliseconds} ms");

        watch.Reset();

        watch.Start();
        IterativeFibo(n);
        watch.Stop();

        Console.WriteLine($"Iterative Approach Time : {watch.ElapsedMilliseconds} ms");
    }

    public static int RecursiveFibo(int n)
    {  
        if (n <= 1) return n;
        return RecursiveFibo(n-1) + RecursiveFibo(n-2);
    
    }

    public static int IterativeFibo(int n)
    {  
        int a = 0, b = 1;
        int sum=0;
        for (int i = 2; i <= n; i++) {
            sum = a + b;
            a = b;
            b = sum;
        }
        return b;

    }
}