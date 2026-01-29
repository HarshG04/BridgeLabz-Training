using System;
using System.IO;
using System.Collections.Generic;

class Student
{
    public int Id;
    public string Name;
    public int Age;
    public int Marks;

    public Student(int id, string name, int age, int marks)
    {
        Id = id;
        Name = name;
        Age = age;
        Marks = marks;
    }

    public void Display()
    {
        Console.WriteLine(Id + " " + Name + " " + Age + " " + Marks);
    }
}

class Program
{
    static void Main()
    {
        string studentsFile = "students.csv";
        List<Student> students = new List<Student>();

        if (File.Exists(studentsFile))
        {
            string[] students = File.ReadAllLines(studentsFile);

            for (int i = 1; i < students.Length; i++)
            {
                string[] data = students[i].Split(',');

                Student s = new Student(
                    int.Parse(data[0]),
                    data[1],
                    int.Parse(data[2]),
                    int.Parse(data[3])
                );

                studentsFile.Add(s);
            }

            foreach (Student s in studentsFile)
            {
                s.Display();
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
