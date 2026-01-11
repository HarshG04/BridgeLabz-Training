using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the Number of Products: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] prices = new int[n];

        Console.WriteLine("Enter Product Prices: ");
        for (int i = 0; i < n; i++)
        {
            prices[i] = Convert.ToInt32(Console.ReadLine());
        }

        Program p = new Program();

        Console.WriteLine("Sorting Prices....");
        p.QuickSort(prices, 0, n - 1);

        Console.WriteLine("Sorted Product Prices: ");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(prices[i]);
        }
    }

    public void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);

            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }


    public int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    public void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
