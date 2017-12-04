using System.Collections.Generic;

namespace KD.AutoBot.Input.Windows
{
    /// <summary>
    /// Windows implementation of <see cref="IInputHandler"/>.
    /// </summary>
    public class WindowsInputHandler : AbstractInputHandler
    {
        public WindowsInputHandler(IAutoBot bot, IKeyboardHandler keyboard, IMouseHandler mouse, ICollection<IDevice> devices) :
            base(bot, keyboard, mouse, devices)
        {
        }
    }
}