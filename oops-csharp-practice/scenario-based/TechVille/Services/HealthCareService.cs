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

        // Method Overriding (Runtime Polymorphism)
        public override void ProcessService()
        {
            Console.WriteLine("Processing healthcare service...");
        }

        // Method Overloading (Compile-Time Polymorphism)
        public void ProcessService(string patientName)
        {
            Console.WriteLine($"Processing healthcare service for {patientName}...");
        }

        public override void DisplayServiceInfo()
        {
            base.DisplayServiceInfo();
            Console.WriteLine($"Plan Type: {Plan.PlanName}");
        }
    }
}