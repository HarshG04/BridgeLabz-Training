class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the Number of Employees: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] id = new int[n];
        Console.WriteLine("Enter Marks: ");
        for(int i = 0; i < n; i++)
        {
            id[i] = Convert.ToInt32(Console.ReadLine());
        }

        Program p = new Program();
        
        Console.WriteLine("Sorting IDs....");
        p.InsertionSort(id);

        Console.WriteLine("Sorted Ids: ");
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine(id[i]);
        }
    }

    public void InsertionSort(int[] id)
    {
        for(int i = 1; i < id.Length; i++)
        {
            int key = id[i];
            int j = i-1;
            while(j>=0 && id[j] > key)
            {
                id[j+1] = id[j];
                j--;
            }
            id[j+1] = key;
        }
    }
    
}