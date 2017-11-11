using System;
using System.Collections.Generic;

namespace KD.AutoBot.Input.Windows
{
    /// <summary>
    /// Windows implementation of <see cref="IKeyboardHandler"/>.
    /// </summary>
    public class WindowsKeyboardHandler : AbstractKeyboardHandler
    {
        public WindowsKeyboardHandler(IInputHandler inputHandler, IPlatformInputTools platformTools) :
            base(inputHandler, platformTools)
        {
        }

        public WindowsKeyboardHandler(IInputHandler inputHandler, IPlatformInputTools platformInputTools, ICollection<IKeyDescription> availableKeys) :
            base(inputHandler, platformInputTools, availableKeys)
        {
        }

        public override void PressKey(IntPtr processHandler, int keyCode)
        {
            this.PlatformInputTools.SendKeyPressed(processHandler, keyCode);
        }

        public override void PressKey(IntPtr processHandler, IEnumerable<int> keyCode)
        {
            this.PlatformInputTools.SendKeyPressed(processHandler, keyCode);
        }

        public override void ReleaseKey(IntPtr processHandler, int keyCode)
        {
            this.PlatformInputTools.SendKeyReleased(processHandler, keyCode);
        }

        public override void ReleaseKey(IntPtr processHandler, IEnumerable<int> keyCode)
        {
            this.PlatformInputTools.SendKeyReleased(processHandler, keyCode);
        }
    }
}