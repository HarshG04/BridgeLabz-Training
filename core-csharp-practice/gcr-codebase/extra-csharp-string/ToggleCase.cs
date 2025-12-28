using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string s = Console.ReadLine();

        string result = "";

        foreach (char ch in s)
        {
            if (char.IsLower(ch))
                result += char.ToUpper(ch);
            else if (char.IsUpper(ch))
                result += char.ToLower(ch);
            else
                result += ch;
        }

        Console.WriteLine("Toggled string: " + result);
    }
}
