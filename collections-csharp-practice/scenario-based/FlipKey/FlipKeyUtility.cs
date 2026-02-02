using System.Text;
using System.Text.RegularExpressions;

namespace FlipKey;

class FlipKeyUtility
{
    public void TakeInput()
    {
        Console.Write("Enter Input: ");
        string input = Console.ReadLine();
        
        string output = CleanseAndInvert(input);

        if(output.Equals(""))
        {
            Console.WriteLine("Invalid Input");
            return;
        }

        Console.WriteLine(output);
    }
    public string CleanseAndInvert(string input)
    {
        // string pattern = @"[0-9\W\s]";
        
        string pattern = @"^[a-zA-Z]{6,}$";

        if (!Regex.IsMatch(input, pattern))
        {
            return "";
        }

        StringBuilder sb = new StringBuilder(input.ToLower());
        for(int i = 0; i < sb.Length; i++)
        {
            if(sb[i]%2==0) {
                sb.Remove(i,1);
                i--;
            }
        }

        // Console.WriteLine("Sb: " + sb.ToString());

        StringBuilder rev = new StringBuilder();
        for(int i = sb.Length-1; i >= 0; i--)
        {
            if(i%2==0) rev.Append(sb[i].ToString().ToUpper());
            else rev.Append(sb[i]);
        }


        return rev.ToString();

    }
}