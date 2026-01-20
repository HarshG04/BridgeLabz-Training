using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BridgeLabzTraining.data_structure_csharp_practice.scenario_based.ParcelTracker
{
    // Menu Class Containing Program User Menu
    internal class ParcelTrackerMenu
    {
        private ParcelTrackerUtilityImpl ParcelUtility;

        public void Menu()
        {
            ParcelUtility = new ParcelTrackerUtilityImpl();
            while (true)
            {
                Console.WriteLine("\n===== Parcel Tracker Menu =====");
                Console.WriteLine("1. Add Parcel");
                Console.WriteLine("2. Move Parcels");
                Console.WriteLine("3. Add Checkpoint");
                Console.WriteLine("4. Track Parcels");
                Console.WriteLine("5. Exit");
                Console.Write("Choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ParcelUtility.AddParcel();
                        break;

                    case 2:
                        ParcelUtility.ParcelMove();
                        break;

                    case 3:
                        Console.Write("Enter checkpoint name: ");
                        ParcelUtility.AddCheckPoint(Console.ReadLine());
                        break;

                    case 4:
                        ParcelUtility.TrackParcel();
                        break;

                    case 5:
                        Console.WriteLine("Exiting The Parcel Tracker");
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
