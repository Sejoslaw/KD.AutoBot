using System.Collections.Generic;
using System.Diagnostics;

namespace KD.AutoBot.Connection
{
    /// <summary>
    /// Abstract implementation of <see cref="IConnectionHandler"/>.
    /// </summary>
    public abstract class AbstractConnectionHandler : BasicDataHolder, IConnectionHandler
    {
        public IAutoBot Bot { get; }

        public IPlatformConnectionTools PlatformConnectionTools { get; }

        public ICollection<IConnectedProcess> ConnectedProcesses { get; }

        public AbstractConnectionHandler(IAutoBot bot, IPlatformConnectionTools platformConnectionTools, ICollection<IConnectedProcess> connectedProcesses)
        {
            this.Bot = bot;
            this.PlatformConnectionTools = platformConnectionTools;
            this.ConnectedProcesses = connectedProcesses;
        }

        public abstract bool AttachToProcess(Process process);
    }
}