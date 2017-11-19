using System.Diagnostics;

namespace KD.AutoBot.Connection
{
    /// <summary>
    /// Basic implementation of <see cref="IConnectedProcess"/>.
    /// </summary>
    public class BasicConnectedProcess : BasicDataHolder, IConnectedProcess
    {
        public IConnectionHandler ConnectionHandler { get; }

        public Process Process { get; }

        public BasicConnectedProcess(IConnectionHandler connectionHandler, Process processToConnect)
        {
            this.ConnectionHandler = connectionHandler;
            this.Process = processToConnect;
        }
    }
}