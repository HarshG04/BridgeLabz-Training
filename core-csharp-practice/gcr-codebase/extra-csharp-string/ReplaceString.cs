using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();

        Console.Write("Enter word to replace: ");
        string old = Console.ReadLine();

        Console.Write("Enter new word: ");
        string newWord = Console.ReadLine();

        string updated = ReplaceWord(str, old, newWord);

        Console.WriteLine("Updated sentence: " + updated);
    }

    static string ReplaceWord(string sentence, string oldWord, string newWord)
    {
        string[] words = sentence.Split(' ');
        string result = "";

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == oldWord) words[i] = newWord;

            result += words[i];

            if (i != words.Length - 1) result += " ";
        }

        return result;
    }
}
