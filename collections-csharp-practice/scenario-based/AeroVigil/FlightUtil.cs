using System;
using System.Text.RegularExpressions;

namespace AeroVigil
{
    class FlightUtil : IFlight
    {
        public void EnterFlighDetailsAndValide()
        {
            Console.WriteLine("Enter flight details <FlightNumber>:<FlightName>:<PassengerCount>:<CurrentFuelLevel>");
            string[] input = Console.ReadLine().Split(":");
            string flightNumber = input[0];
            string flightName = input[1];
            int passengerCount = int.Parse(input[2]);
            double currentFuelLevel = double.Parse(input[3]);

            if(ValidateFlightNumber(flightNumber) && ValidateFlightName(flightName) && ValidatePassengerCount(passengerCount,flightName))
            {
                double requiredFule = CalculateFuelToFillTank(flightName,currentFuelLevel);
                if(requiredFule>0) Console.WriteLine($"Fuel required to fill the tank: {requiredFule} liters");
            }
            

        }
        public bool ValidateFlightNumber(string FlightNumber)
        {
            try{
                string pattern = @"^FL-[1-9][0-9]{3}$";

                bool isValid = Regex.IsMatch(FlightNumber,pattern);

                if(!isValid) throw new InvalidFlightExcption($"The Flight Number <{FlightNumber}> Is Invalid");

                return isValid;
            }
            catch(InvalidFlightExcption e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        public bool ValidateFlightName(string FlightName)
        {
            try{
                HashSet<String> flightNames = new HashSet<string>{"SpiceJet", "Vistara", "IndiGo", "Air Arabia"};
                if(flightNames.Contains(FlightName)) return true;
                throw new InvalidFlightExcption($"The Flight Name <{FlightName}> Is Invalid");

            }
            catch(InvalidFlightExcption e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        public bool ValidatePassengerCount(int passengerCount, string flightName)
        {
            try
            {
                if(passengerCount<=0) throw new InvalidFlightExcption($"The passenger count <{passengerCount}> is invalid for <{flightName}>.");

                Dictionary<string,int> flightSeatCountMap = new Dictionary<string, int>{{"SpiceJet" , 396}, {"Vistara",615},{"IndiGo",230},{"Air Arabia",130}};

                if(passengerCount > flightSeatCountMap[flightName]) throw new InvalidFlightExcption($"The passenger count <{passengerCount}> is invalid for <{flightName}>.");

                return true;
                
            }

            catch(InvalidFlightExcption e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public double CalculateFuelToFillTank(string flightName, double currentFuelLevel)
        {
            try{
                if(currentFuelLevel<=0) throw new InvalidFlightExcption($"Invalid fuel level for <{flightName}>.");
                Dictionary<string,int> flightFuelCapacityMap = new Dictionary<string, int>{{"SpiceJet" , 200000}, {"Vistara",300000},{"IndiGo",250000},{"Air Arabia",150000}};
                if(currentFuelLevel > flightFuelCapacityMap[flightName]) throw new InvalidFlightExcption($"Invalid fuel level for <{flightName}>.");

                return flightFuelCapacityMap[flightName]  - currentFuelLevel;
            }

            catch(InvalidFlightExcption e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }

        }



    }

}