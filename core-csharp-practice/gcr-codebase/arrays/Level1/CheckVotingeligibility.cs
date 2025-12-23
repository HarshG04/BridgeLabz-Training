using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter 10 ages");
        int[] ages = new int[10];
        for(int i=0;i<ages.Length;i++) ages[i] = Convert.ToInt32(Console.ReadLine());

        for(int i = 0; i < ages.Length; i++)
        {
            if(ages[i]<0) Console.WriteLine($"{ages[i]} Invalid Age");
            else if(ages[i]>=18) Console.WriteLine($"The student with the age {ages[i]} can vote");
            else Console.WriteLine($"The student with the age {ages[i]} cannot vote. ");
        }
    }
}