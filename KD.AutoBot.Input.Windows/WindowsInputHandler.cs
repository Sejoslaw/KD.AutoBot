namespace KD.AutoBot.Input.Windows
{
    /// <summary>
    /// Windows implementation of <see cref="IInputHandler"/>.
    /// </summary>
    public class WindowsInputHandler : AbstractInputHandler
    {
        public WindowsInputHandler(IAutoBot bot, IKeyboardHandler keyboard, IMouseHandler mouse) :
            base(bot, keyboard, mouse)
        {
        }
    }
}