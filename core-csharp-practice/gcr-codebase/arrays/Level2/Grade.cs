using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] marks = new int[n, 3];   // [][0]=Physics, [][1]=Chemistry, [][2]=Maths
        double[] perc = new double[n];
        char[] grade = new char[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter marks for student {i + 1}:");

            int p = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());

            if (p < 0 || c < 0 || m < 0)
            {
                Console.WriteLine("Invalid marks. Enter positive values.");
                i--;
                continue;
            }

            marks[i, 0] = p;
            marks[i, 1] = c;
            marks[i, 2] = m;
        }

        for (int i = 0; i < n; i++)
        {
            int total = marks[i, 0] + marks[i, 1] + marks[i, 2];
            perc[i] = total / 3.0;

            if (perc[i] >= 80) grade[i] = 'A';
            else if (perc[i] >= 70) grade[i] = 'B';
            else if (perc[i] >= 60) grade[i] = 'C';
            else if (perc[i] >= 50) grade[i] = 'D';
            else if (perc[i] >= 40) grade[i] = 'E';
            else grade[i] = 'R';
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Physics: {marks[i,0]}  Chemistry: {marks[i,1]}  Maths: {marks[i,2]}  " +$"Percentage: {perc[i]:F2}%  Grade: {grade[i]}");
        }
    }
}
