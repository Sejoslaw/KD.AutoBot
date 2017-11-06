using System.Diagnostics;

namespace KD.AutoBot
{
    /// <summary>
    /// Describes tools used to connect to single platform.
    /// </summary>
    public interface IPlatformConnectionTools : IPlatformTools
    {
        /// <summary>
        /// Handler connected with this platform tools.
        /// </summary>
        IConnectionHandler ConnectionHandler { get; }

        /// <summary>
        /// Tries to connect to platform using this tools.
        /// </summary>
        bool AttachToProcess(Process process);
    }
}