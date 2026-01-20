using System;

namespace UniversityCourseManagement
{
    class Program
    {
        static void Main()
        {
            CourseUtility utility = new CourseUtility();

            while (true)
            {
                Console.WriteLine("\n--- University Course Management ---");
                Console.WriteLine("1. Add Exam Course");
                Console.WriteLine("2. Add Assignment Course");
                Console.WriteLine("3. View All Courses");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        utility.AddExamCourse();
                        break;
                    case 2:
                        utility.AddAssignmentCourse();
                        break;
                    case 3:
                        utility.ViewCourses();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
