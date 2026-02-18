using System;

namespace TechVille.Modules
{
    public class Citizen
    {
        private static int nextId = 1;
        public int CitizenID {get; set;}
        public string CitizenName {get; set;}
        public string CitizenEmail {get; set;} // Module - 4 : Email of the Citizen
        public int CitizenAge {get; set;}
        public double AnnualIncome {get; set;}
        public int ResidencyYears {get; set;}
        public int EligibilityScore {get; set;}
        public bool IsEligible {get; set;}
        public string ServicePackage {get; set;} // Module - 2 : Adding Service Package

        public void SetCitizenId()
        {
            this.CitizenID = nextId++;
        }
    }
}