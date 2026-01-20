using System;
using System.Collections.Generic;

namespace ResumeScreeningSystem
{
    class ResumeUtility
    {
        private List<BaseResume> pipeline = new List<BaseResume>();

        public void AddResume<T>() where T : JobRole, new()
        {
            Resume<T> resume = new Resume<T>();

            Console.Write("Enter Candidate Name: ");
            resume.CandidateName = Console.ReadLine();

            Console.Write("Enter Years of Experience: ");
            resume.Experience = Convert.ToInt32(Console.ReadLine());

            pipeline.Add(resume);
            Console.WriteLine("Resume added to screening pipeline.");
        }

        public void ScreenResumes()
        {
            if (pipeline.Count == 0)
            {
                Console.WriteLine("No resumes to screen.");
                return;
            }

            Console.WriteLine("\n--- Screening Results ---");
            foreach (var r in pipeline)
            {
                string result = r.Experience >= r.Role.RequiredExperience()
                    ? "SHORTLISTED"
                    : "REJECTED";

                Console.WriteLine($"{r} → {result}");
            }
        }
    }
}
