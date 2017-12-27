using System;
using System.Runtime.InteropServices;

namespace KD.AutoBot.Input.Windows.Native
{
    /// <summary>
    /// Holds native Win32 API calls.
    /// </summary>
    public static class NativeMethods
    {
        /// <summary>
        /// Simulates mouse buttons and wheel event to Screen.
        /// </summary>
        [DllImport("user32.dll")]
        internal static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(out POINT lpPoint);

        /// <summary>
        /// The ClientToScreen API converts the client-area coordinates of a specified point to screen coordinates.
        /// </summary>
        [DllImport("user32.dll")]
        internal static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

        /// <summary>
        /// Sets Cursor position.
        /// </summary>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetCursorPos(int x, int y);

        /// <summary>
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        /// </summary>
        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint inputsLength, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] inputs, int inputStructureSize);

        /// <summary>
        /// Sets the focus to given Window Handler.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SetFocus(IntPtr hWnd);

        /// <summary>
        /// The SetActiveWindow API
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SetActiveWindow(IntPtr hWnd);
    }
}