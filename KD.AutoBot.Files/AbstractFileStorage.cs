using System.Collections.Generic;
using System.IO;

namespace KD.AutoBot.Files
{
    /// <summary>
    /// Abstract implementation of <see cref="IFileStorage"/>.
    /// </summary>
    public abstract class AbstractFileStorage : BasicDataHolder, IFileStorage
    {
        public IAutoBot Bot { get; }

        public DirectoryInfo Directory { get; }

        public ICollection<FileInfo> Files { get; }

        public AbstractFileStorage(IAutoBot bot, DirectoryInfo dirInfo, ICollection<FileInfo> files)
        {
            this.Bot = bot;
            this.Directory = dirInfo;
            this.Files = files;
        }

        public abstract void ReadFile(FileInfo file);

        public abstract void ReadFiles();

        public abstract void WriteToFile(FileInfo file, object[] data);
    }
}