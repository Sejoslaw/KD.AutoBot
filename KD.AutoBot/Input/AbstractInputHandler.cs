namespace KD.AutoBot.Input
{
    /// <summary>
    /// Abstract implementation of <see cref="IInputHandler"/>.
    /// </summary>
    public abstract class AbstractInputHandler : AbstractModule, IInputHandler
    {
        public IKeyboardHandler Keyboard { get; set; }

        public IMouseHandler Mouse { get; set; }

        public AbstractInputHandler(IAutoBot bot, IKeyboardHandler keyboard, IMouseHandler mouse) :
            base(bot)
        {
            this.Keyboard = keyboard;
            this.Mouse = mouse;
        }

        public override void Initialize()
        {
        }
    }
}