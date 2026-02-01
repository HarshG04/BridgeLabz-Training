using System;
using System.Text;

namespace LexicalTwist;
class LexicalTwistUtility
{
    private string s1;
    private string s2;

    public void TakeInput()
    {
        Console.Write("Enter The First Word: ");
        s1 = Console.ReadLine().Trim();

        if(s1.Contains(" "))
        {
            Console.Write($"{s1} is an invalid word");
            return;
        }
        Console.Write("Enter The Second Word: ");
        s2 = Console.ReadLine().Trim();

        if(s2.Contains(" "))
        {
            Console.Write($"{s2} is an invalid word");
            return;
        }



        CheckStrings();
        
    }

    private void CheckStrings()
    {
        if(s1.Length != s2.Length)
        {
            IfNotReversed();
            return;
        }

        string t1 = s1.ToLower();
        string t2 = s2.ToLower();

        int i=0, j=t2.Length-1;
        while(i<t1.Length)
        {
            if (!t1[i].Equals(t2[j]))
            {
                IfNotReversed();
                return;
            }
            i++; j--;
        }

        IfReversed();
    }

    public void IfReversed()
    {
        s1 = s2.ToLower();
        StringBuilder sb = new StringBuilder(s1);
        
        string vowels = "aeiou";
        for(int i = 0; i < sb.Length; i++)
        {
            if (vowels.Contains(sb[i]))
            {
                sb.Replace(sb[i],'@');
            }
        }

        Console.Write(sb.ToString());
    }

    public void IfNotReversed()
    {
        StringBuilder sb = new StringBuilder(s1.ToUpper()+s2.ToUpper());
        int vowelsCount = 0, consonantCount = 0;
        string vowels = "AEIOU";

        for(int i = 0; i < sb.Length; i++)
        {
            if(vowels.Contains(sb[i])) vowelsCount++;
            else consonantCount++;
        }

        HashSet<char> visited = new HashSet<char>();
        visited.Add(' ');
        int count = 0;
        if(vowelsCount > consonantCount)
        {
            for(int i = 0; i < sb.Length && count!=2; i++)
            {
                if(vowels.Contains(sb[i]) && !visited.Contains(sb[i])) 
                {
                   Console.Write(sb[i]);
                   visited.Add(sb[i]);
                   count++;
                }

            }
        }
        else if (consonantCount > vowelsCount)
        {
            for(int i = 0; i < sb.Length && count!=2; i++)
            {
                if(!vowels.Contains(sb[i]) && !visited.Contains(sb[i])) 
                {
                   Console.Write(sb[i]);
                   visited.Add(sb[i]);
                   count++;
                }

            }
        }
        else
        {
            Console.Write("Vowels and consonants are equal");
        }
    }
    


}