using System;

namespace KD.AutoBot.Connection.Extensions
{
    /// <summary>
    /// Abstract implementation of <see cref="IWindowControlHandler"/>.
    /// </summary>
    public abstract class AbstractWindowControlHandler : BasicDataHolder, IWindowControlHandler
    {
        public IPlatformConnectionTools PlatformConnectionTools { get; }

        public AbstractWindowControlHandler(IPlatformConnectionTools platformConnectionTools)
        {
            this.PlatformConnectionTools = platformConnectionTools;
        }

        public abstract IWindowControl GetWindowControl(IntPtr process);
    }
}