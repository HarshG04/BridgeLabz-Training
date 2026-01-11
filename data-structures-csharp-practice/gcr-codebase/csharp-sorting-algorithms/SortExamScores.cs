using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] scores = new int[n];

        Console.WriteLine("Enter exam scores:");
        for (int i = 0; i < n; i++)
        {
            scores[i] = Convert.ToInt32(Console.ReadLine());
        }

        Program p = new Program();

        Console.WriteLine("Sorting exam scores...");
        p.SelectionSort(scores);

        Console.WriteLine("Sorted Exam Scores:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(scores[i]);
        }
    }

    public void SelectionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            int temp = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = temp;
        }
    }
}
