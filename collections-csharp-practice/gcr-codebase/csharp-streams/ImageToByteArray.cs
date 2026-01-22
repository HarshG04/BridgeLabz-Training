using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StreamAssignment
{
    internal class ImageToByteArray
    {
        static void Main(string[] args)
        {
            try
            {
                byte[] imageBytes = File.ReadAllBytes("image.jpg");

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    File.WriteAllBytes("copy.jpg", ms.ToArray());
                }

                Console.WriteLine("Image copied successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
