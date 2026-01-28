using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class FileProcessor
    {
        public void WriteToFile(string filename, string content)
        {
            File.WriteAllText(filename, content);
        }

        public string ReadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new IOException("File does not exist");
            }

            return File.ReadAllText(filename);
        }
    }
}
