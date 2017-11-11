using KD.AutoBot.Input.Windows.Native;
using System;

namespace KD.AutoBot.Input.Windows
{
    /// <summary>
    /// Windows implementation of <see cref="IMouseHandler"/>.
    /// </summary>
    public class WindowsMouseHandler : AbstractMouseHandler
    {
        public WindowsMouseHandler(IInputHandler inputHandler) :
            base(inputHandler)
        {
        }

        public override void ClickButton(IntPtr processHandler, uint mouseButton)
        {
            NativeMethods.mouse_event(mouseButton, 0, 0, 0, UIntPtr.Zero);
        }

        public override void Move(IntPtr processHandler, int dx, int dy)
        {
            var point = new POINT();
            if (NativeMethods.GetCursorPos(out point))
            {
                NativeMethods.ClientToScreen(processHandler, ref point);
                var movedX = point.X + dx;
                var movedY = point.Y + dy;
                NativeMethods.SetCursorPos(movedX, movedY);
            }
        }
    }
}