using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KD.AutoBot.Connection
{
    /// <summary>
    /// Describes tools used to connect to single platform.
    /// </summary>
    public interface IPlatformConnectionTools : IPlatformTools
    {
        /// <summary>
        /// Handler connected with this platform tools.
        /// </summary>
        IConnectionHandler ConnectionHandler { get; }
        /// <summary>
        /// Extensions which allow bot to get values from various system elements.
        /// For example: windows controls, system registers, etc.
        /// </summary>
        ICollection<IPlatformConnectionExtension> Extensions { get; }

        /// <summary>
        /// Tries to connect to platform using current tools.
        /// It window handler is unknown, use <see cref="Process.MainWindowHandle"/>.
        /// </summary>
        bool AttachToProcess(Process process, IntPtr windowHandler);
    }
}