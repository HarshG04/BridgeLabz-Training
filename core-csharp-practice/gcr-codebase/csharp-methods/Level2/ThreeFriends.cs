using System;


class AgeAndHeight
    {
    static void Main()
    {
        string[] names = { "Amar", "Akbar", "Anthony" };
        int[] age = new int[3];
        int[] height = new int[3];


        Console.WriteLine("Enter 3 age and height : ");
        for(int i = 0; i < 3; i++)
        {
            Console.Write($"Enter age and Height of {names[i]} : ");
            age[i] = Convert.ToInt32(Console.ReadLine());
            height[i] = Convert.ToInt32(Console.ReadLine());
        }

        int youngest = FindYoungest(age);
        int tallest = FindTallest(height);

        Console.WriteLine($"The Youngest Friend is : {names[youngest]}\n" +
            $"The Tallest Friend is : {names[tallest]}");

    }

    static int FindYoungest(int[] age)
    {
        int young = 0;
        for(int i = 1; i < 3; i++)
        {
            if (age[i] < age[young]) young = i;
        }
        return young;
    }

    static int FindTallest(int[] height)
    {
        int tallest = 0;
        for (int i = 1; i < 3; i++)
        {
            if (height[i] > height[tallest]) tallest = i;
        }
        return tallest;
    }
}
