using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "largefile.csv";
        int count = 0;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            int batch = 0;

            reader.ReadLine();

            while ((line = reader.ReadLine()) != null)
            {
                batch++;
                count++;

                if (batch == 100)
                {
                    Console.WriteLine("Processed " + count + " records");
                    batch = 0;
                }
            }
        }

        Console.WriteLine("Total records processed: " + count);
    }
}
