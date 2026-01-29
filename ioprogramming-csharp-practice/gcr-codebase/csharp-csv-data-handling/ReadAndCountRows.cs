using System;
using System.IO;

class Program
{
    static void Main()
    {
        string studentsFile = "students.csv";

        if (File.Exists(studentsFile))
        {
            string[] students = File.ReadAllLines(studentsFile);
            int count = students.Length - 1;

            Console.WriteLine("Total Records (excluding header): " + count);
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
