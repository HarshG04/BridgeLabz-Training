using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string filePath = "data.csv";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            string phonePattern = @"^\d{10}$";

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                string email = data[2];
                string phone = data[3];

                bool emailValid = Regex.IsMatch(email, emailPattern);
                bool phoneValid = Regex.IsMatch(phone, phonePattern);

                if (!emailValid || !phoneValid)
                {
                    Console.WriteLine("Invalid Data at Row " + i + ": " + lines[i]);
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
