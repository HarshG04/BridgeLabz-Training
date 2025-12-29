using System;
using System.Text;

class SentenceFormatter
{
    string[] str = new string[500];
    int length = 0;
    string text = "";

    public void StringMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1: Enter Text\n2: Format Text\n3: Count Words\n4: Longest Word\n5: Replace Word\nOther: Exit");
            int n = Convert.ToInt32(Console.ReadLine());

            switch (n)
            {
                case 1:
                    Console.Write("Enter new text: ");
                    text = Console.ReadLine();
                    break;

                case 2:
                    FormateString();
                    break;

                case 3:
                    ConvertToStringArray();
                    NoOfWords();
                    break;

                case 4:
                    ConvertToStringArray();
                    LongestWord();
                    break;

                case 5:
                    Console.Write("Enter word to replace: ");
                    string a = Console.ReadLine();

                    Console.Write("Enter new word: ");
                    string b = Console.ReadLine();

                    Replace(a, b);
                    break;

                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    public void FormateString()
    {
        ConvertToStringArray();
        text = ArrayToString();
        Console.WriteLine(text);
    }

    void ConvertToStringArray()
    {
        int idx = 0;
        StringBuilder temp = new StringBuilder();
        string punction = ".,;:?!";

        int i = 0;

        while (i < text.Length && text[i] == ' ') i++;

        while (i < text.Length && idx < 500)
        {
            char ch = text[i];

            if (ch == ' ')
            {
                if (temp.Length > 0)
                {
                    str[idx++] = temp.ToString();
                    temp.Clear();
                }
                i++;
                continue;
            }

            if (punction.Contains(ch))
            {
                if (temp.Length > 0)
                {
                    str[idx++] = temp.ToString();
                    temp.Clear();
                }

                str[idx++] = ch.ToString();
            }
            else
                temp.Append(ch);

            i++;
        }

        if (temp.Length > 0)
            str[idx++] = temp.ToString();

        length = idx;
    }

    string ArrayToString()
    {
        StringBuilder sb = new StringBuilder();
        bool isPunct = true;

        for (int i = 0; i < length; i++)
        {
            string temp = str[i];

            bool endP = (temp == "." || temp == "?" || temp == "!");
            bool midP = (temp == "," || temp == ";" || temp == ":");

            if (endP)
            {
                sb.Append(temp);
                sb.Append(' ');
                isPunct = true;
            }
            else if (midP)
            {
                sb.Append(temp);
                sb.Append(' ');
            }
            else
            {
                if (isPunct && temp.Length > 0 &&
                    temp[0] >= 'a' && temp[0] <= 'z')
                {
                    char c = (char)(temp[0] - 'a' + 'A');
                    temp = c + (temp.Length > 1 ? temp.Substring(1) : "");
                }

                sb.Append(temp);

                if (i + 1 < length)
                {
                    string next = str[i + 1];
                    if (!(next == "." || next == "?" || next == "!" ||
                          next == "," || next == ";" || next == ":"))
                        sb.Append(' ');
                }

                isPunct = false;
            }
        }

        int end = sb.Length - 1;
        while (end >= 0 && sb[end] == ' ')
            end--;

        return sb.ToString(0, end + 1);
    }

    public void NoOfWords()
    {
        int count = 0;
        string punct = ".,;:?!";

        for (int i = 0; i < length; i++)
            if (!punct.Contains(str[i]))
                count++;

        Console.WriteLine(count);
    }

    public void LongestWord()
    {
        string ans = "";
        string punct = ".,;:?!";

        for (int i = 0; i < length; i++)
        {
            if (punct.Contains(str[i])) continue;
            if (ans.Length < str[i].Length)
                ans = str[i];
        }

        Console.WriteLine(ans);
    }

    public void Replace(string a, string b)
    {
        for (int i = 0; i < length; i++)
            if (str[i] == a)
                str[i] = b;

        text = ArrayToString();
        Console.WriteLine(text);
    }

    static void Main()
    {
        SentenceFormatter sf = new SentenceFormatter();
        sf.StringMenu();
    }
}
