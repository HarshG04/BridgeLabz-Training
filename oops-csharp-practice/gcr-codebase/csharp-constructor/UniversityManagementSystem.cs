using System;

class Student
{
    public int rollNumber;
    protected string name;
    private double CGPA;

    public Student(int rollNumber, string name, double cgpa)
    {
        this.rollNumber = rollNumber;
        this.name = name;
        this.CGPA = cgpa;
    }

    public double GetCGPA()
    {
        return CGPA;
    }

    public void SetCGPA(double cgpa)
    {
        CGPA = cgpa;
    }

    public void ShowStudent()
    {
        Console.WriteLine(rollNumber);
        Console.WriteLine(name);
        Console.WriteLine(CGPA);
    }
}

class Program
{
    static void Main()
    {
        Student s = new Student(1, "Harsh", 8.5);
        s.ShowStudent();
        s.SetCGPA(9.1);
        Console.WriteLine(s.GetCGPA());
    }
}