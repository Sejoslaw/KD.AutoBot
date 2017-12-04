using KD.AutoBot.Data;
using System.IO;

namespace KD.AutoBot.Files
{
    /// <summary>
    /// Abstract implementation of <see cref="IFileStorage"/>.
    /// </summary>
    public abstract class AbstractFileStorage : AbstractDataStorage, IFileStorage
    {
        public DirectoryInfo Directory { get; set; }

        public AbstractFileStorage(IAutoBot bot, DirectoryInfo dirInfo) :
            base(bot)
        {
            this.Directory = dirInfo;
        }
    }
}