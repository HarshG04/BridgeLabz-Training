using System;
namespace TechVille
{
    class Program
    {
        /// <summary>
        /// Module 1 Summary:
        /// This module implements a basic citizen registration system for TechVille.
        /// It accepts single-user input such as name, age, income, and residency years.
        /// An eligibility score is calculated using arithmetic operators.
        /// Conditional statements are used to determine service eligibility.
        /// This module focuses on core programming concepts like variables, I/O, and operators.
        /// 
        /// Module 2 Summary:
        /// This module extends the citizen registration system to handle multiple
        /// family members using loops. It calculates eligibility scores and assigns
        /// service packages using conditional logic, switch statements, and control
        /// flow statements like break and continue.
        /// 
        /// </summary>
        static void Main(string[] args)
        {
           Console.Write("Enter Number of family members : ");
           int familyMembers = Convert.ToInt32(Console.ReadLine());

           for(int i = 1; i <= familyMembers; i++)
            {
                // Taking Citizen Data/Details From The User
                Console.WriteLine($"--- Member {i} Registration ---");

                Console.Write("Enter Name : ");
                string name = Console.ReadLine();

                Console.Write("Enter Age : ");
                int age = Convert.ToInt32(Console.ReadLine());

                if (age <= 0)
                {
                    Console.WriteLine("Invalid Age. Skipping This Member");
                    continue;
                }

                Console.Write("Enter Income : ");
                double income = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Residency Years : ");
                int years = Convert.ToInt32(Console.ReadLine());

                // Calculating Eligibility Score Based On Citizen Data.
                double eligibilityScore = (age*3)+(years*2)+(income/10000);

                // Ternary operator
                string status = (eligibilityScore >= 70) ? "Eligible" : "Not Eligible";

                // Nested if-else for service package
                string servicePackage;

                if (eligibilityScore >= 90)
                    servicePackage = "Platinum";
                else if (eligibilityScore >= 75)
                    servicePackage = "Gold";
                else if (eligibilityScore >= 60)
                    servicePackage = "Silver";
                else
                    servicePackage = "Basic";

                Console.WriteLine("\n--- Result ---");
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Eligibility Score: " + eligibilityScore);
                Console.WriteLine("Status: " + status);
                Console.WriteLine("Service Package: " + servicePackage);

                // switch statement usage
                switch (servicePackage)
                {
                    case "Platinum":
                        Console.WriteLine("Benefits: All city services + Priority support");
                        break;

                    case "Gold":
                        Console.WriteLine("Benefits: Most city services");
                        break;

                    case "Silver":
                        Console.WriteLine("Benefits: Basic city services");
                        break;

                    case "Basic":
                        Console.WriteLine("Benefits: Limited services");
                        break;

                    default:
                        Console.WriteLine("Invalid package");
                        break;
                }

                if(i==familyMembers) break;

                // break example
                Console.Write("Do you want to stop registration? (yes/no): ");
                string choice = Console.ReadLine();

                if (choice.ToLower() == "yes")
                {
                    Console.WriteLine("Registration stopped by user.");
                    break;
                }

                Console.WriteLine("\nThank you for using TechVille Service Portal.");
            }
        }
    }
}