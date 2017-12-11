using System.IO;

namespace KD.AutoBot.Storage
{
    /// <summary>
    /// Abstract implementation of <see cref="IFileStorage"/>.
    /// </summary>
    public abstract class AbstractFileStorage : AbstractDataStorage<FileInfo>, IFileStorage
    {
        public DirectoryInfo Directory { get; set; }

        protected AbstractFileStorage(IAutoBot bot, DirectoryInfo dirInfo) :
            base(bot)
        {
            this.Directory = dirInfo;
        }
    }
}