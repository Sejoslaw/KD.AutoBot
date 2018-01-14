using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KD.AutoBot.Connection.Windows
{
    /// <summary>
    /// Windows implementation of <see cref="IPlatformConnectionTools"/>.
    /// </summary>
    [Serializable]
    public class WindowsPlatformConnectionTools : AbstractPlatformConnectionTools
    {
        public WindowsPlatformConnectionTools(IConnectionHandler connectionHandler) :
            base(connectionHandler, "Windows")
        {
            this.Extensions = new HashSet<IPlatformConnectionExtension>();
        }

        public override bool AttachToProcess(Process process, IntPtr windowHandler)
        {
            if (process == null)
            {
                return false;
            }

            IConnectedProcess connectedProcess = new BasicConnectedProcess(this.ConnectionHandler, process, windowHandler);
            this.ConnectionHandler.ConnectedProcesses.Add(connectedProcess);
            return true;
        }
    }
}