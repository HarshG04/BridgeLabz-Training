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

        public override void Register()
        {
            base.Register();

            if (Plan == ServicePlan.Premium)
                Console.WriteLine("Priority healthcare activated.");
        }

        public override string ToString()
        {
            return base.ToString() + $", Plan: {Plan.PlanName}";
        }
    }
}