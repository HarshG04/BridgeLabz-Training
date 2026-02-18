using System;
using TechVille.Interface;

namespace TechVille.Modules
{
    public class Service : IService
    {
        private static int TotalServices = 0;
        public string ServiceName {get; protected set;}
        public double ServiceFee {get; protected set;}
        public bool IsRegistered {get; protected set;}

        public Service(string name, double fee)
        {
            this.ServiceName = name;
            this.ServiceFee = fee;
            this.IsRegistered = false;

            TotalServices++;
        }

        // Register
        public virtual void Register()
        {
            IsRegistered = true;
            Console.WriteLine($"{ServiceName} registered successfully.");
        }
        
        // Cancellation
        public virtual void Cancel()
        {
            IsRegistered = false;
            Console.WriteLine($"{ServiceName} cancelled successfully.");
        }

        // Status Check
        public virtual void CheckStatus()
        {
            Console.WriteLine(IsRegistered
                ? $"{ServiceName} is currently active."
                : $"{ServiceName} is not active.");
        }

        public override string ToString()
        {
            return $"Service: {ServiceName}, Fee: {ServiceFee}, Active: {IsRegistered}";
        }
        
        public static void DisplayTotalServices()
        {
            Console.WriteLine($"Total Services Created: {TotalServices}");
        }
    }
}