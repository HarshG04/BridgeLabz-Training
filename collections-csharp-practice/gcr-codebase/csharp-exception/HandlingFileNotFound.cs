using System;
using System.Collections.Generic;
using System.Text;

class HandlingFileNotFound
{
    static void Main(string[] args)
    {
        try
        {
            string fileContent = File.ReadAllText("data.txt");
            Console.WriteLine($"File Content : {fileContent}");
        }
        catch (IOException)
        {
            Console.WriteLine("File Not Found");
        }
    }
}

