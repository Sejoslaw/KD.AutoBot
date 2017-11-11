using System;

namespace KD.AutoBot.Input.Windows.Native
{
    /// <summary>
    /// Specifies various aspects of a keystroke. This member can be certain combinations of the following values.
    /// </summary>
    [Flags]
    public enum WindowsKeyboardFlag : uint
    {
        /// <summary>
        /// KEYEVENTF_EXTENDEDKEY = 0x0001
        /// </summary>
        ExtendedKey = 0x0001,

        /// <summary>
        /// KEYEVENTF_KEYUP = 0x0002
        /// </summary>
        KeyUp = 0x0002,

        /// <summary>
        /// KEYEVENTF_UNICODE = 0x0004
        /// </summary>
        Unicode = 0x0004,

        /// <summary>
        /// KEYEVENTF_SCANCODE = 0x0008
        /// </summary>
        ScanCode = 0x0008
    }
}