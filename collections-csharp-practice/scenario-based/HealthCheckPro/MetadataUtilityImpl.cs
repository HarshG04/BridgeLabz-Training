using System;
using System.Reflection;

namespace HealthCheckPro
{
    public class HealthCheckUtilityImpl : IHealthCheck
    {
        public void ScanController(Type type)
        {
            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            Console.WriteLine($"\nScanning Controller: {type.Name}\n");

            foreach (var m in methods)
            {
                Console.WriteLine($"Method: {m.Name}");

                var publicTag = m.GetCustomAttribute<PublicAPIAttribute>();
                var authTag = m.GetCustomAttribute<RequiresAuthAttribute>();

                if (publicTag != null)
                {
                    Console.WriteLine("  Type: Public API");
                    Console.WriteLine($"  Description: {publicTag.Description}");
                }

                if (authTag != null)
                {
                    Console.WriteLine("  Type: Requires Auth");
                    Console.WriteLine($"  Role: {authTag.Role}");
                }

                if (publicTag == null && authTag == null)
                {
                    Console.WriteLine("  WARNING: No metadata found!");
                }

                Console.WriteLine("----------------------");
            }
        }
    }
}
