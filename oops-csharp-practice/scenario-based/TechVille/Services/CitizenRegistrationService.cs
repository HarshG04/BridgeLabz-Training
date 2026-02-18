using System;
using TechVille.Modules;

namespace TechVille.Services
{
    public class CitizenRegistrationService
    {
        // Module -1 : Calculating Eligibility Score
        public void CalculateEligibility(Citizen citizen)
        {
            int ageScore = citizen.CitizenAge >= 18 ? 20 : 0;
            int residencyScore = citizen.ResidencyYears * 5;
            int incomeScore = citizen.AnnualIncome < 300000 ? 30 : 10;

            citizen.EligibilityScore = ageScore + residencyScore + incomeScore;
            citizen.IsEligible = citizen.CitizenAge >= 18;
        }

        // Addigning Package If Citizen is Eligible for it.
        public void AssignServicePackage(Citizen citizen)
        {
            // Checking if a citizen is eligible or not.
            if (!citizen.IsEligible)
            {
                citizen.ServicePackage = "Not Eligible";
                return;
            }

            if (citizen.EligibilityScore >= 80)
                citizen.ServicePackage = "Platinum";
            else if (citizen.EligibilityScore >= 60)
                citizen.ServicePackage = "Gold";
            else if (citizen.EligibilityScore >= 40)
                citizen.ServicePackage = "Silver";
            else
                citizen.ServicePackage = "Basic";
        }
    }
}