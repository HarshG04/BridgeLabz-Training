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

            Console.WriteLine("Students scoring more than 80:\n");

            for (int i = 1; i < students.Length; i++)
            {
                string[] student = students[i].Split(',');
                int marks = int.Parse(student[3]);

                if (marks > 80)
                {
                    Console.WriteLine("ID: " + student[0] + ", Name: " + student[1] + ", Age: " + student[2] + ", Marks: " + student[3]);
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
