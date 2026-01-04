using System;

class Student
{
    public static string universityName = "GLAU";
    private static int totalStudents = 0;

    public string name;
    public readonly int rollNumber;
    public string grade;

    public Student(string name, int rollNumber, string grade)
    {
        this.name = name;
        this.rollNumber = rollNumber;
        this.grade = grade;
        totalStudents++;
    }

    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Students: " + totalStudents);
    }

    public static void ShowStudentDetails(object obj)
    {
        if (obj is Student s)
        {
            Console.WriteLine("\nStudent Details");
            Console.WriteLine("University: " + universityName);
            Console.WriteLine("Name: " + s.name);
            Console.WriteLine("Roll Number: " + s.rollNumber);
            Console.WriteLine("Grade: " + s.grade);
        }
        else
        {
            Console.WriteLine("Object is not a Student");
        }
    }

    public static void UpdateGrade(object obj, string newGrade)
    {
        if (obj is Student s)
        {
            s.grade = newGrade;
            Console.WriteLine("Grade updated for " + s.name);
        }
        else
        {
            Console.WriteLine("Object is not a Student");
        }
    }
}

class Program
{
    static void Main()
    {
        Student s1 = new Student("Harsh", 101, "A");
        Student s2 = new Student("Aditya", 102, "B");

        Student.ShowStudentDetails(s1);
        Student.ShowStudentDetails(s2);

        Student.DisplayTotalStudents();

        Student.UpdateGrade(s2, "A+");
        Student.ShowStudentDetails(s2);

        Student.ShowStudentDetails("Hello");
    }
}
