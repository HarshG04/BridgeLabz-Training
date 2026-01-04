using System;

public class Person
{
    public string name;
    public int age;
}

public class Teacher : Person
{
    public string subject;
    public void DisplayRole()
    {
        Console.WriteLine($"Teacher - Name: {name}, Age: {age}, Subject: {subject}");
    }
}

public class Student : Person
{
    public string grade;
    public void DisplayRole()
    {
        Console.WriteLine($"Student - Name: {name}, Age: {age}, Grade: {grade}");
    }
}

public class Staff : Person
{
    public string role;
    public void DisplayRole()
    {
        Console.WriteLine($"Staff - Name: {name}, Age: {age}, Role: {role}");
    }
}

public class Program
{
    public static void Main()
    {
        Teacher teacher = new Teacher { name = "harsh", age = 34, subject = "Math" };
        Student student = new Student { name = "aditya", age = 16, grade = "10" };
        Staff staff = new Staff { name = "aryan", age = 45, role = "Librarian" };
        teacher.DisplayRole();
        student.DisplayRole();
        staff.DisplayRole();
    }
}
