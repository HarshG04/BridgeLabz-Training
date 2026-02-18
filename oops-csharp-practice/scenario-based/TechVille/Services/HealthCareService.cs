using System;
using System.Numerics;
using TechVille.Modules;

namespace TechVille.Services
{
    public class HealthCareService : Service
    {
        public ServicePlan Plan {get; set;}
        public HealthCareService(ServicePlan plan) : base("HealthCare Service", plan.Fee)
        {
            this.Plan = plan;
        }

        public override void DisplayServiceInfo()
        {
            base.DisplayServiceInfo();
            Console.WriteLine($"Plan Type: {Plan.PlanName}");

            if (Plan == ServicePlan.Premium)
            {
                Console.WriteLine("Includes priority support and specialist access.");
            }
        }

        public void BookAppointment()
        {
            if (Plan == ServicePlan.Premium)
                Console.WriteLine("Priority appointment booked.");
            else
                Console.WriteLine("Standard appointment booked.");
        }
    }
}