using System;

namespace TechVille.Exceptions
{
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message)
        {

        }
    }
}