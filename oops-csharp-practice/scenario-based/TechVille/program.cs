using System;
using TechVille.Exceptions;
using TechVille.Modules;
using TechVille.Services;
using TechVille.Utilities;

namespace TechVille
{
    class Program
    {
        static void Main(String[] args)
        {
            // Taking Input Of The Citizen Population and The Zone And Sectors
            Console.Write("Enter Maximum Citizen Capacity : ");
            int capacity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Number Of Zones : ");
            int zoneNumber = Convert.ToInt32(Console.ReadLine());

            CitizenRegistrationService service = new CitizenRegistrationService();
            CitizenPopulationManager manager = new CitizenPopulationManager(capacity,zoneNumber);

            // Initialize sectors dynamically
            for (int i = 0; i < zoneNumber; i++)
            {
                Console.Write($"Enter number of sectors in Zone {i}: ");
                int sectors = Convert.ToInt32(Console.ReadLine());
                manager.InitializeSectors(i, sectors);
            }

            // Create Service Objects
            HealthCareService healthcare = new HealthCareService();
            EducationService education = new EducationService();

            Console.WriteLine("\n=== Available City Services ===");
            healthcare.DisplayServiceInfo();
            education.DisplayServiceInfo();

            Console.WriteLine();

            // Example Service Usage
            healthcare.BookAppointment();
            education.EnrollCourse();

            // Infinte Loop
            while (true)
            {
                Console.WriteLine("\n===== TechVille Registration =====");
                Console.WriteLine("1. Register Citizen");
                Console.WriteLine("2. Search By ID");
                Console.WriteLine("3. Search By Name");
                Console.WriteLine("4. Display All Citizens");
                Console.WriteLine("5. Show Zone Data");
                Console.WriteLine("6. Exit");
                Console.Write("Enter Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1 :
                        HandleCitizenRegistration(service,manager);
                        break;
                    case 2 : 
                        HandleSearchById(manager);
                        break;
                    case 3 :
                        HandleSearchByName(manager);
                        break;
                    case 4 :
                        manager.DisplayAllCitizens();
                        break;
                    case 5 :
                        manager.DisplayZoneData();
                        break;
                    case 6 : 
                        Console.WriteLine("Exiting Program");
                        return;
                    default : 
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }

        // Helper Methods 
        private static void HandleCitizenRegistration(CitizenRegistrationService service, CitizenPopulationManager manager)
        {
            try
            {
                Console.Write("Enter Name: ");
                string name = CitizenUtility.FormatName(Console.ReadLine());

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();
                InputValidator.ValidateEmail(email);

                Console.Write("Enter Age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                InputValidator.ValidateAge(age);

                Console.Write("Enter Annual Income: ");
                double income = Convert.ToDouble(Console.ReadLine());
                InputValidator.ValidateIncome(income);

                Console.Write("Enter Residency Years: ");
                int years = Convert.ToInt32(Console.ReadLine());
                InputValidator.ValidateResidency(years);

                Citizen citizen = new Citizen();
                citizen.CitizenName = name;
                citizen.CitizenEmail = email;
                citizen.CitizenAge = age;
                citizen.AnnualIncome = income;
                citizen.ResidencyYears = years;

                service.CalculateEligibility(citizen);
                service.AssignServicePackage(citizen);

                Console.Write("Enter Zone: ");
                int zone = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Sector: ");
                int sector = Convert.ToInt32(Console.ReadLine());

                manager.AddCitizen(citizen, zone, sector);
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine("Age Error : " + ex.Message);
            }
            catch(InvalidIncomeException ex)
            {
                Console.WriteLine("Income Error : " + ex.Message);
            }
            catch(TechVilleCustomeException ex)
            {
                Console.WriteLine("Custom Error : " + ex.Message);
            }
        }

        private static void HandleSearchById(CitizenPopulationManager manager)
        {
            try
            {
                Console.Write("Enter Id To Search : ");
                int id = Convert.ToInt32(Console.ReadLine());

                Citizen found = manager.SearchById(id);

                if (found != null)
                    Console.WriteLine($"Found : {found.CitizenName}, Package : {found.ServicePackage}");
                else
                    Console.WriteLine("Citizen Not Found");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        private static void HandleSearchByName(CitizenPopulationManager manager)
        {
            Console.Write("Enter Name: ");
            string name = CitizenUtility.FormatName(Console.ReadLine());

            Citizen found = manager.SearchByName(name);

            if (found != null)
                Console.WriteLine($"Found: {found.CitizenName}");
            else
                Console.WriteLine("Citizen Not Found.");
        }
    }
}