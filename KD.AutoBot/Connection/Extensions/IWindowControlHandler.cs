using System;

namespace KD.AutoBot.Connection.Extensions
{
    /// <summary>
    /// Used to get single window control from connected process.
    /// </summary>
    public interface IWindowControlHandler : IPlatformConnectionExtension
    {
        /// <summary>
        /// Returns control from connected process.
        /// </summary>
        IWindowControl GetWindowsControl(IntPtr process);
    }
}