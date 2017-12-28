using KD.AutoBot.Connection.Extensions;
using System;

namespace KD.AutoBot.Connection.Windows.Extensions
{
    /// <summary>
    /// Windows specific implementation of <see cref="IWindowControlHandler"/>.
    /// </summary>
    public class WindowControlHandler : AbstractWindowControlHandler
    {
        public WindowControlHandler(IPlatformConnectionTools platformConnectionTools) :
            base(platformConnectionTools)
        {
        }

        public override IWindowControl GetWindowsControl(IntPtr process)
        {
            IWindowControl windowsControl = new WindowControl(process, null);
            return windowsControl;
        }
    }
}