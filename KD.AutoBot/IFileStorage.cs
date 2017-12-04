using System.Collections.Generic;
using System.IO;

namespace KD.AutoBot
{
    /// <summary>
    /// Storage for all files connected with current <see cref="IAutoBot"/>'s <see cref="System.Diagnostics.Process"/>.
    /// </summary>
    public interface IFileStorage : IDataStorage
    {
        /// <summary>
        /// Directory where Bot stores all it's files.
        /// </summary>
        DirectoryInfo Directory { get; }
        /// <summary>
        /// All files which Bot currently use.
        /// </summary>
        ICollection<FileInfo> Files { get; }
    }
}