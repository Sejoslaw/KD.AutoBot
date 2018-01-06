using KD.AutoBot.Connection.Extensions;
using System;

namespace KD.AutoBot.Connection.Windows.Extensions
{
    /// <summary>
    /// Windows specific implementation of <see cref="IWindowControlHandler"/>.
    /// </summary>
    [Serializable]
    public class WindowControlHandler : AbstractWindowControlHandler
    {
        public WindowControlHandler(IPlatformConnectionTools platformConnectionTools) :
            base(platformConnectionTools)
        {
        }

        public override IWindowControl GetWindowControl(IntPtr process)
        {
            IWindowControl windowsControl = new WindowControl(process, null);
            return windowsControl;
        }
    }
}