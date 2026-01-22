using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Pipes;
using System.IO;
using System.Threading;

namespace StreamAssignment
{
    internal class PipeStreamDemo
    {
        static void Main(string[] args)
        {
            AnonymousPipeServerStream server = new AnonymousPipeServerStream(PipeDirection.Out);
            AnonymousPipeClientStream client =
                new AnonymousPipeClientStream(PipeDirection.In, server.ClientSafePipeHandle);

            Thread writer = new Thread(() =>
            {
                using (StreamWriter sw = new StreamWriter(server))
                {
                    sw.AutoFlush = true;
                    sw.WriteLine("Message from writer thread");
                }
            });

            Thread reader = new Thread(() =>
            {
                using (StreamReader sr = new StreamReader(client))
                {
                    Console.WriteLine(sr.ReadLine());
                }
            });

            writer.Start();
            reader.Start();
        }
    }
}
