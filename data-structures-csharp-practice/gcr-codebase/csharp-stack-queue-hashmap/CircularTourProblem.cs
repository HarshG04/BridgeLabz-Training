using System;

class CircularTour
{
    public static int FindStartingPump(int[] petrol, int[] distance)
    {
        int n = petrol.Length;

        int start = 0;
        int balance = 0;
        int deficit = 0;

        for (int i = 0; i < n; i++)
        {
            balance += petrol[i] - distance[i];

            if (balance < 0)
            {
                deficit += balance;
                start = i + 1;
                balance = 0;
            }
        }

        return (balance + deficit >= 0) ? start : -1;
    }

    static void Main()
    {
        int[] petrol = { 4, 6, 7, 4 };
        int[] distance = { 6, 5, 3, 5 };

        int start = FindStartingPump(petrol, distance);

        if (start == -1)
            Console.WriteLine("No circular tour possible.");
        else
            Console.WriteLine("Start at petrol pump index: " + start);
    }
}
