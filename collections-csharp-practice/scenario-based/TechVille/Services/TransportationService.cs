using System;
using TechVille.Modules;

namespace TechVille
{
    public class TransportationService : Service
    {
        public string VehicleType { get; private set; }

        public TransportationService(string vehicleType)
            : base("Transportation Service", 300)
        {
            this.VehicleType = vehicleType;
        }

        public override void Register()
        {
            base.Register();
            Console.WriteLine($"Vehicle Type: {VehicleType} assigned.");
        }

        public override string ToString()
        {
            return base.ToString() + $", Vehicle: {VehicleType}";
        }

    }
}