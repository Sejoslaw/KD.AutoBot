using System.Collections.Generic;
using System.Diagnostics;

namespace KD.AutoBot.Connection.Windows
{
    /// <summary>
    /// Windows implementation of <see cref="IPlatformConnectionTools"/>.
    /// </summary>
    public class WindowsPlatformConnectionTools : AbstractPlatformConnectionTools
    {
        public WindowsPlatformConnectionTools(IConnectionHandler connectionHandler) :
            base(connectionHandler, "Windows")
        {
            this.Extensions = new HashSet<IPlatformConnectionExtension>();
        }

        public override bool AttachToProcess(Process process)
        {
            if (process == null)
            {
                return false;
            }

            IConnectedProcess connectedProcess = new BasicConnectedProcess(this.ConnectionHandler, process);
            this.ConnectionHandler.ConnectedProcesses.Add(connectedProcess);
            return true;
        }
    }
}