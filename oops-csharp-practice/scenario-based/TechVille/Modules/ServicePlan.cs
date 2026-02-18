using System;

namespace TechVille
{
    public class ServicePlan
    {
        public string PlanName {get;}
        public double Fee {get;}
        
        public ServicePlan(string name, double fee)
        {
            this.PlanName = name;
            this.Fee = fee;
        }

        public static readonly ServicePlan Basic = new ServicePlan("Basic", 500);

        public static readonly ServicePlan Premium = new ServicePlan("Premium", 1500);
    }
}