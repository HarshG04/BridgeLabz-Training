using System;

class Program
{
    static void Main()
    {   

        int[] age = new int[3];
        double[] height = new double[3];

        Console.WriteLine("Enter Height and Age : ");
        for(int i=0; i<3; i++)
        {
            age[i] = Convert.ToInt32(Console.ReadLine());
            height[i] = Convert.ToDouble(Console.ReadLine());
        }

        int y = 0;
        int t = 0;

        for (int i = 1; i < 3; i++)
        {
            if (age[i] < age[y]) y = i;
            if (height[i] > height[t]) t = i;
            Console.WriteLine(y +" " + t);
        }

        string[] names = {"Amar", "Akbar", "Anthony"};
        Console.WriteLine("Youngest: " + names[y]);
        Console.WriteLine("Tallest: " + names[t]);
    }
}