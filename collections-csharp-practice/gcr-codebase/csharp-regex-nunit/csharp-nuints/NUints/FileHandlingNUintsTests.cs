using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing;

namespace NUnit.tests
{
    [TestFixture]
    public class FileProcessorNUnitTests
    {
        private FileProcessor fileProcessor;
        private string testFile;

        [SetUp]
        public void Setup()
        {
            fileProcessor = new FileProcessor();
            testFile = "test_nunit.txt";
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
        }

        [Test]
        public void WriteAndRead_File_ContentMatches()
        {
            fileProcessor.WriteToFile(testFile, "Hello NUnit");

            string result = fileProcessor.ReadFromFile(testFile);

            Assert.AreEqual("Hello NUnit", result);
        }

        [Test]
        public void WriteToFile_FileExistsAfterWrite()
        {
            fileProcessor.WriteToFile(testFile, "Test Data");

            Assert.IsTrue(File.Exists(testFile));
        }

        [Test]
        public void ReadFromFile_FileDoesNotExist_ThrowsIOException()
        {
            Assert.Throws<IOException>(() =>
                fileProcessor.ReadFromFile("nonexistent.txt"));
        }
    }
}
