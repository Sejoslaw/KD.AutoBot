using System.Collections.Generic;
using System.Diagnostics;

namespace KD.AutoBot.Connection.Windows
{
    /// <summary>
    /// Windows implementation of <see cref="IConnectionHandler"/>.
    /// </summary>
    public class WindowsConnectionHandler : AbstractConnectionHandler
    {
        public WindowsConnectionHandler(IAutoBot bot, IPlatformConnectionTools platformConnectionTools) :
            base(bot, platformConnectionTools, new HashSet<IConnectedProcess>())
        {
        }

        public WindowsConnectionHandler(IAutoBot bot, IPlatformConnectionTools platformConnectionTools, ICollection<IConnectedProcess> connectedProcesses) :
            base(bot, platformConnectionTools, connectedProcesses)
        {
        }

        public override bool AttachToProcess(Process process)
        {
            bool value = this.PlatformConnectionTools.AttachToProcess(process);
            return value;
        }
    }
}