using System;
using TechVille.Modules;

namespace TechVille
{
    public class EducationService : Service
    {
        public EducationService() : base("Education Service", 1000)
        {
            
        }

        public override void ProcessService()
        {
            Console.WriteLine("Processing education enrollment...");
        }

        public void EnrollCourse()
        {
            Console.WriteLine("Course enrolled successfully.");
        }
    }
}