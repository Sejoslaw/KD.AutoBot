using System.Collections.Generic;

namespace KD.AutoBot.Input
{
    /// <summary>
    /// Abstract implementation of <see cref="IInputHandler"/>.
    /// </summary>
    public abstract class AbstractInputHandler : AbstractModule, IInputHandler
    {
        public IKeyboardHandler Keyboard { get; set; }
        public IMouseHandler Mouse { get; set; }
        public ICollection<IDevice> Devices { get; set; }

        protected AbstractInputHandler(IAutoBot bot, IKeyboardHandler keyboard, IMouseHandler mouse, ICollection<IDevice> devices) :
            base(bot)
        {
            this.Keyboard = keyboard;
            this.Mouse = mouse;
            this.Devices = devices;
        }

        public override void Initialize()
        {
            foreach (IDevice device in this.Devices)
            {
                device.Initialize();
            }
        }
    }
}