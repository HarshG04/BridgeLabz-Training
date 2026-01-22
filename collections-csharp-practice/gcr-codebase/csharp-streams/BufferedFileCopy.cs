using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace StreamAssignment
{
    internal class BufferedFileCopy
    {
        static void Main(string[] args)
        {
            string source = "bigfile.dat";
            string destination = "buffered.dat";

            byte[] buffer = new byte[4096];

            Stopwatch sw = Stopwatch.StartNew();

            using (FileStream fsRead = new FileStream(source, FileMode.Open))
            using (FileStream fsWrite = new FileStream(destination, FileMode.Create))
            using (BufferedStream br = new BufferedStream(fsRead))
            using (BufferedStream bw = new BufferedStream(fsWrite))
            {
                int bytesRead;
                while ((bytesRead = br.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bw.Write(buffer, 0, bytesRead);
                }
            }

            sw.Stop();
            Console.WriteLine("Buffered copy time: " + sw.ElapsedMilliseconds + " ms");
        }
    }
}
