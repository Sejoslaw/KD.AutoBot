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

        public override void Initialize()
        {
        }

        public override void ReadData<TStorageType>(TStorageType file)
        {
            // For now on, only add selected File to Bot's collection.
            if (file is FileInfo)
            {
                FileInfo fileInfo = file as FileInfo;
                this.Files.Add(fileInfo);
            }
        }

        public override void WriteData<TStorageType, TDataType>(TStorageType file, TDataType[] data)
        {
            if (file is FileInfo)
            {
                FileInfo fileInfo = file as FileInfo;
                foreach (object dataObj in data)
                {
                    if (dataObj is string)
                    {
                        File.AppendAllText(fileInfo.FullName, dataObj.ToString());
                    }
                    else if (dataObj is byte[])
                    {
                        byte[] bytes = dataObj as byte[];
                        FileStream stream = File.OpenWrite(fileInfo.FullName);
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Flush();
                        stream.Close();
                    }
                }
            }
        }
    }
}