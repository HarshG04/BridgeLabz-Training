using System;
using TechVille.Exceptions;

namespace TechVille.Utilities
{
    public static class InputValidator
    {
        public static void ValidateAge(int age)
        {
            if(age <= 0)
            {
                throw new InvalidAgeException("Age must be greater than 0.");
            }
        }

        public static void ValidateIncome(double income)
        {
            if(income < 0)
            {
                throw new InvalidIncomeException("Income must be greater than 0.");
            }
        }

        public static void ValidateResidency(int years)
        {
            if(years < 0)
            {
                throw new TechVilleCustomeException("Residency years can't be less than 0.");
            }
        }
        public static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
            {
                throw new TechVilleCustomeException("Email Format is not valid.");
            }
        }
    }
}