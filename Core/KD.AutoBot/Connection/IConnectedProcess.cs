using System;
using System.Diagnostics;

namespace KD.AutoBot.Connection
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
        Process Process { get; }
        /// <summary>
        /// Handler for native Window. May be different than <see cref="Process.MainWindowHandle"/>.
        /// </summary>
        IntPtr WindowHandle { get; }
    }
}