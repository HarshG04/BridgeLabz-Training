using System.Diagnostics;
using System.Text;

class ComparePerformance
{
    public static void Main(string[] args)
    {
        Console.WriteLine("For String: ");
        string s = "";
        Stopwatch watch = new Stopwatch();

        watch.Start();
        for(int i = 0; i < 50000; i++)
        {
            s += "harsh";
        }
        watch.Stop();

        Console.WriteLine($"Time in ms: {watch.ElapsedMilliseconds} ms");

        watch.Reset();

        Console.WriteLine("\nFor StringBuilder: ");
        StringBuilder sb = new StringBuilder();
        
        watch.Start();
        for(int i = 0; i < 50000; i++)
        {
            sb.Append("harsh");
        }
        watch.Stop();

        Console.WriteLine($"Time in ms: {watch.ElapsedMilliseconds} ms");

    }
}