using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] ages = new int[n];

        Console.WriteLine("Enter student ages (10 to 18):");
        for (int i = 0; i < n; i++)
        {
            ages[i] = Convert.ToInt32(Console.ReadLine());
        }

        Program p = new Program();
        p.CountingSort(ages);

        Console.WriteLine("Sorted Student Ages:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(ages[i]);
        }
    }

    public void CountingSort(int[] ages)
    {
        int min = 10;
        int max = 18;

        int[] count = new int[9];

        for (int i = 0; i < ages.Length; i++)
        {
            count[ages[i] - min]++;
        }

        int index = 0;
        for (int i = 0; i < count.Length; i++)
        {
            while (count[i] > 0)
            {
                ages[index++] = i + min;
                count[i]--;
            }
        }
    }
}
