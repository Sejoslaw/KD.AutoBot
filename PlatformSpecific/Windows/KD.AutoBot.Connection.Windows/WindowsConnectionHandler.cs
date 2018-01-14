using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KD.AutoBot.Connection.Windows
{
    /// <summary>
    /// Windows implementation of <see cref="IConnectionHandler"/>.
    /// </summary>
    [Serializable]
    public class WindowsConnectionHandler : AbstractConnectionHandler
    {
        public WindowsConnectionHandler(IAutoBot bot) :
            this(bot, new HashSet<IConnectedProcess>())
        {
        }

        public WindowsConnectionHandler(IAutoBot bot, ICollection<IConnectedProcess> connectedProcesses) :
            base(bot, connectedProcesses)
        {
            this.PlatformConnectionTools = new WindowsPlatformConnectionTools(this);
        }

        public override bool AttachToProcess(Process process, IntPtr windowHandler)
        {
            bool value = this.PlatformConnectionTools.AttachToProcess(process, windowHandler);
            return value;
        }
    }
}