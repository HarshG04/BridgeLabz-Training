using System;

class TemperatureAnalyzer
{
    private float[,] readings = new float[7, 24];
    private Random random = new Random();

    public void GenerateAndAnalyze()
    {
        Console.WriteLine("\nGenerating random temperatures (0–100)...\n");

        for (int d = 0; d < 7; d++)
        {
            for (int h = 0; h < 24; h++)
                readings[d, h] = random.Next(0, 101);   // 0–100
        }

        Analyze();
    }

    private void Analyze()
    {
        float hottest = float.MinValue;
        float coldest = float.MaxValue;
        int hotDay = 0, coldDay = 0;

        Console.WriteLine("Average Temperature Per Day:");

        for (int d = 0; d < 7; d++)
        {
            float sum = 0;

            for (int h = 0; h < 24; h++)
            {
                float t = readings[d, h];
                sum += t;

                if (t > hottest) { hottest = t; hotDay = d; }
                if (t < coldest) { coldest = t; coldDay = d; }
            }

            Console.WriteLine($"Day {d + 1}: {sum / 24f:F2}");
        }

        Console.WriteLine($"\nHottest Temp : {hottest} on Day {hotDay + 1}");
        Console.WriteLine($"Coldest Temp : {coldest} on Day {coldDay + 1}");
    }
}



class StudentScoresManager
{
    private double[] scores;
    private Random rand = new Random();

    public void GenerateAndAnalyze()
    {
        Console.Write("\nEnter number of students: ");

        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            Console.Write("Invalid! Enter a positive number: ");

        scores = new double[n];

        Console.WriteLine("\nGenerating random scores (0–100)...");

        for (int i = 0; i < n; i++)
            scores[i] = rand.Next(0, 101);   // 0–100

        Analyze();
    }

    private void Analyze()
    {
        double sum = 0, max = scores[0], min = scores[0];

        foreach (double s in scores)
        {
            sum += s;
            if (s > max) max = s;
            if (s < min) min = s;
        }

        double avg = sum / scores.Length;

        Console.WriteLine($"\nAverage Score = {avg:F2}");
        Console.WriteLine($"Highest Score = {max}");
        Console.WriteLine($"Lowest Score  = {min}");

        Console.WriteLine("\nScores above average:");
        foreach (double s in scores)
            if (s > avg)
                Console.WriteLine(s);
    }
}



class Program
{
    static void Main()
    {
        TemperatureAnalyzer tempTool = new TemperatureAnalyzer();
        StudentScoresManager scoreTool = new StudentScoresManager();

        while (true)
        {
            Console.WriteLine("\n==== MAIN MENU ====");
            Console.WriteLine("1. Temperature Analyzer (Random Data)");
            Console.WriteLine("2. Student Score Manager (Random Data)");
            Console.WriteLine("3. Exit");
            Console.Write("Select option: ");

            int ch;
            if (!int.TryParse(Console.ReadLine(), out ch)) 
                continue;

            if (ch == 1)
                tempTool.GenerateAndAnalyze();
            else if (ch == 2)
                scoreTool.GenerateAndAnalyze();
            else
                break;
        }

        Console.WriteLine("\nProgram Ended.");
    }
}
