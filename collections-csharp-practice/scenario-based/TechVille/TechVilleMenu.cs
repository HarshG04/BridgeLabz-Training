using System;
using TechVille.Modules;
using TechVille.Services;
using TechVille.Interface;
using TechVille.Utilities;
using TechVille.Exceptions;

namespace TechVille
{
    class TechVilleMenu
    {
        public void DisplayMenu()
        {
            Console.Write("Enter Number Of Zones : ");
            int zoneNumber = Convert.ToInt32(Console.ReadLine());

            CitizenPopulationManager manager = new CitizenPopulationManager(zoneNumber);

            // Initialize Zones
            for (int i = 0; i < zoneNumber; i++)
            {
                Console.Write($"Enter number of sectors in Zone {i}: ");
                int sectors = Convert.ToInt32(Console.ReadLine());
                manager.InitializeSectors(i, sectors);
            }

            while (true)
            {
                Console.WriteLine("\n===== TechVille Registration =====");
                Console.WriteLine("1. Register Citizen");
                Console.WriteLine("2. Search By ID");
                Console.WriteLine("3. Search By Name");
                Console.WriteLine("4. Delete Citizen");
                Console.WriteLine("5. Display All Citizens");
                Console.WriteLine("6. Show Zone Data");
                Console.WriteLine("7. View Profiles Forward");
                Console.WriteLine("8. View Profiles Backward");
                Console.WriteLine("9. Run Round Robin Allocation");
                Console.WriteLine("10. Show Services");
                Console.WriteLine("11. Exit");
                Console.Write("Enter Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterCitizen(manager);
                        break;

                    case 2:
                        SearchById(manager);
                        break;

                    case 3:
                        SearchByName(manager);
                        break;

                    case 4:
                        DeleteCitizen(manager);
                        break;

                    case 5:
                        manager.DisplayAllCitizens();
                        break;

                    case 6:
                        manager.DisplayZoneData();
                        break;

                    case 7:
                        manager.DisplayForwardProfiles();
                        break;

                    case 8:
                        manager.DisplayBackwardProfiles();
                        break;

                    case 9:
                        Console.Write("Enter number of cycles: ");
                        int cycles =
                            Convert.ToInt32(Console.ReadLine());
                        manager.RunRoundRobin(cycles);
                        break;

                    case 10:
                        HandleServices();
                        break;

                    case 11:
                        Console.WriteLine("Exiting Program...");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }

        // ================= CITIZEN OPERATIONS =================

        private void RegisterCitizen(
            CitizenPopulationManager manager)
        {
            try
            {
                CitizenRegistrationService service =
                    new CitizenRegistrationService();

                Console.Write("Enter Name: ");
                string name =
                    CitizenUtility.FormatName(Console.ReadLine());

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();
                InputValidator.ValidateEmail(email);

                Console.Write("Enter Age: ");
                int age =
                    Convert.ToInt32(Console.ReadLine());
                InputValidator.ValidateAge(age);

                Console.Write("Enter Annual Income: ");
                double income =
                    Convert.ToDouble(Console.ReadLine());
                InputValidator.ValidateIncome(income);

                Console.Write("Enter Residency Years: ");
                int years =
                    Convert.ToInt32(Console.ReadLine());
                InputValidator.ValidateResidency(years);

                Citizen citizen = new Citizen
                {
                    CitizenName = name,
                    CitizenEmail = email,
                    CitizenAge = age,
                    AnnualIncome = income,
                    ResidencyYears = years
                };

                service.CalculateEligibility(citizen);
                service.AssignServicePackage(citizen);

                Console.Write("Enter Zone: ");
                int zone =
                    Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Sector: ");
                int sector =
                    Convert.ToInt32(Console.ReadLine());

                manager.AddCitizen(citizen, zone, sector);
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine("Age Error: " + ex.Message);
            }
            catch (InvalidIncomeException ex)
            {
                Console.WriteLine("Income Error: " + ex.Message);
            }
            catch (TechVilleCustomeException ex)
            {
                Console.WriteLine("Custom Error: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid numeric input.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
        }

        private void SearchById(
            CitizenPopulationManager manager)
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Citizen found = manager.SearchById(id);

            Console.WriteLine(found != null
                ? found.ToString()
                : "Citizen Not Found.");
        }

        private void SearchByName(
            CitizenPopulationManager manager)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Citizen found = manager.SearchByName(name);

            Console.WriteLine(found != null
                ? found.ToString()
                : "Citizen Not Found.");
        }

        private void DeleteCitizen(
            CitizenPopulationManager manager)
        {
            Console.Write("Enter ID to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            manager.DeleteCitizen(id);
            Console.WriteLine("Delete operation completed.");
        }

        // ================= SERVICE OPERATIONS =================

        private void HandleServices()
        {
            Console.WriteLine("\n=== Available Services ===");

            IService[] services =
            {
                new HealthCareService(ServicePlan.Basic),
                new HealthCareService(ServicePlan.Premium),
                new EducationService(),
                new TransportationService("Metro")
            };

            foreach (IService service in services)
            {
                service.Register();
                service.CheckStatus();
                service.Cancel();
                Console.WriteLine();
            }

            Console.WriteLine("Detailed Info:\n");

            foreach (IService service in services)
            {
                Console.WriteLine(service.ToString());
            }

            Console.WriteLine();
            Service.DisplayTotalServices();
        }
    }
}
