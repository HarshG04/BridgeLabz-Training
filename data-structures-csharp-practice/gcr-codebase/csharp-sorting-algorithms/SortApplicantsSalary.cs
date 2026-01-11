using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter number of job applicants: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] salaries = new int[n];

        Console.WriteLine("Enter expected salary demands:");
        for (int i = 0; i < n; i++)
        {
            salaries[i] = Convert.ToInt32(Console.ReadLine());
        }

        Program p = new Program();

        Console.WriteLine("Sorting salary demands...");
        p.HeapSort(salaries);

        Console.WriteLine("Sorted Salary Demands:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(salaries[i]);
        }
    }

    public void HeapSort(int[] arr)
    {
        int n = arr.Length;


        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }


        for (int i = n - 1; i > 0; i--)
        {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            Heapify(arr, i, 0);
        }
    }

    public void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left] > arr[largest])
            largest = left;

        if (right < n && arr[right] > arr[largest])
            largest = right;

        if (largest != i)
        {
            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;

            Heapify(arr, n, largest);
        }
    }
}
