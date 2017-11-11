using System;
using System.Collections.Generic;

namespace KD.AutoBot.Input
{
    /// <summary>
    /// Abstract implementation of <see cref="IPlatformInputTools"/>.
    /// </summary>
    public abstract class AbstractPlatformInputTools : BasicDataHolder, IPlatformInputTools
    {
        public IKeyboardHandler KeyboardHandler { get; }

        public string PlatformName { get; }

        public AbstractPlatformInputTools(IKeyboardHandler keyboardHandler, string platformName)
        {
            this.KeyboardHandler = keyboardHandler;
            this.PlatformName = platformName;
        }

        public abstract void SendKeyPressed(IntPtr processHandler, int keyCode);

        public abstract void SendKeyReleased(IntPtr processHandler, int keyCode);

        public abstract void SendKeyPressed(IntPtr processHandler, IEnumerable<int> keyCode);

        public abstract void SendKeyReleased(IntPtr processHandler, IEnumerable<int> keyCode);

        public abstract void SendTextInput(IntPtr processHandler, string text);
    }
}