using System;

namespace KD.AutoBot.Input
{
    /// <summary>
    /// Abstract implementation of <see cref="IMouseHandler"/>.
    /// </summary>
    public abstract class AbstractMouseHandler : AbstractDevice, IMouseHandler
    {
        public AbstractMouseHandler(IInputHandler inputHandler) :
            base(inputHandler)
        {
        }

        public override void Initialize()
        {
        }

        public abstract void ClickButton(IntPtr processHandler, uint mouseButton);

        public abstract void Move(IntPtr processHandler, int dx, int dy);
    }
}