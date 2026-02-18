using System;
using TechVille.Modules;

namespace TechVille
{
    class CitizenPopulationManager
    {
        private Citizen[] CitizensList; // Array Containing The Citizens
        private int count = 0; // To Count The Current Citizen Population.

        // Creating A Jagged Array To Store 5 Zone With Multiple Sectors 
        private int[][] ZoneAndSectors;

        // Constructor To Initialize The Citizens List Array And The Zones Of the Zone And Sectors Array.
        public CitizenPopulationManager(int size,int zoneNumber)
        {
            CitizensList = new Citizen[size];
            ZoneAndSectors = new int[zoneNumber][];
        }

        // Method To Add Or Initialize The Sectors of each zone
        public void InitializeSectors(int zoneIdx, int SectorNumber)
        {
            ZoneAndSectors[zoneIdx] = new int[SectorNumber];
        }

        // Method To Add New Citizens In The Citizen List
        public void AddCitizen(Citizen citizen, int zone, int sector)
        {
            if(zone > ZoneAndSectors.Length || sector > ZoneAndSectors[zone].Length)
            {
                Console.WriteLine("Zone And Sector is out of order");
                return;
            }
            if (count < CitizensList.Length)
            {
                CitizensList[count++] = citizen;

                if(zone <  ZoneAndSectors.Length && sector < ZoneAndSectors[zone].Length)
                {
                    ZoneAndSectors[zone][sector]++;
                }
            }
            citizen.SetCitizenId();
            Console.WriteLine("Citizen Registered Successfully!");
        }

        // Method To Search If A Citizen Exist Or Not By Using Their Id
        public Citizen SearchById(int id)
        {
            for(int i = 0; i < count; i++)
            {
                if (CitizensList[i].CitizenID == id)
                {
                    return CitizensList[i];
                }
            }
            return null;
        }

        public Citizen SearchByName(string name)
        {
            for(int i = 0; i < count; i++)
            {
                if(CitizensList[i].CitizenName.ToLower() == name.ToLower())
                {
                    return CitizensList[i];
                }
            }
            return null;
        }

        // Method To Display The Zone Data
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

        // Method To Display All Citizens
        public void DisplayAllCitizens()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"ID: {CitizensList[i].CitizenID}, Name: {CitizensList[i].CitizenName}"+
                                $", Package: {CitizensList[i].ServicePackage}");
            }
        }
    }
}