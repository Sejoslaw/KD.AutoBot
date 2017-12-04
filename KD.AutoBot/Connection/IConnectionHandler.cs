using System.Collections.Generic;
using System.Diagnostics;

namespace KD.AutoBot.Connection
{
    /// <summary>
    /// Determines how Bot connectes to specified element on specified operating system.
    /// </summary>
    public interface IConnectionHandler : IModule
    {
        /// <summary>
        /// Platform-specific connection tools available for Bot.
        /// </summary>
        IPlatformConnectionTools PlatformConnectionTools { get; }
        /// <summary>
        /// Processes to which the Bot is currently connected.
        /// </summary>
        ICollection<IConnectedProcess> ConnectedProcesses { get; }

        /// <summary>
        /// Tries to connect to specified <see cref="Process"/>.
        /// If connection will be accepted than current process is added to ConnectedProcesses.
        /// </summary>
        bool AttachToProcess(Process process);
    }
}