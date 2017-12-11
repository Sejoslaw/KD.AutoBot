using KD.AutoBot;
using KD.AutoBot.Files;
using System;
using System.IO;

namespace Test_Windows_FileStorage
{
    public class TestingFileStorage : BasicFileStorage
    {
        public TestingFileStorage(IAutoBot bot, DirectoryInfo dirInfo) :
            base(bot, dirInfo)
        {
        }

        public override void ReadData(FileInfo file)
        {
            Console.WriteLine($"Readed file: { file.ToString() }");
        }
    }
}