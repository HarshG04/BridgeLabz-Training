// class Subject
// {
//     String Hindi;
//     String Maths;
//     String English;

//     public Subject(String Hindi,String Maths,String English)
//     {
//         t5his
//     }

// }
class Student
{

    public string name;
    public int age;
    public int totalMarks;


    
    private Student(string name,int age)
    {
        this.name = name;
        this.age = age;
    }

    public static Student AddNewStudent()
    {
        Console.WriteLine("Enter Student Name: ");
        string name = Console.WriteLine();
        Console.WriteLine("Enter Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Student s = new Student(name,age);

        Console.WriteLine("Enter Hindi Marks");
        int hMarks = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter english Marks");
        int eMarks = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter maths Marks");
        int mMarks = Convert.ToInt32(Console.ReadLine());

        for(int i = 0; i < subject.GetLength(0); i++)
        {
            Console.Write($"\nEnter {subject[i][0]} Marks");
            int marks = Convert.ToInt32(Console.ReadLine());
            s.subject[i,1] = marks;
        }
        s.totalMarks = hMarks+eMarks+mMarks;
        return s;
    }

    public void ShowStudentDetails()
    {
        Console.WriteLine("----Student-----");
        Console.WriteLine($"Student Name : {this.name}");
        Console.WriteLine($"Student Name : {this.age}");
        for(int i = 0; i < subject.GetLength(0); i++)
        {
            Console.WriteLine($"{subject[i,0]} : {subject[i,1]}");
        }
    }

    public void SortByMarks(Student student)
    {
        int n = student.Length();
        for(int i = 0; i < n; i++)
        {
            for(int j = i + 1; j < n; j++)
            {
                if (student[i].totalMarks < student[j].totalMarks)
                {
                    Student temp = student[i];
                    student[i] = student[j];
                    student[j] = temp;
                }
            }
        }
    }
}


class Program
{
    static void Main()
    {  
        Student[] students = new Student[3];
        for(int i = 0; i < students.Length; i++)
        {
            students[i] =  Student.AddNewStudent();
        }

    }
}

