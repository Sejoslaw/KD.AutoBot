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
            POINT point = new POINT();
            if (NativeMethods.GetCursorPos(out point))
            {
                NativeMethods.ClientToScreen(processHandler, ref point);
                int movedX = point.X + dx;
                int movedY = point.Y + dy;
                NativeMethods.SetCursorPos(movedX, movedY);
            }
        }
    }
}