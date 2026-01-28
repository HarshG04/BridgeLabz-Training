using System;

namespace HealthCheckPro
{
    public class HealthCheckMenu
    {
        private IHealthCheck utility;

        public HealthCheckMenu()
        {
            utility = new HealthCheckUtilityImpl();
        }

        public void ShowMenu()
        {
            Console.WriteLine("=== HealthCheckPro API Validator ===");
            Console.WriteLine("1. Scan LabTest Controller");
            Console.WriteLine("0. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    utility.ScanController(typeof(LabTestController));
                    break;
                case 0:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
