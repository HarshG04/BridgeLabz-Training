using System;
using TechVille.Modules;

namespace TechVille
{
    class CitizenPopulationManager
    {
        private SinglyLinkedList citizens;
        private DoublyLinkedList profileNavigation;
        private CircularLinkedList roundRobinList;
        private int[][] ZoneAndSectors;

        public CitizenPopulationManager(int zoneNumber)
        {
            citizens = new SinglyLinkedList();
            profileNavigation = new DoublyLinkedList();
            roundRobinList = new CircularLinkedList();
            ZoneAndSectors = new int[zoneNumber][];
        }

        public void InitializeSectors(int zoneIdx, int sectorNumber)
        {
            ZoneAndSectors[zoneIdx] = new int[sectorNumber];
        }

        public void AddCitizen(Citizen citizen, int zone, int sector)
        {
            citizen.SetCitizenId();

            citizens.Insert(citizen);
            profileNavigation.Insert(citizen);
            roundRobinList.Insert(citizen);

            ZoneAndSectors[zone][sector]++;

            Console.WriteLine("Citizen Registered Successfully!");
        }

        public Citizen SearchById(int id)
        {
            return citizens.SearchById(id);
        }

        public Citizen SearchByName(string name)
        {
            return citizens.SearchByName(name);
        }

        public void DeleteCitizen(int id)
        {
            citizens.DeleteById(id);
        }

        public void DisplayAllCitizens()
        {
            citizens.Traverse();
        }

        public void DisplayForwardProfiles()
        {
            profileNavigation.TraverseForward();
        }

        public void DisplayBackwardProfiles()
        {
            profileNavigation.TraverseBackward();
        }

        public void RunRoundRobin(int cycles)
        {
            roundRobinList.RoundRobin(cycles);
        }

        public void DisplayZoneData()
        {
            Console.WriteLine("\nZone-Sector Citizen Count:");

            for (int i = 0; i < ZoneAndSectors.Length; i++)
            {
                Console.Write($"Zone {i}: ");
                for (int j = 0; j < ZoneAndSectors[i].Length; j++)
                {
                    Console.Write(ZoneAndSectors[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
