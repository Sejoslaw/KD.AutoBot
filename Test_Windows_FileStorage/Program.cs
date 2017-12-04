using KD.AutoBot;
using System;
using System.IO;

namespace Test_Windows_FileStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing File Storage
            IFileStorage storage = new TestingFileStorage(null, new DirectoryInfo("bin/Debug/netcoreapp2.0/Testing"));

            // Test directory path
            Console.WriteLine("Directory full path: " + storage.Directory.FullName);
            Console.WriteLine("Directory exists: " + storage.Directory.Exists);

            // Test reading from File
            FileInfo file = new FileInfo("bin/Debug/netcoreapp2.0/TestFile.txt");
            storage.ReadData(file);

            // Test writing to File
            storage.WriteData(new FileInfo($"bin/Debug/netcoreapp2.0/Testing/TestFile---{ GetTime() }.txt"), new object[]
                {
                    "Testing writing",
                    GetTime()
                });
        }

        static string GetTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd---HH-mm-ss-fffffff");
        }
    }
}