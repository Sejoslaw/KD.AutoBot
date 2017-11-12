using System.Diagnostics;

namespace KD.AutoBot
{
    /// <summary>
    /// Describes single process to which the Bot did connect using specified tools.
    /// </summary>
    public interface IConnectedProcess : IDataHolder
    {
        /// <summary>
        /// Handler which stores this connected process.
        /// </summary>
        IConnectionHandler ConnectionHandler { get; }
        /// <summary>
        /// Process to which the Bot is connected.
        /// </summary>
        Process ConnectedProcess { get; }
    }
}