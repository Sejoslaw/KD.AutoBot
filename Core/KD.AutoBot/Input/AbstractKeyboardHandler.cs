using System;
using System.Collections.Generic;

namespace KD.AutoBot.Input
{
    /// <summary>
    /// Abstract implementation of <see cref="IKeyboardHandler"/>.
    /// </summary>
    public abstract class AbstractKeyboardHandler : AbstractDevice, IKeyboardHandler
    {
        public IPlatformInputTools PlatformInputTools { get; set; }
        public ICollection<IKeyDescription> AvailableKeys { get; set; }

        protected AbstractKeyboardHandler(IInputHandler inputHandler, IPlatformInputTools platformInputTools) :
            this(inputHandler, platformInputTools, new HashSet<IKeyDescription>())
        {
        }

        protected AbstractKeyboardHandler(IInputHandler inputHandler, IPlatformInputTools platformInputTools, ICollection<IKeyDescription> availableKeys) :
            base(inputHandler)
        {
            this.PlatformInputTools = platformInputTools;
            this.AvailableKeys = availableKeys;
        }

        public override void Initialize()
        {
        }

        public abstract void PressKey(IntPtr processHandler, int keyCode);

        public abstract void ReleaseKey(IntPtr processHandler, int keyCode);

        public abstract void PressKey(IntPtr processHandler, IEnumerable<int> keyCode);

        public abstract void ReleaseKey(IntPtr processHandler, IEnumerable<int> keyCode);

        public abstract void InputText(IntPtr processHandler, string text);
    }
}