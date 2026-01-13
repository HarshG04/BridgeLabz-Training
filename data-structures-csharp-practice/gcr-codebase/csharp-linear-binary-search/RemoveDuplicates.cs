using System.Text;

class RemoveDuplicates
{
    public static void Main(string[] args)
    {
        Console.Write("Enter String: ");
        string s = Console.ReadLine();

        StringBuilder sb = new StringBuilder();

        HashSet<char> set = new HashSet<char>();
        foreach(char ch in s)
        {
            if(!set.Contains(ch)){
                sb.Append(ch);
                set.Add(ch);
            }
        }
        

        Console.WriteLine(sb);
    }
}