using System;

namespace KD.AutoBot
{
    /// <summary>
    /// Handler for mouse events.
    /// </summary>
    public interface IMouseHandler : IDataHolder
    {
        /// <summary>
        /// Input Handler connected with this Mouse Handler.
        /// </summary>
        IInputHandler InputHandler { get; }

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