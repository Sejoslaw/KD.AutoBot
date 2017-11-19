using System.Collections.Generic;
using System.IO;

namespace KD.AutoBot.Files
{
    /// <summary>
    /// Basic definition of File Storage.
    /// </summary>
    public class BasicFileStorage : AbstractFileStorage
    {
        public BasicFileStorage(IAutoBot bot, DirectoryInfo dirInfo) :
            base(bot, dirInfo, new HashSet<FileInfo>())
        {
        }

        public BasicFileStorage(IAutoBot bot, DirectoryInfo dirInfo, ICollection<FileInfo> files) :
            base(bot, dirInfo, files)
        {
        }

        public override void ReadFile(FileInfo file)
        {
            // For now on, only add selected File to Bot's collection.
            this.Files.Add(file);
        }

        public override void ReadFiles()
        {
            IEnumerable<FileInfo> files = this.Directory.EnumerateFiles();
            foreach (FileInfo file in files)
            {
                this.ReadFile(file);
            }
        }

        public override void WriteToFile(FileInfo file, object[] data)
        {
            foreach (object dataObj in data)
            {
                if (dataObj is string)
                {
                    File.AppendAllText(file.FullName, dataObj.ToString());
                }
                else if (dataObj is byte[])
                {
                    byte[] bytes = dataObj as byte[];
                    FileStream stream = File.OpenWrite(file.FullName);
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                    stream.Close();
                }
            }
        }
    }
}