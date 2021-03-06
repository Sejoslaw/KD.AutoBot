﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KD.AutoBot.Connection
{
    /// <summary>
    /// Abstract implementation of <see cref="IPlatformConnectionTools"/>.
    /// </summary>
    public abstract class AbstractPlatformConnectionTools : AbstractPlatformTools, IPlatformConnectionTools
    {
        public IConnectionHandler ConnectionHandler { get; set; }
        public ICollection<IPlatformConnectionExtension> Extensions { get; set; }

        protected AbstractPlatformConnectionTools(IConnectionHandler connectionHandler, string platformName) :
            base(platformName)
        {
            this.ConnectionHandler = connectionHandler;
        }

        public abstract bool AttachToProcess(Process process, IntPtr windowHandler);
    }
}