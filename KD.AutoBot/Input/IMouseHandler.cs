using System;

namespace KD.AutoBot.Input
{
    /// <summary>
    /// Handler for mouse events.
    /// </summary>
    public interface IMouseHandler : IDevice
    {
        /// <summary>
        /// Describes the functionality for moving mouse.
        /// Where: dx and dy are values for how many mouse will move.
        /// </summary>
        void Move(IntPtr processHandler, int dx, int dy);
        /// <summary>
        /// Clicks specified button on mouse.
        /// </summary>
        void ClickButton(IntPtr processHandler, uint mouseButton);
    }
}