using System;
using System.Diagnostics;

class SortingPerformanceComparison
{
    static void Main()
    {
        int n = 10000;

        int[] arr = GenerateArray(n);

        int[] bubbleArray = (int[])arr.Clone();
        int[] mergeArray = (int[])arr.Clone();
        int[] quickArray = (int[])arr.Clone();

        Stopwatch watch = new Stopwatch();

        // Bubble Sort
        watch.Start();
        BubbleSort(bubbleArray);
        watch.Stop();
        Console.WriteLine("Bubble Sort Time: " + watch.ElapsedMilliseconds + " ms");

        watch.Reset();

        // Merge Sort
        watch.Start();
        MergeSort(mergeArray, 0, n-1);
        watch.Stop();
        Console.WriteLine("Merge Sort Time: " + watch.ElapsedMilliseconds + " ms");

        watch.Reset();

        // Quick Sort
        watch.Start();
        QuickSort(quickArray, 0, n-1);
        watch.Stop();
        Console.WriteLine("Quick Sort Time: " + watch.ElapsedMilliseconds + " ms");
    }

    public static void BubbleSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    public static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    public static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++) L[i] = arr[left + i];

        for (int j = 0; j < n2; j++) R[j] = arr[mid + 1 + j];

        int idx = 0, jdx = 0;
        int k = left;

        while (idx < n1 && jdx < n2)
        {
            if (L[idx] <= R[jdx])
            {
                arr[k] = L[idx];
                idx++;
            }
            else
            {
                arr[k] = R[jdx];
                jdx++;
            }
            k++;
        }

        while (idx < n1)
        {
            arr[k] = L[idx];
            idx++;
            k++;
        }

        while (jdx < n2)
        {
            arr[k] = R[jdx];
            jdx++;
            k++;
        }
    }

    public static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);

            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    public static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;

        return i + 1;
    }

    public static int[] GenerateArray(int size)
    {
        int[] arr = new int[size];
        Random rnd = new Random();

        for (int i = 0; i < size; i++)
        {
            arr[i] = rnd.Next(1, size);
        }

        return arr;
    }
}
