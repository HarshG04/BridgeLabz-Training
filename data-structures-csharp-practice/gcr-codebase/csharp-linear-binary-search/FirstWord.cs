class FirstWord
{
    public static void Main(string[] args)
    {
        string[] arr = {"Hi","I","Am","Harsh","Goyal"};
        string key = "rsh";
        foreach(string s in arr)
        {
            if (s.Contains(key, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(s);
            }
        }
    }
}