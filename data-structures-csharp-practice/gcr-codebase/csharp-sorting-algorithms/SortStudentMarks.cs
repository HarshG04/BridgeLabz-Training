class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the Number of Students: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] marks = new int[n];
        Console.WriteLine("Enter Marks: ");
        for(int i = 0; i < n; i++)
        {
            marks[i] = Convert.ToInt32(Console.ReadLine());
        }

        Program p = new Program();
        
        Console.WriteLine("Sorting Marks....");
        p.BubbleSort(marks);

        Console.WriteLine("Sorted Marks: ");
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine(marks[i]);
        }
    }

    public void BubbleSort(int[] marks)
    {
        for(int i = 0; i < marks.Length-1; i++)
        {
            bool isSort = false;
            for(int j = 0; j < marks.Length-1; j++)
            {
                if (marks[j + 1] < marks[j])
                {
                    int temp = marks[j];
                    marks[j] = marks[j+1];
                    marks[j+1] = temp;
                    isSort = true;
                }
            }

            if(!isSort) break;
        }
    }
    
}