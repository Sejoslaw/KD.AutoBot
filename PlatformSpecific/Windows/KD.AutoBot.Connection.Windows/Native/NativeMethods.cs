﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace KD.AutoBot.Connection.Windows.Native
{
    /// <summary>
    /// Holds native Win32 API calls.
    /// </summary>
    internal static class NativeMethods
    {
        public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

        /// <summary>
        /// Enumerates the child windows that belong to the specified parent window by passing the handle to each child window, 
        /// in turn, to an application-defined callback function.
        /// </summary>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// Retrieves the identifier of the specified control.
        /// </summary>
        [DllImport("user32.dll")]
        public static extern int GetDlgCtrlID(IntPtr hwndCtl);

        /// <summary>
        /// Retrieves a handle to a control in the specified dialog box.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetDlgItem(IntPtr hDlg, int nIDDlgItem);

        /// <summary>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer. 
        /// If the specified window is a control, the text of the control is copied. 
        /// However, GetWindowText cannot retrieve the text of a control in another application.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// Used for communication with control.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int Param, StringBuilder text);

        /// <summary>
        /// Used mainly in button pressing.
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings. 
        /// This function does not search child windows. 
        /// This function does not perform a case-sensitive search.
        /// 
        /// To search child windows, beginning with a specified child window, use the FindWindowEx function.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string className, string windowTitle);

        /// <summary>
        /// Retrieves a handle to a window whose class name and window name match the specified strings. 
        /// The function searches child windows, beginning with the one following the specified child window. 
        /// This function does not perform a case-sensitive search.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        /// <summary>
        /// Returns main window handle by specified window title.
        /// </summary>
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(IntPtr zeroOnly, string lpWindowName);

        /// <summary>
        /// Retrieves the identifier of the thread that created the specified window and, optionally, the identifier of the process that created the window.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        /// <summary>
        /// When you don't want the ProcessId, use this overload and pass IntPtr.Zero for the second parameter
        /// </summary>
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
    }
}