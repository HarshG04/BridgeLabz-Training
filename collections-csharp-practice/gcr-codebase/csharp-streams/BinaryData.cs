using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StreamAssignment
{
    internal class BinaryData
    {
        static void Main(string[] args)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open("student.dat", FileMode.Create)))
            {
                bw.Write(101);
                bw.Write("Rahul");
                bw.Write(8.9);
            }

            using (BinaryReader br = new BinaryReader(File.Open("student.dat", FileMode.Open)))
            {
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
                Console.WriteLine(br.ReadDouble());
            }
        }
    }
}
