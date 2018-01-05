﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace Test_XUnitTests_AdditionalTests
{
    public class Tests_GetControlValue
    {
        const int WM_GETTEXT = 0x0D;
        const int WM_GETTEXTLENGTH = 0x0E;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int Param, System.Text.StringBuilder text);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);


        [Fact]
        public void Test_GetControlValue_Idea1()
        {
            //find the "first" window
            IntPtr hWnd = FindWindow("notepad", null);

            while (hWnd != IntPtr.Zero)
            {
                //find the control window that has the text
                IntPtr hEdit = FindWindowEx(hWnd, IntPtr.Zero, "edit", null);

                //initialize the buffer.  using a StringBuilder here
                System.Text.StringBuilder sb = new System.Text.StringBuilder(255);  // or length from call with GETTEXTLENGTH

                //get the text from the child control
                int RetVal = SendMessage(hEdit, WM_GETTEXT, sb.Capacity, sb);
            }

            Console.ReadKey();
        }
    }
}