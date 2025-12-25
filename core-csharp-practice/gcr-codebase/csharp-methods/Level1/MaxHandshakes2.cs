using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter Number of Students : ");
        int numberOfStudents = Convert.ToInt32(Console.ReadLine());

        int max = MaxHandshakes(numberOfStudents);
        Console.WriteLine($"No of max handshakes : {max}");
    }

    static int MaxHandshakes(int n)
    {
        int max = (n*(n-1))/2;
        return max;
    }
}