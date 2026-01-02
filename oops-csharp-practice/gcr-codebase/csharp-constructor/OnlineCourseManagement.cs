class Course
{
    static string instituteName = "GLAU";
    string courseName;
    int duration;
    int fee;

    Course(string courseName,int dur,int fee)
    {
        this.courseName = courseName;
        this.duration = dur;
        this.fee = fee;
    }

    void DisplayCourseDetails()
    {
        Console.WriteLine(this.courseName);
        Console.WriteLine(this.duration);
        Console.WriteLine(this.fee);
    }
    static void UpdateInstituteName()
    {
        Console.WriteLine("New name");
        string name = Console.ReadLine();
        Course.instituteName = name;
        Console.WriteLine(Course.instituteName);
    }

    static void Main()
    {
        Course c1 = new Course("CSE",4,1200000);
        c1.DisplayCourseDetails();
        Course.UpdateInstituteName();
    }

}