using System.Collections.Generic;

namespace KD.AutoBot
{
    /// <summary>
    /// Input Handler is used to allow Bot to send keys and mouse events to connected <see cref="System.Diagnostics.Process"/> using specified platform.
    /// </summary>
    public interface IInputHandler : IDataHolder
    {
        /// <summary>
        /// Bot connected with this Handler.
        /// </summary>
        IAutoBot Bot { get; }
        /// <summary>
        /// Platform-specific input tools available for Bot.
        /// </summary>
        ICollection<IPlatformInputTools> PlatformInputTools { get; }
        /// <summary>
        /// Collection of available keys for current Input Handler.
        /// </summary>
        ICollection<IKeyDescription> AvailableKeys { get; }
        /// <summary>
        /// Handler for Mouse events.
        /// </summary>
        IMouseHandler Mouse { get; }

        /// <summary>
        /// Simulates Bot pressing key by given key code.
        /// </summary>
        void PressKey(int keyCode);
        /// <summary>
        /// Returns platform tools for given platform name.
        /// </summary>
        IPlatformInputTools GetPlatformInputTools(string platformName);
    }
}