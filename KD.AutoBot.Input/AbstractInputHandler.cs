namespace KD.AutoBot.Input
{
    /// <summary>
    /// Abstract implementation of <see cref="IInputHandler"/>.
    /// </summary>
    public abstract class AbstractInputHandler : BasicDataHolder, IInputHandler
    {
        public IAutoBot Bot { get; }

        public IKeyboardHandler Keyboard { get; }

        public IMouseHandler Mouse { get; }

        public AbstractInputHandler(IAutoBot bot, IKeyboardHandler keyboard, IMouseHandler mouse)
        {
            this.Bot = bot;
            this.Keyboard = keyboard;
            this.Mouse = mouse;
        }
    }
}