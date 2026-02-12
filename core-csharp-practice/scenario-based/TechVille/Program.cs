using System;
using System.Runtime.InteropServices;
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
        /// Module 3 Summary:
        /// This module focuses on efficient storage and management of large-scale citizen data
        /// using arrays. A one-dimensional array is used to store citizen IDs, while a jagged
        /// array represents five city zones with varying numbers of sectors. Basic array
        /// operations such as sorting, searching, and traversal are demonstrated.
        /// 
        /// Module 4 Summary:
        /// This module focuses on citizen profile management using strings and reusable methods.
        /// It demonstrates string manipulation, email validation, string-based search, and
        /// explains the difference between pass-by-value and pass-by-reference in C#.
        /// 
        /// Module 5 Summary:
        /// This module implements exception handling to build a robust registration system.
        /// It uses try-catch-finally blocks and custom exceptions to handle invalid input
        /// gracefully and prevent application crashes.
        /// </summary>
        /// 
        
        class InvalidAgeException : Exception
        {
            public InvalidAgeException(string message) : base(message)
            {
            }
        }
        // Module - 2
        // static void Main(string[] args)
        // {
        //    Console.Write("Enter Number of family members : ");
        //    int familyMembers = Convert.ToInt32(Console.ReadLine());

        //    for(int i = 1; i <= familyMembers; i++)
        //     {
        //         // Taking Citizen Data/Details From The User
        //         Console.WriteLine($"--- Member {i} Registration ---");

        //         Console.Write("Enter Name : ");
        //         string name = Console.ReadLine();

        //         Console.Write("Enter Age : ");
        //         int age = Convert.ToInt32(Console.ReadLine());

        //         if (age <= 0)
        //         {
        //             Console.WriteLine("Invalid Age. Skipping This Member");
        //             continue;
        //         }

        //         Console.Write("Enter Income : ");
        //         double income = Convert.ToDouble(Console.ReadLine());

        //         Console.Write("Enter Residency Years : ");
        //         int years = Convert.ToInt32(Console.ReadLine());

        //         // Calculating Eligibility Score Based On Citizen Data.
        //         double eligibilityScore = (age*3)+(years*2)+(income/10000);

        //         // Ternary operator
        //         string status = (eligibilityScore >= 70) ? "Eligible" : "Not Eligible";

        //         // Nested if-else for service package
        //         string servicePackage;

        //         if (eligibilityScore >= 90)
        //             servicePackage = "Platinum";
        //         else if (eligibilityScore >= 75)
        //             servicePackage = "Gold";
        //         else if (eligibilityScore >= 60)
        //             servicePackage = "Silver";
        //         else
        //             servicePackage = "Basic";

        //         Console.WriteLine("\n--- Result ---");
        //         Console.WriteLine("Name: " + name);
        //         Console.WriteLine("Eligibility Score: " + eligibilityScore);
        //         Console.WriteLine("Status: " + status);
        //         Console.WriteLine("Service Package: " + servicePackage);

        //         // switch statement usage
        //         switch (servicePackage)
        //         {
        //             case "Platinum":
        //                 Console.WriteLine("Benefits: All city services + Priority support");
        //                 break;

        //             case "Gold":
        //                 Console.WriteLine("Benefits: Most city services");
        //                 break;

        //             case "Silver":
        //                 Console.WriteLine("Benefits: Basic city services");
        //                 break;

        //             case "Basic":
        //                 Console.WriteLine("Benefits: Limited services");
        //                 break;

        //             default:
        //                 Console.WriteLine("Invalid package");
        //                 break;
        //         }

        //         if(i==familyMembers) break;

        //         // break example
        //         Console.Write("Do you want to stop registration? (yes/no): ");
        //         string choice = Console.ReadLine();

        //         if (choice.ToLower() == "yes")
        //         {
        //             Console.WriteLine("Registration stopped by user.");
        //             break;
        //         }

        //         Console.WriteLine("\nThank you for using TechVille Service Portal.");
        //     }
        // }

        // Module - 3
        // static void Main(String[] args)
        // {
        //     int[] citizenIds = new int[1001];
        //     // Jagged Array: 5 Zones with different sector counts
        //     int[][] cityZones = new int[5][];

        //     int idx = 1;
        //     Console.WriteLine("Enter Citizen ID's : ");
        //     for(int i = 0; i < citizenIds.Length; i++)
        //     {
        //         Console.Write($"Citizen {i+1} ID : ");
        //         // citizenIds[i] = Convert.ToInt32(Console.ReadLine());
        //         citizenIds[i] = idx++;
        //     }

        //      // ---------- SORTING ----------
        //     Array.Sort(citizenIds);

        //     Console.WriteLine("\nSorted Citizen IDs:");
        //     foreach (int id in citizenIds)
        //     {
        //         Console.WriteLine(id);
        //     }

        //      // ---------- SEARCHING ----------
        //     Console.Write("Enter Citizen ID to search: ");
        //     int searchId = Convert.ToInt32(Console.ReadLine());

        //     bool found = false;
        //     for (int i = 0; i < citizenIds.Length; i++)
        //     {
        //         if (citizenIds[i] == searchId)
        //         {
        //             Console.WriteLine($"Citizen ID found at index: {i}");
        //             found = true;
        //             break;
        //         }
        //     }

        //     if (!found)
        //     {
        //         Console.WriteLine("Citizen ID not found.");
        //     }

        //     // ---------- Zones & Sectors ----------
        //     for (int zone = 0; zone < cityZones.Length; zone++)
        //     {
        //         Console.Write($"Enter number of sectors in Zone {zone + 1}: ");
        //         int sectorCount = Convert.ToInt32(Console.ReadLine());

        //         cityZones[zone] = new int[sectorCount];

        //         for (int sector = 0; sector < sectorCount; sector++)
        //         {
        //             Console.Write($"Zone {zone + 1}, Sector {sector + 1} citizen count: ");
        //             cityZones[zone][sector] = Convert.ToInt32(Console.ReadLine());
        //         }
        //     }

        //     // Display
        //     Console.WriteLine("\nZone-Sector Citizen Distribution:");
        //     for (int zone = 0; zone < cityZones.Length; zone++)
        //     {
        //         Console.Write($"Zone {zone + 1}: ");
        //         for (int sector = 0; sector < cityZones[zone].Length; sector++)
        //         {
        //             Console.Write(cityZones[zone][sector] + "\t");
        //         }
        //         Console.WriteLine();
        //     }
        // }

        // Module - 4
        // static void Main(string[] args)
        // {
        //     Console.Write("Enter Name : ");
        //     string name = Console.ReadLine();

        //     Console.Write(@"Enter Email (""Name@Gmail.com""): ");
        //     string email = Console.ReadLine();

        //     Console.Write("Enter Address: ");
        //     string address = Console.ReadLine();

        //     // String Formatting
        //     name = FormatName(name);
        //     Console.WriteLine($"Formatted Name : {name}");

        //     // Email Validation
        //     bool isValidEmail = ValidateEmail(email);
        //     Console.WriteLine($"Is Email Valid : {isValidEmail}");

        //     // Search using string
        //     Console.Write("Enter name keyword to search: ");
        //     string keyword = Console.ReadLine();

        //     bool found = SearchCitizen(name, keyword);
        //     Console.WriteLine($"Citizen Found: {found}");

        //     // Pass by value
        //     int age = 25;
        //     UpdateAge(age);
        //     Console.WriteLine($"Age after method call (pass by value): {age}");

        //     // Pass by reference
        //     UpdateAddress(ref address);
        //     Console.WriteLine($"Updated Address (pass by reference): {address}");
        // }

        // // Method: String formatting
        // static string FormatName(string name)
        // {
        //     return name.Trim().ToUpper();
        // }

        //  // Method: Email validation
        // static bool ValidateEmail(string email)
        // {
        //     return email.Contains("@") && email.Contains(".");
        // }

        // // Method: Search using string
        // static bool SearchCitizen(string name, string keyword)
        // {
        //     return name.Contains(keyword.ToUpper());
        // }

        // // Pass by value
        // static void UpdateAge(int age)
        // {
        //     age = age + 1;
        // }

        // // Pass by reference
        // static void UpdateAddress(ref string address)
        // {
        //     address = address + ", Zone A";
        // }

        // Module - 5
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Name : ");
                string name = Console.ReadLine();
                
                Console.Write("Enter Age : ");
                int age = Convert.ToInt32(Console.ReadLine());

                if (age < 18)
                {
                    throw new InvalidAgeException("Citizen must be atleast 18 years old.");
                }

                Console.Write("Enter Email : ");
                string email = Console.ReadLine();

                if (!email.Contains("@"))
                {
                    throw new FormatException("Invalid Email Format");

                }
                Console.WriteLine("\nCitizen Registered Successfully!");
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Age: {age}");
                Console.WriteLine($"Email: {email}");
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine("Age Error: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input Format Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nRegistration process completed.");
            }
        }
    }
}