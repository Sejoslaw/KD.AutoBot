using System;

namespace KD.AutoBot
{
    /// <summary>
    /// Contains events connected with initialization an <see cref="object"/>.
    /// </summary>
    public interface IInitializationEventHandler
    {
        /// <summary>
        /// Event which is fired when current <see cref="object"/> is starting initialization.
        /// </summary>
        event EventHandler OnPreInitialization;
        /// <summary>
        /// Event which is fired when current <see cref="object"/> has started initialization.
        /// </summary>
        event EventHandler OnPostInitialization;
    }
}