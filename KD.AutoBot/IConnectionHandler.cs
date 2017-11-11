using System.Collections.Generic;
using System.Diagnostics;

namespace KD.AutoBot
{
    /// <summary>
    /// Determines how Bot connectes to specified element on specified operating system.
    /// </summary>
    public interface IConnectionHandler : IDataHolder
    {
        /// <summary>
        /// Bot connected with this Handler.
        /// </summary>
        IAutoBot Bot { get; }
        /// <summary>
        /// Platform-specific connection tools available for Bot.
        /// </summary>
        IPlatformConnectionTools PlatformConnectionTools { get; }
        /// <summary>
        /// Processes to which the Bot is currently connected.
        /// </summary>
        ICollection<IConnectedProcess> ConnectedProcesses { get; }

        /// <summary>
        /// Tries to connect to specified <see cref="Process"/> using specified <see cref="IPlatformConnectionTools"/>.
        /// If connection will be accepted than current process is added to ConnectedProcesses.
        /// </summary>
        bool AttachToProcess(Process process, IPlatformConnectionTools platformTools);
    }
}