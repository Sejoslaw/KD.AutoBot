using System.IO;

namespace KD.AutoBot.Files
{
    /// <summary>
    /// Basic definition of File Storage.
    /// </summary>
    public abstract class BasicFileStorage : AbstractFileStorage
    {
        public BasicFileStorage(IAutoBot bot, DirectoryInfo dirInfo) :
            base(bot, dirInfo)
        {
            if (this.Directory == null)
            {
                throw new DirectoryNotFoundException("AutoBot's operating directory does not exists.");
            }

            if (!this.Directory.Exists)
            {
                this.Directory.Create();
            }
        }

        public override void Initialize()
        {
        }

        public override void WriteData<TStorageType, TDataType>(TStorageType file, TDataType[] data)
        {
            if (file is FileInfo)
            {
                FileInfo fileInfo = file as FileInfo;
                if (!fileInfo.Exists)
                {
                    FileStream stream = fileInfo.Create();
                    stream.Close();
                }

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