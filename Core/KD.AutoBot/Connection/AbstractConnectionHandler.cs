﻿using System;
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

        protected AbstractConnectionHandler(IAutoBot bot, ICollection<IConnectedProcess> connectedProcesses) :
            base(bot)
        {
            this.ConnectedProcesses = connectedProcesses;
        }

        public override void Initialize()
        {
        }

        public abstract bool AttachToProcess(Process process, IntPtr windowHandler);
    }
}