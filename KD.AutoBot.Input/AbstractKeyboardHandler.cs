using System;
using System.Collections.Generic;

namespace KD.AutoBot.Input
{
    /// <summary>
    /// Abstract implementation of <see cref="IKeyboardHandler"/>.
    /// </summary>
    public abstract class AbstractKeyboardHandler : BasicDataHolder, IKeyboardHandler
    {
        public IInputHandler InputHandler { get; }

        public IPlatformInputTools PlatformInputTools { get; }

        public ICollection<IKeyDescription> AvailableKeys { get; }

        public AbstractKeyboardHandler(IInputHandler inputHandler, IPlatformInputTools platformInputTools) :
            this(inputHandler, platformInputTools, new HashSet<IKeyDescription>())
        {
        }

        public AbstractKeyboardHandler(IInputHandler inputHandler, IPlatformInputTools platformInputTools, ICollection<IKeyDescription> availableKeys)
        {
            this.InputHandler = inputHandler;
            this.PlatformInputTools = platformInputTools;
            this.AvailableKeys = availableKeys;
        }

        public abstract void PressKey(IntPtr processHandler, int keyCode);

        public abstract void ReleaseKey(IntPtr processHandler, int keyCode);
    }
}