using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StreamAssignment
{
    internal class ConsoleInputToFile
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                using (StreamWriter writer = new StreamWriter("user.txt"))
                {
                    Console.Write("Enter Name: ");
                    string name = reader.ReadLine();

                    Console.Write("Enter Age: ");
                    string age = reader.ReadLine();

                    Console.Write("Enter Favorite Language: ");
                    string language = reader.ReadLine();

                    writer.WriteLine("Name: " + name);
                    writer.WriteLine("Age: " + age);
                    writer.WriteLine("Language: " + language);
                }

                Console.WriteLine("User data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
