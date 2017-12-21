using System;

namespace KD.AutoBot.Connection.Windows.Extensions
{
    /// <summary>
    /// Used to get single window control from connected process.
    /// </summary>
    public interface IWindowsControlHandler : IPlatformConnectionExtension
    {
        /// <summary>
        /// Returns control from connected process.
        /// </summary>
        IWindowsControl GetWindowsControl(IntPtr process);
    }
}