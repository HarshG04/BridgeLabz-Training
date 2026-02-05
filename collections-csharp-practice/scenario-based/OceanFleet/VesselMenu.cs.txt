using System;

namespace OceanFleet
{
    public class VesselMenu
    {
        private VesselUtil vesselUtil;

        public VesselMenu()
        {
            vesselUtil = new VesselUtil();
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- OceanFleet Menu ---");
                Console.WriteLine("1. Add Vessel");
                Console.WriteLine("2. Search Vessel by ID");
                Console.WriteLine("3. Show High Performance Vessels");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddVessel();
                        break;

                    case 2:
                        SearchVessel();
                        break;

                    case 3:
                        ShowHighPerformanceVessels();
                        break;

                    case 4:
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        private void AddVessel()
        {
            Console.WriteLine("Enter vessel details (vesselId:vesselName:averageSpeed:vesselType):");
            string input = Console.ReadLine();

            string[] data = input.Split(':');

            Vessel vessel = new Vessel(
                data[0],
                data[1],
                double.Parse(data[2]),
                data[3]
            );

            vesselUtil.AddVesselPerformance(vessel);
            Console.WriteLine("Vessel added successfully!");
        }

        private void SearchVessel()
        {
            Console.Write("Enter Vessel ID: ");
            string id = Console.ReadLine();

            Vessel vessel = vesselUtil.GetVesselById(id);

            if (vessel != null)
            {
                Console.WriteLine(
                    vessel.VesselId + " | " +
                    vessel.VesselName + " | " +
                    vessel.VesselType + " | " +
                    vessel.AverageSpeed + " knots"
                );
            }
            else
            {
                Console.WriteLine("Vessel Id " + id + " not found");
            }
        }

        private void ShowHighPerformanceVessels()
        {
            List<Vessel> vessels = vesselUtil.GetHighPerformanceVessels();

            Console.WriteLine("High performance vessels are:");
            foreach (Vessel vessel in vessels)
            {
                Console.WriteLine(
                    vessel.VesselId + " | " +
                    vessel.VesselName + " | " +
                    vessel.VesselType + " | " +
                    vessel.AverageSpeed + " knots"
                );
            }
        }
    }
}