using System.Text;

class ReverseString
{
    public static void Main(string[] args)
    {
        Console.Write("Enter String: ");
        string s = Console.ReadLine();
        StringBuilder rev = new StringBuilder();
        for(int i = s.Length - 1; i >= 0; i--)
        {
            rev.Append(s[i]);
        }

        Console.WriteLine(rev);
        

    }
}