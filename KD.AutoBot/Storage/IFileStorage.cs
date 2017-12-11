using System.IO;

namespace KD.AutoBot.Storage
{
    /// <summary>
    /// Storage for all files connected with current <see cref="IAutoBot"/>'s <see cref="System.Diagnostics.Process"/>.
    /// </summary>
    public interface IFileStorage : IDataStorage<FileInfo>
    {
        /// <summary>
        /// Directory where Bot stores all it's files.
        /// </summary>
        DirectoryInfo Directory { get; }
    }
}