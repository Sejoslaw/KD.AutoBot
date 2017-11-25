using System;
using System.Collections.Generic;

namespace KD.AutoBot.Input
{
    /// <summary>
    /// Abstract implementation of <see cref="IPlatformInputTools"/>.
    /// </summary>
    public abstract class AbstractPlatformInputTools : AbstractPlatformTools, IPlatformInputTools
    {
        public IKeyboardHandler KeyboardHandler { get; set; }

        public AbstractPlatformInputTools(IKeyboardHandler keyboardHandler, string platformName) :
            base(platformName)
        {
            this.KeyboardHandler = keyboardHandler;
        }

        public abstract void SendKeyPressed(IntPtr processHandler, int keyCode);

        public abstract void SendKeyReleased(IntPtr processHandler, int keyCode);

        public abstract void SendKeyPressed(IntPtr processHandler, IEnumerable<int> keyCode);

        public abstract void SendKeyReleased(IntPtr processHandler, IEnumerable<int> keyCode);

        public abstract void SendTextInput(IntPtr processHandler, string text);
    }
}