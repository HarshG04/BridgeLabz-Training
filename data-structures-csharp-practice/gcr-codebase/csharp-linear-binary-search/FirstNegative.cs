class FirstNegative
{
    public static void Main(string[] args)
    {
        int[] arr = {1,5,3,5,2,-10,5,88,0,-9,55};
        foreach(int i in arr)
        {
            if(i<0)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}