using System;

namespace KD.AutoBot.Connection.Windows.Extensions
{
    /// <summary>
    /// Abstract implementation of <see cref="IWindowsControlHandler"/>.
    /// </summary>
    public abstract class AbstractWindowsControlHandler : BasicDataHolder, IWindowsControlHandler
    {
        public IPlatformConnectionTools PlatformConnectionTools { get; }

        public AbstractWindowsControlHandler(IPlatformConnectionTools platformConnectionTools)
        {
            this.PlatformConnectionTools = platformConnectionTools;
        }

        public abstract IWindowsControl GetWindowsControl(IntPtr process);
    }
}