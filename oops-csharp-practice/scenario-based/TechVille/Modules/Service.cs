using System;

namespace TechVille.Modules
{
    public class Service
    {
        private static int TotalServices = 0;
        public string ServiceName {get; protected set;}
        public double ServiceFee {get; protected set;}

        public Service(string name, double fee)
        {
            this.ServiceName = name;
            this.ServiceFee = fee;

            TotalServices++;
        }

        public virtual void DisplayServiceInfo()
        {
            Console.WriteLine($"Service: {ServiceName}, Fee: {ServiceFee}");
        }

        public static void DisplayTotalServices()
        {
            Console.WriteLine($"Total Services Created: {TotalServices}");
        }
    }
}