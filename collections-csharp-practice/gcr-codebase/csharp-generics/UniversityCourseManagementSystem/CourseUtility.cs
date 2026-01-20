using System;
using System.Collections.Generic;

namespace UniversityCourseManagement
{
    class CourseUtility
    {
        private List<BaseCourse> courses = new List<BaseCourse>();

        public void AddExamCourse()
        {
            Course<ExamCourse> course = new Course<ExamCourse>();

            Console.Write("Enter Course Name: ");
            course.CourseName = Console.ReadLine();

            Console.Write("Enter Department: ");
            course.Department = Console.ReadLine();

            course.EvaluationType = new ExamCourse();

            courses.Add(course);
            Console.WriteLine("Exam course added.");
        }

        public void AddAssignmentCourse()
        {
            Course<AssignmentCourse> course = new Course<AssignmentCourse>();

            Console.Write("Enter Course Name: ");
            course.CourseName = Console.ReadLine();

            Console.Write("Enter Department: ");
            course.Department = Console.ReadLine();

            course.EvaluationType = new AssignmentCourse();

            courses.Add(course);
            Console.WriteLine("Assignment course added.");
        }

        public void ViewCourses()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses available.");
                return;
            }

            foreach (var c in courses)
                Console.WriteLine(c);
        }
    }
}
