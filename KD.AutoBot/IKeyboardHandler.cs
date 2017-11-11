using System;
using System.Collections.Generic;

namespace KD.AutoBot
{
    /// <summary>
    /// Handler for keyboard events.
    /// </summary>
    public interface IKeyboardHandler : IDataHolder
    {
        /// <summary>
        /// Input Handler connected with this Keyboard Handler.
        /// </summary>
        IInputHandler InputHandler { get; }
        /// <summary>
        /// Platform-specific input tools available for Bot.
        /// </summary>
        IPlatformInputTools PlatformInputTools { get; }
        /// <summary>
        /// Collection of available keys for current Input Handler.
        /// </summary>
        ICollection<IKeyDescription> AvailableKeys { get; }

        /// <summary>
        /// Simulates Bot pressing key in specified process by given key code.
        /// </summary>
        void PressKey(IntPtr processHandler, int keyCode);
        /// <summary>
        /// Simulates Bot pressing multiple keys at once. For example: CTRL-C.
        /// </summary>
        void PressKey(IntPtr processHandler, IEnumerable<int> keyCode);
        /// <summary>
        /// Simulates Bot releasing key in specified process by given key code.
        /// </summary>
        void ReleaseKey(IntPtr processHandler, int keyCode);
        /// <summary>
        /// Simulates Bot releasing multiple keys.
        /// </summary>
        void ReleaseKey(IntPtr processHandler, IEnumerable<int> keyCode);
        /// <summary>
        /// Simulates Bot inputing text.
        /// </summary>
        void InputText(IntPtr processHandler, string text);
    }
}