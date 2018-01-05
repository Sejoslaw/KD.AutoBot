using KD.AutoBot.Input.Windows.Native;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;

namespace KD.AutoBot.Input.Windows
{
    /// <summary>
    /// Windows Implementation of <see cref="IPlatformInputTools"/>.
    /// </summary>
    public class WindowsPlatformInputTools : AbstractPlatformInputTools
    {
        public WindowsPlatformInputTools(IKeyboardHandler keyboardHandler) :
            base(keyboardHandler, "Windows")
        {
        }

        public override void SendTextInput(IntPtr processHandler, string text)
        {
            this.SendNative<char>(text, this.GetInputFromChar);
        }

        public override void SendKeyPressed(IntPtr processHandler, int keyCode)
        {
            this.SendKeyPressed(processHandler, new int[] { keyCode });
        }

        public override void SendKeyReleased(IntPtr processHandler, int keyCode)
        {
            this.SendKeyReleased(processHandler, new int[] { keyCode });
        }

        public override void SendKeyPressed(IntPtr processHandler, IEnumerable<int> keyCode)
        {
            this.SendNative<int>(keyCode, this.GetPressedInputFromKeyCode);
        }

        public override void SendKeyReleased(IntPtr processHandler, IEnumerable<int> keyCode)
        {
            this.SendNative<int>(keyCode, this.GetReleasedInputFromKeyCode);
        }

        private void SendNative<T>(IEnumerable<T> inputData, Func<T, INPUT> function)
        {
            var inputs = new List<INPUT>();
            inputData.ToList().ForEach(input =>
            {
                INPUT pressed = function(input);
                inputs.Add(pressed);
            });
            INPUT[] inputsArray = inputs.ToArray();
            NativeMethods.SendInput((uint)inputsArray.Length, inputsArray, Marshal.SizeOf(typeof(INPUT)));
        }

        private bool IsExtendedKey(int keyCode)
        {
            if (keyCode == (int)WindowsKeyCodes.MENU ||
                keyCode == (int)WindowsKeyCodes.LMENU ||
                keyCode == (int)WindowsKeyCodes.RMENU ||
                keyCode == (int)WindowsKeyCodes.CONTROL ||
                keyCode == (int)WindowsKeyCodes.RCONTROL ||
                keyCode == (int)WindowsKeyCodes.INSERT ||
                keyCode == (int)WindowsKeyCodes.DELETE ||
                keyCode == (int)WindowsKeyCodes.HOME ||
                keyCode == (int)WindowsKeyCodes.END ||
                keyCode == (int)WindowsKeyCodes.PRIOR ||
                keyCode == (int)WindowsKeyCodes.NEXT ||
                keyCode == (int)WindowsKeyCodes.RIGHT ||
                keyCode == (int)WindowsKeyCodes.UP ||
                keyCode == (int)WindowsKeyCodes.LEFT ||
                keyCode == (int)WindowsKeyCodes.DOWN ||
                keyCode == (int)WindowsKeyCodes.NUMLOCK ||
                keyCode == (int)WindowsKeyCodes.CANCEL ||
                keyCode == (int)WindowsKeyCodes.SNAPSHOT ||
                keyCode == (int)WindowsKeyCodes.DIVIDE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private INPUT GetInputFromChar(char ch)
        {
            INPUT input = this.GetInputFromKeyCode(0, (UInt16)ch, (UInt32)WindowsKeyboardFlag.Unicode);
            return input;
        }

        private INPUT GetPressedInputFromKeyCode(int keyCode)
        {
            INPUT input = this.GetInputFromKeyCode((UInt16)keyCode, 0, IsExtendedKey(keyCode) ? (UInt32)WindowsKeyboardFlag.ExtendedKey : 0);
            return input;
        }

        private INPUT GetReleasedInputFromKeyCode(int keyCode)
        {
            INPUT input = this.GetInputFromKeyCode((UInt16)keyCode, 0, (UInt32)(IsExtendedKey(keyCode) ? WindowsKeyboardFlag.KeyUp | WindowsKeyboardFlag.ExtendedKey : WindowsKeyboardFlag.KeyUp));
            return input;
        }

        private INPUT GetInputFromKeyCode(int keyCode, ushort scan, uint flags)
        {
            INPUT key = new INPUT
            {
                Type = (UInt32)WindowsInputType.Keyboard,
                Data = new MOUSEKEYBDHARDWAREINPUT
                {
                    Keyboard = new KEYBDINPUT
                    {
                        KeyCode = (UInt16)keyCode,
                        Scan = scan,
                        Flags = flags,
                        Time = 0,
                        ExtraInfo = IntPtr.Zero
                    }
                }
            };
            return key;
        }
    }
}