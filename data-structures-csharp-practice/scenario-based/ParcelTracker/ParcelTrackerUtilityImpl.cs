using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.data_structure_csharp_practice.scenario_based.ParcelTracker
{
    // Utility Class Containing Interface Methods Implementation
    internal class ParcelTrackerUtilityImpl : IParcelTracker
    {
        private Parcel[] parcelsList;
        private int currentIdx;
        private Random random;

        public ParcelTrackerUtilityImpl()
        {
            Console.Write("Enter number of parcels: ");
            int capacity = Convert.ToInt32(Console.ReadLine());

            parcelsList = new Parcel[capacity];
            currentIdx = 0;
            random = new Random();
        }

        public void AddParcel()
        {
            if (currentIdx >= parcelsList.Length)
            {
                Console.WriteLine("Parcel limit reached.");
                return;
            }

            parcelsList[currentIdx++] = new Parcel();
            Console.WriteLine("New parcel added.");
        }

        public void ParcelMove()
        {
            if (currentIdx == 0)
            {
                Console.WriteLine("No parcels available.");
                return;
            }

            for (int i = 0; i < currentIdx; i++)
            {
                int decision = random.Next(0, 10);

                if (decision >= 1)
                {
                    parcelsList[i].Move();
                }
                else
                {
                    parcelsList[i].MarkLost();
                    Console.WriteLine($"Parcel {parcelsList[i].ParcelID} LOST");
                }
            }
        }

        public void AddCheckPoint(string checkpoint)
        {
            for (int i = 0; i < currentIdx; i++)
            {
                parcelsList[i].AddCheckPoint(checkpoint);
            }
            Console.WriteLine("Checkpoint added.");
        }

        public void TrackParcel()
        {
            for (int i = 0; i < currentIdx; i++)
            {
                parcelsList[i].Track();
            }
        }
    }
}

