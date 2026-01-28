using System;

class Student
{
    public string Name = "Harsh";
}

class Program
{
    static void Main()
    {
        Type t = typeof(Student);
        object obj = Activator.CreateInstance(t);

        Student s = (Student)obj;
        Console.WriteLine(s.Name);
    }
}
