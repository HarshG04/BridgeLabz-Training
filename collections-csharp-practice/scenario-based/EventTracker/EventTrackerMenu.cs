using System;

namespace EventTracker
{
    public class EventTrackerMenu
    {
        private IAuditScanner auditScanner;

        public EventTrackerMenu()
        {
            auditScanner = new AuditUtility();
        }

        public void ShowMenu()
        {
            Console.WriteLine("=== EventTracker Audit System ===");
            Console.WriteLine("1. Generate Audit Logs");
            Console.WriteLine("0. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    auditScanner.ScanAndGenerateLogs(typeof(UserActionController));
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
