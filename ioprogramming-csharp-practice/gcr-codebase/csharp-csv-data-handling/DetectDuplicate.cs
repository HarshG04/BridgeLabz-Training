using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string filePath = "students.csv";
        HashSet<string> ids = new HashSet<string>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                string id = data[0];

                if (ids.Contains(id))
                {
                    Console.WriteLine("Duplicate Record: " + lines[i]);
                }
                else
                {
                    ids.Add(id);
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
