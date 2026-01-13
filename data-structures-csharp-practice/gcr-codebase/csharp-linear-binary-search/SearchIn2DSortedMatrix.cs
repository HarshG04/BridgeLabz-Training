class SearchIn2DSortedMatrix
{
    public static void Main(string[] args)
    {
       int[,] arr = {{ 1, 3, 5, 7 },{ 10, 11, 16, 20 },{ 23, 30, 34, 60 }};

        FindTarget(arr,16); 
    }
    public static void FindTarget(int[,] arr ,int target)
    {
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);


        bool found = false;
        for (int i = 0; i < rows; i++)
        {
            int left = 0;
            int right = cols - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[i, mid] == target)
                {
                    Console.WriteLine("Target found at row " + i + " column " + mid);
                    found = true;
                    break;
                }
                else if (arr[i, mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            if (found)
                break;
        }
        if (!found)
        {
            Console.WriteLine("Target not found");
        }
    }
}