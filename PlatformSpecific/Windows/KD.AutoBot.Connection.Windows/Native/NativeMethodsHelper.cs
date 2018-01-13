using System;
using System.Diagnostics;
using System.Text;

namespace KD.AutoBot.Connection.Windows.Native
{
    /// <summary>
    /// Contains various helper methods based on native functions.
    /// </summary>
    public static class NativeMethodsHelper
    {
        /// <summary>
        /// Returns text from specified control.
        /// </summary>
        public static string GetControlText(IntPtr control)
        {
            int length = NativeMethods.SendMessage(control, (int)NativeConstants.WM_GETTEXTLENGTH, IntPtr.Zero.ToInt32(), null);
            StringBuilder stringBuilder = new StringBuilder(length + 1);
            NativeMethods.SendMessage(control, (int)NativeConstants.WM_GETTEXT, stringBuilder.Capacity, stringBuilder);
            string controlText = stringBuilder.ToString();
            return controlText;
        }

        /// <summary>
        /// Returns handler to window based on window title.
        /// </summary>
        public static IntPtr GetWindowByTitle(string windowTitle)
        {
            IntPtr window = NativeMethods.FindWindowByCaption(IntPtr.Zero, windowTitle);
            return window;
        }

        /// <summary>
        /// Returns the <see cref="Process"/> using given window handler.
        /// </summary>
        public static Process GetProcessByWindowHandler(IntPtr windowHandler)
        {
            uint processId;
            uint threadThatCreatedWindow = NativeMethods.GetWindowThreadProcessId(windowHandler, out processId);
            Process windowProcess = Process.GetProcessById((int)processId);
            return windowProcess;
        }
    }
}