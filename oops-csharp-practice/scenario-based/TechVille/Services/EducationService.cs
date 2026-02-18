using System;
using TechVille.Modules;

namespace TechVille
{
    public class EducationService : Service
    {
        public EducationService() : base("Education Service", 1000)
        {
            
        }

        public void EnrollCourse()
        {
            Console.WriteLine("Course enrolled successfully.");
        }
    }
}