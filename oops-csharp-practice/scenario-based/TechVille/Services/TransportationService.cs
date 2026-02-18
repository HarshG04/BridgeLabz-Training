using System;
using TechVille.Modules;

namespace TechVille
{
    public class TransportationService : Service
    {
        public TransportationService() : base("Transportation Service", 300)
        {
            
        }

        public override void ProcessService()
        {
            Console.WriteLine("Processing Transport Service");
        }

    }
}