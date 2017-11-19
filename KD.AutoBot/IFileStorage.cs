using System.Collections.Generic;
using System.IO;

namespace KD.AutoBot
{
    /// <summary>
    /// Storage for all files connected with current <see cref="IAutoBot"/>'s <see cref="System.Diagnostics.Process"/>.
    /// </summary>
    public interface IFileStorage : IDataHolder
    {
        /// <summary>
        /// Bot connected with this File Storage.
        /// </summary>
        IAutoBot Bot { get; }
        /// <summary>
        /// Directory where Bot stores all it's files.
        /// </summary>
        DirectoryInfo Directory { get; }
        /// <summary>
        /// All files which Bot currently use.
        /// </summary>
        ICollection<FileInfo> Files { get; }

        /// <summary>
        /// Writes specified data to given file.
        /// </summary>
        void WriteToFile(FileInfo file, object[] data);
        /// <summary>
        /// Reads and loads data from given file.
        /// </summary>
        void ReadFile(FileInfo file);
        /// <summary>
        /// Reads and loads data from all files in current working directory.
        /// </summary>
        void ReadFiles();
    }
}