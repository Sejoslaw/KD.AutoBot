using KD.AutoBot.Data;
using System.Collections.Generic;
using System.IO;

namespace KD.AutoBot.Files
{
    /// <summary>
    /// Abstract implementation of <see cref="IFileStorage{FileInfo}"/>.
    /// </summary>
    public abstract class AbstractFileStorage : AbstractDataStorage, IFileStorage
    {
        public DirectoryInfo Directory { get; set; }

        public ICollection<FileInfo> Files { get; set; }

        public AbstractFileStorage(IAutoBot bot, DirectoryInfo dirInfo, ICollection<FileInfo> files) :
            base(bot)
        {
            this.Directory = dirInfo;
            this.Files = files;
        }
    }
}