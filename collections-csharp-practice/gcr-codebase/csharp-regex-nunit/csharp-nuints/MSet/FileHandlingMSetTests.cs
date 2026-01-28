using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace MSet.tests
{
    [TestClass]
    public class FileProcessorMSTests
    {
        private FileProcessor fileProcessor;
        private string testFile;

        [TestInitialize]
        public void Init()
        {
            fileProcessor = new FileProcessor();
            testFile = "test_mstest.txt";
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
        }

        [TestMethod]
        public void WriteAndRead_File_ContentMatches()
        {
            fileProcessor.WriteToFile(testFile, "Hello MSTest");

            string result = fileProcessor.ReadFromFile(testFile);

            Assert.AreEqual("Hello MSTest", result);
        }

        [TestMethod]
        public void WriteToFile_FileExistsAfterWrite()
        {
            fileProcessor.WriteToFile(testFile, "Data");

            Assert.IsTrue(File.Exists(testFile));
        }

        [TestMethod]
        public void ReadFromFile_FileDoesNotExist_ThrowsIOException()
        {
            try
            {
                fileProcessor.ReadFromFile("missing.txt");
                Assert.Fail("Expected IOException was not thrown.");
            }
            catch (IOException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
