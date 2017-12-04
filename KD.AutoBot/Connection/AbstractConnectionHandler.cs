using System.Collections.Generic;
using System.Diagnostics;

namespace KD.AutoBot.Connection
{
    /// <summary>
    /// Abstract implementation of <see cref="IConnectionHandler"/>.
    /// </summary>
    public abstract class AbstractConnectionHandler : AbstractModule, IConnectionHandler
    {
        public IPlatformConnectionTools PlatformConnectionTools { get; set; }

        public ICollection<IConnectedProcess> ConnectedProcesses { get; set; }

        public AbstractConnectionHandler(IAutoBot bot, IPlatformConnectionTools platformConnectionTools, ICollection<IConnectedProcess> connectedProcesses) :
            base(bot)
        {
            this.PlatformConnectionTools = platformConnectionTools;
            this.ConnectedProcesses = connectedProcesses;
        }

        public override void Initialize()
        {
        }

        public abstract bool AttachToProcess(Process process);
    }
}