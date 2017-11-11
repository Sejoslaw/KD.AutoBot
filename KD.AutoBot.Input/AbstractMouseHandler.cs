using System;

namespace KD.AutoBot.Input
{
    /// <summary>
    /// Abstract implementation of <see cref="IMouseHandler"/>.
    /// </summary>
    public abstract class AbstractMouseHandler : BasicDataHolder, IMouseHandler
    {
        public IInputHandler InputHandler { get; }

        public AbstractMouseHandler(IInputHandler inputHandler)
        {
            this.InputHandler = inputHandler;
        }

        public abstract void ClickButton(IntPtr processHandler, uint mouseButton);

        public abstract void Move(IntPtr processHandler, int dx, int dy);
    }
}