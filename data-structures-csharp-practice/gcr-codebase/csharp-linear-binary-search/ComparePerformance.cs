using System.Diagnostics;
using System.Text;

class ComparePerformance
{
    public static void Main(string[] args)
    {
        Console.WriteLine("For String: ");
        string s = "";
        Stopwatch watch1 = new Stopwatch();

        watch1.Start();
        for(int i = 0; i < 50000; i++)
        {
            s += "harsh";
        }
        watch1.Stop();

        Console.WriteLine($"Time in ms: {watch1.ElapsedMilliseconds}");


        Console.WriteLine("\nFor StringBuilder: ");
        StringBuilder sb = new StringBuilder();
        Stopwatch watch2 = new Stopwatch();
        watch2.Start();
        for(int i = 0; i < 50000; i++)
        {
            sb.Append("harsh");
        }
        watch2.Stop();

        Console.WriteLine($"Time in ms: {watch2.ElapsedMilliseconds}");

    }
}