using System;
using System.Runtime.InteropServices;

namespace KD.AutoBot.Input.Windows.Native
{
    /// <summary>
    /// Struct representing a 2D Point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct POINT
    {
        public int X;
        public int Y;
    }

    /// <summary>
    /// The INPUT structure is used by SendInput to store information for synthesizing input events such as keystrokes, mouse movement, and mouse clicks.
    /// Declared in Winuser.h, include Windows.h
    /// </summary>
    internal struct INPUT
    {
        /// <summary>
        /// One of the <see cref="WindowsInputType"/>.
        /// </summary>
        public UInt32 Type;

        /// <summary>
        /// The data structure that contains information about the simulated Mouse, Keyboard or Hardware event.
        /// </summary>
        public MOUSEKEYBDHARDWAREINPUT Data;
    }

    /// <summary>
    /// The combined/overlayed structure that includes Mouse, Keyboard and Hardware Input message data.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    internal struct MOUSEKEYBDHARDWAREINPUT
    {
        /// <summary>
        /// The <see cref="MOUSEINPUT"/> definition.
        /// </summary>
        [FieldOffset(0)]
        public MOUSEINPUT Mouse;

        /// <summary>
        /// The <see cref="KEYBDINPUT"/> definition.
        /// </summary>
        [FieldOffset(0)]
        public KEYBDINPUT Keyboard;

        /// <summary>
        /// The <see cref="HARDWAREINPUT"/> definition.
        /// </summary>
        [FieldOffset(0)]
        public HARDWAREINPUT Hardware;
    }

    /// <summary>
    /// The MOUSEINPUT structure contains information about a simulated mouse event.
    /// Declared in Winuser.h, include Windows.h
    /// </summary>
    internal struct MOUSEINPUT
    {
        /// <summary>
        /// Specifies the absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. 
        /// Absolute data is specified as the x coordinate of the mouse; relative data is specified as the number of pixels moved. 
        /// </summary>
        public Int32 X;

        /// <summary>
        /// Specifies the absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. 
        /// Absolute data is specified as the y coordinate of the mouse; relative data is specified as the number of pixels moved. 
        /// </summary>
        public Int32 Y;

        /// <summary>
        /// If dwFlags contains MOUSEEVENTF_WHEEL, then mouseData specifies the amount of wheel movement. 
        /// A positive value indicates that the wheel was rotated forward, away from the user; 
        /// A negative value indicates that the wheel was rotated backward, toward the user. 
        /// One wheel click is defined as WHEEL_DELTA, which is 120. 
        /// </summary>
        public UInt32 MouseData;

        /// <summary>
        /// A set of bit flags that specify various aspects of mouse motion and button clicks. 
        /// The bits in this member can be any reasonable combination of the following values. 
        /// The bit flags that specify mouse button status are set to indicate changes in status, not ongoing conditions. 
        /// For example, if the left mouse button is pressed and held down, MOUSEEVENTF_LEFTDOWN is set when the left button is first pressed, but not for subsequent motions. 
        /// Similarly, MOUSEEVENTF_LEFTUP is set only when the button is first released. 
        /// You cannot specify both the MOUSEEVENTF_WHEEL flag and either MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP flags simultaneously in the dwFlags parameter, 
        /// because they both require use of the mouseData field. 
        /// </summary>
        public UInt32 Flags;

        /// <summary>
        /// Time stamp for the event, in milliseconds. If this parameter is 0, the system will provide its own time stamp. 
        /// </summary>
        public UInt32 Time;

        /// <summary>
        /// Specifies an additional value associated with the mouse event.
        /// </summary>
        public IntPtr ExtraInfo;
    }

    /// <summary>
    /// The KEYBDINPUT structure contains information about a simulated keyboard event.
    /// Declared in Winuser.h, include Windows.h
    /// </summary>
    internal struct KEYBDINPUT
    {
        /// <summary>
        /// Specifies a virtual-key code. 
        /// The code must be a value in the range 1 to 254. 
        /// The Winuser.h header file provides macro definitions (VK_*) for each value. 
        /// If the dwFlags member specifies KEYEVENTF_UNICODE, wVk must be 0. 
        /// </summary>
        public UInt16 KeyCode;

        /// <summary>
        /// Specifies a hardware scan code for the key. 
        /// If dwFlags specifies KEYEVENTF_UNICODE, wScan specifies a Unicode character which is to be sent to the foreground application. 
        /// </summary>
        public UInt16 Scan;

        /// <summary>
        /// Specifies various aspects of a keystroke. This member can be certain combinations of the following values.
        /// KEYEVENTF_EXTENDEDKEY - If specified, the scan code was preceded by a prefix byte that has the value 0xE0 (224).
        /// KEYEVENTF_KEYUP - If specified, the key is being released. If not specified, the key is being pressed.
        /// KEYEVENTF_SCANCODE - If specified, wScan identifies the key and wVk is ignored.
        /// </summary>
        public UInt32 Flags;

        /// <summary>
        /// Time stamp for the event, in milliseconds. If this parameter is zero, the system will provide its own time stamp. 
        /// </summary>
        public UInt32 Time;

        /// <summary>
        /// Specifies an additional value associated with the keystroke.
        /// </summary>
        public IntPtr ExtraInfo;
    }

    /// <summary>
    /// The HARDWAREINPUT structure contains information about a simulated message generated by an input device other than a keyboard or mouse.
    /// Declared in Winuser.h, include Windows.h
    /// </summary>
    internal struct HARDWAREINPUT
    {
        /// <summary>
        /// Value specifying the message generated by the input hardware. 
        /// </summary>
        public UInt32 Msg;

        /// <summary>
        /// Specifies the low-order word of the lParam parameter for uMsg. 
        /// </summary>
        public UInt16 ParamL;

        /// <summary>
        /// Specifies the high-order word of the lParam parameter for uMsg. 
        /// </summary>
        public UInt16 ParamH;
    }
}