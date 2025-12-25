using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] marks = GenerateMarks(n);
        double[,] results = CalculateResults(marks);

        DisplayScoreCard(marks, results);
    }

    static int[,] GenerateMarks(int n)
    {
        int[,] m = new int[n, 3];   // 0 = Phy, 1 = Chem, 2 = Math
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            m[i, 0] = rnd.Next(10, 100);  // Physics
            m[i, 1] = rnd.Next(10, 100);  // Chemistry
            m[i, 2] = rnd.Next(10, 100);  // Maths
        }

        return m;
    }

    static double[,] CalculateResults(int[,] marks)
    {
        int n = marks.GetLength(0);
        double[,] res = new double[n, 3];   // 0 = total, 1 = avg, 2 = percentage

        for (int i = 0; i < n; i++)
        {
            double total = marks[i, 0] + marks[i, 1] + marks[i, 2];
            double avg = total / 3.0;
            double percent = (total / 300.0) * 100;

            res[i, 0] = Math.Round(total, 2);
            res[i, 1] = Math.Round(avg, 2);
            res[i, 2] = Math.Round(percent, 2);
        }

        return res;
    }

   static void DisplayScoreCard(int[,] marks, double[,] results)
    {
        int n = marks.GetLength(0);

        Console.WriteLine("\nScore Card:\n");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Student " + (i + 1) +" -> Physics: " + marks[i, 0] +" Chemistry: " + marks[i, 1] +" Maths: " + marks[i, 2] +" Total: " + results[i, 0] +" Average: " + results[i, 1] +" Percentage: " + results[i, 2]);
        }
    }
}
