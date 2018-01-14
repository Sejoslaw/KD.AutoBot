using KD.AutoBot.Connection.Extensions;
using System;

namespace KD.AutoBot.Connection.Windows.Extensions
{
    public static class ExtensionMethods
    {
        public static IWindowControl ToWindowControl(this IntPtr windowHandle, IWindowControl parentControl = null)
        {
            return new WindowControl(windowHandle, parentControl);
        }
    }
}