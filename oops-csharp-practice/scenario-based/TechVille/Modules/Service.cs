using System;

namespace TechVille.Modules
{
    public class Service
    {
        public string ServiceName {get; protected set;}
        public double ServiceFee {get; protected set;}

        public Service(string name, double fee)
        {
            this.ServiceName = name;
            this.ServiceFee = fee;
        }

        public virtual void DisplayServiceInfo()
        {
            Console.WriteLine($"Service: {ServiceName}, Fee: {ServiceFee}");
        }
    }
}