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
        /// </summary>
        static void Main(string[] args)
        {
            // Taking Citizen Data/Details From The User
            Console.Write("Enter Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter Age : ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Income : ");
            double income = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Residency Years : ");
            int years = Convert.ToInt32(Console.ReadLine());

            // Calculating Eligibility Score Based On Citizen Data.
            double eligibilityScore = (age*3)+(years*2)+(income/10000);

            // Checking If The CItizen is Eligible for Service or Not.
            if (eligibilityScore > 70)
            {
                Console.WriteLine("Citizen Is Elibile");
                Console.WriteLine("\n--- Citizen Details ---");
                Console.WriteLine("Name : " + name);
                Console.WriteLine("Age : " + age);
                Console.WriteLine("Income : " + income);
                Console.WriteLine("Residency Years : " + years);
                Console.WriteLine("Eligibility Score : " + eligibilityScore);
            }
            else
            {
                Console.WriteLine("Citizen is not eligible");
            }
        }
    }
}