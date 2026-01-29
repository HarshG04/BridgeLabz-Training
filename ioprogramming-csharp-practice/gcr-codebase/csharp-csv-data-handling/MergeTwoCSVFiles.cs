using System;
using System.IO;

class Program
{
    static void Main()
    {
        string[] file1 = File.ReadAllLines("students1.csv");
        string[] file2 = File.ReadAllLines("students2.csv");

        string outputFile = "merged.csv";
        StreamWriter writer = new StreamWriter(outputFile);
        writer.WriteLine("ID,Name,Age,Marks,Grade");

        for (int i = 1; i < file1.Length; i++)
        {
            string[] data1 = file1[i].Split(',');
            string id1 = data1[0];

            for (int j = 1; j < file2.Length; j++)
            {
                string[] data2 = file2[j].Split(',');
                if (id1 == data2[0])
                {
                    writer.WriteLine(id1 + "," + data1[1] + "," + data1[2] + "," + data2[1] + "," + data2[2]);
                }
            }
        }

        writer.Close();
        Console.WriteLine("Files merged successfully.");
    }
}
