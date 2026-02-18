using System;

namespace TechVille
{
    public class DuplicateCitizenException : Exception
    {
        public DuplicateCitizenException(string message) : base(message)
        {
            
        }
    }
}