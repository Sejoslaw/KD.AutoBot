using KD.AutoBot.Storage;
using System.IO;

namespace KD.AutoBot.Files
{
    /// <summary>
    /// Basic definition of File Storage.
    /// </summary>
    public abstract class BasicFileStorage : AbstractFileStorage
    {
        protected BasicFileStorage(IAutoBot bot, DirectoryInfo dirInfo) :
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

        public override void WriteData<TStorageType, TDataType>(TStorageType storageType, TDataType[] data)
        {
            if (storageType is FileInfo)
            {
                FileInfo file = storageType as FileInfo;

                if (!file.Exists)
                {
                    FileStream stream = file.Create();
                    stream.Close();
                }

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
}