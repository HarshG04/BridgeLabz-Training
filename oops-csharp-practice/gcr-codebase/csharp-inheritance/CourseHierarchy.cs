using System;

public class Course
{
    public string courseName;
    public int duration;
    public virtual void Display()
    {
        Console.WriteLine($"CourseName: {courseName}, Duration: {duration}");
    }
}

public class OnlineCourse : Course
{
    public string platform;
    public bool isRecorded;
    public override void Display()
    {
        Console.WriteLine($"CourseName: {courseName}, Duration: {duration}, Platform: {platform}, IsRecorded: {isRecorded}");
    }
}

public class PaidOnlineCourse : OnlineCourse
{
    public double fee;
    public double discount;
    public override void Display()
    {
        Console.WriteLine($"CourseName: {courseName}, Duration: {duration}, Platform: {platform}, IsRecorded: {isRecorded}, Fee: {fee}, Discount: {discount}");
    }
}

public class Program
{
    public static void Main()
    {
        PaidOnlineCourse paid = new PaidOnlineCourse { courseName = "Advanced C#", duration = 30, platform = "MyPlatform", isRecorded = true, fee = 199.99, discount = 20 };
        paid.Display();
    }
}
