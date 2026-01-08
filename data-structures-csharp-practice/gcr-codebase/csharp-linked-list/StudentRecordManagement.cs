using System;

class Student
{
    public int rollNumber;
    public string name;
    public int age;
    public double grade;

    public Student next;

    public Student(int rollNumber, string name, int age, double grade)
    {
        this.rollNumber = rollNumber;
        this.name = name;
        this.age = age;
        this.grade = grade;
        this.next = null;
    }
}

class StudentList
{
    private Student head;
    private Student curr;   // tail pointer

    public void AddNewStudent()
    {
        Console.Write("Enter Roll Number: ");
        int roll = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Grade Marks: ");
        double grade = Convert.ToDouble(Console.ReadLine());

        Student newStudent = new Student(roll, name, age, grade);

        if (head == null)
        {
            head = newStudent;
            curr = newStudent;
            Console.WriteLine("Student added.");
            return;
        }

        curr.next = newStudent;
        curr = newStudent;

        Console.WriteLine("Student added.");
    }

    public void DeleteByRoll()
    {
        Console.Write("Enter Roll Number: ");
        int rollNumber = Convert.ToInt32(Console.ReadLine());

        if (head == null)
        {
            Console.WriteLine("No records found.");
            return;
        }

        if (head.rollNumber == rollNumber)
        {
            head = head.next;
            Console.WriteLine("Record deleted.");
            return;
        }

        Student temp = head;

        while (temp.next != null && temp.next.rollNumber != rollNumber)
            temp = temp.next;

        if (temp.next == null)
        {
            Console.WriteLine("Record not found.");
            return;
        }

        temp.next = temp.next.next;
        Console.WriteLine("Record deleted.");
    }

    public void Search()
    {
        Console.Write("Enter Roll Number: ");
        int rollNumber = Convert.ToInt32(Console.ReadLine());

        Student temp = head;

        while (temp != null)
        {
            if (temp.rollNumber == rollNumber)
            {
                Console.WriteLine($"Found → Roll: {temp.rollNumber}, Name: {temp.name}, Age: {temp.age}, Grade: {temp.grade}");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Record not found.");
    }

    public void UpdateGrade()
    {
        Console.Write("Enter Roll Number: ");
        int rollNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New Grade Marks: ");
        double newGrade = Convert.ToDouble(Console.ReadLine());

        Student temp = head;

        while (temp != null)
        {
            if (temp.rollNumber == rollNumber)
            {
                temp.grade = newGrade;
                Console.WriteLine("Grade updated.");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Record not found.");
    }

    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("No student records found.");
            return;
        }

        Student temp = head;

        Console.WriteLine("\n===== Student Records =====");
        while (temp != null)
        {
            Console.WriteLine($"Roll: {temp.rollNumber}, Name: {temp.name}, Age: {temp.age}, Grade: {temp.grade}");
            temp = temp.next;
        }
    }
}

class Program
{
    static void Main()
    {
        StudentList students = new StudentList();

        while (true)
        {
            Console.WriteLine("\n==== Student Menu ====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Delete Student");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Grade");
            Console.WriteLine("5. Display All");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 6) break;

            switch (choice)
            {
                case 1:
                    students.AddNewStudent();
                    break;

                case 2:
                    students.DeleteByRoll();
                    break;

                case 3:
                    students.Search();
                    break;

                case 4:
                    students.UpdateGrade();
                    break;

                case 5:
                    students.DisplayAll();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
