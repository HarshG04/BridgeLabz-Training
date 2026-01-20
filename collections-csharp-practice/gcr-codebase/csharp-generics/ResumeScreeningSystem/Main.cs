using System;

namespace ResumeScreeningSystem
{
    class Program
    {
        static void Main()
        {
            ResumeUtility utility = new ResumeUtility();

            while (true)
            {
                Console.WriteLine("\n--- AI Resume Screening System ---");
                Console.WriteLine("1. Add Software Engineer Resume");
                Console.WriteLine("2. Add Data Scientist Resume");
                Console.WriteLine("3. Screen Resumes");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        utility.AddResume<SoftwareEngineer>();
                        break;
                    case 2:
                        utility.AddResume<DataScientist>();
                        break;
                    case 3:
                        utility.ScreenResumes();
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
