using System;
using TechVille.Modules;

namespace TechVille
{
    public class EducationService : Service
    {
        public EducationService() : base("Education Service", 1000)
        {
            
        }

        public override void Register()
        {
            base.Register();
            Console.WriteLine("Enrollment confirmed.");
        }

    }
}