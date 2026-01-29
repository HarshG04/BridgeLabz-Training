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

            for (int i = 1; i < students.Length; i++)
            {
                string[] student = students[i].Split(',');

                Console.WriteLine("ID: " + student[0]);
                Console.WriteLine("Name: " + student[1]);
                Console.WriteLine("Age: " + student[2]);
                Console.WriteLine("Marks: " + student[3]);
                Console.WriteLine("----------------------");
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
