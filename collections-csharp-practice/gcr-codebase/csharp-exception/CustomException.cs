using System;
using System.Collections.Generic;
using System.Text;

class CustomException
{
    class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message)
        {

        }
    }
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter Your Age : ");
            int age = Convert.ToInt32(Console.ReadLine());

            ValidateAge(age);
            Console.WriteLine("Access Granted");
        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void ValidateAge(int age)
    {
        if (age < 18)
        {
            throw new InvalidAgeException("Age must be 18 or above");
        }
    }
}

