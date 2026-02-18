using System;
using TechVille.Modules;

namespace TechVille.Services
{
    public class HealthCareService : Service
    {
        public HealthCareService() : base("HealthCare Service", 500)
        {
            
        }

        public void BookAppointment()
        {
            Console.WriteLine("Healthcare appointment booked successfully.");
        }
    }
}