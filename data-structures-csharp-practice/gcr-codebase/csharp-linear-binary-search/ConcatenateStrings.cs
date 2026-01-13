using System.Text;

class ConcatenateStrings
{
    public static void Main(string[] args)
    {
        string[] arr = {"Hi","I","Am","Harsh","Goyal"};
        StringBuilder sb = new StringBuilder();

        foreach(string s in arr)
        {
            sb.Append(s);
        }

        Console.WriteLine(sb);
    }
}