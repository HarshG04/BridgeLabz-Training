using System;

namespace TechVille.Exceptions
{
    public class InvalidIncomeException : Exception
    {
        public InvalidIncomeException(string message) : base(message)
        {
            
        }
    }
}