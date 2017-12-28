using System;

namespace KD.AutoBot.Connection.Windows.Extensions
{
    /// <summary>
    /// Implementation of <see cref="IWindowsControlHandler"/>.
    /// </summary>
    public class WindowsControlHandler : AbstractWindowsControlHandler
    {
        public WindowsControlHandler(IPlatformConnectionTools platformConnectionTools) :
            base(platformConnectionTools)
        {
        }

        public override IWindowsControl GetWindowsControl(IntPtr process)
        {
            IWindowsControl windowsControl = new WindowsControl(process, null);
            return windowsControl;
        }
    }
}