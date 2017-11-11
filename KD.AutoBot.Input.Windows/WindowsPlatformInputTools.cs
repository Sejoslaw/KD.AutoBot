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
            var inputs = new List<INPUT>();
            text.ToList().ForEach(ch =>
            {
                var input = this.GetInputFromChar(ch);
                inputs.Add(input);
            });
            var inputsArray = inputs.ToArray();
            NativeMethods.SendInput((uint)inputsArray.Length, inputsArray, Marshal.SizeOf(typeof(INPUT)));
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
            var inputs = new List<INPUT>();
            keyCode.ToList().ForEach(input =>
            {
                var pressed = this.GetPressedInputFromKeyCode(input);
                inputs.Add(pressed);
            });
            var inputsArray = inputs.ToArray();
            NativeMethods.SendInput((uint)inputsArray.Length, inputsArray, Marshal.SizeOf(typeof(INPUT)));
        }

        public override void SendKeyReleased(IntPtr processHandler, IEnumerable<int> keyCode)
        {
            var inputs = new List<INPUT>();
            keyCode.ToList().ForEach(input =>
            {
                var pressed = this.GetReleasedInputFromKeyCode(input);
                inputs.Add(pressed);
            });
            var inputsArray = inputs.ToArray();
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
            UInt16 code = ch;

            var input = new INPUT
            {
                Type = (UInt32)WindowsInputType.Keyboard,
                Data = new MOUSEKEYBDHARDWAREINPUT
                {
                    Keyboard = new KEYBDINPUT
                    {
                        KeyCode = 0,
                        Scan = code,
                        Flags = (UInt32)WindowsKeyboardFlag.Unicode,
                        Time = 0,
                        ExtraInfo = IntPtr.Zero
                    }
                }
            };
            return input;
        }

        private INPUT GetPressedInputFromKeyCode(int keyCode)
        {
            var key = new INPUT
            {
                Type = (UInt32)WindowsInputType.Keyboard,
                Data = new MOUSEKEYBDHARDWAREINPUT
                {
                    Keyboard = new KEYBDINPUT
                    {
                        KeyCode = (UInt16)keyCode,
                        Scan = 0,
                        Flags = IsExtendedKey(keyCode) ? (UInt32)WindowsKeyboardFlag.ExtendedKey : 0,
                        Time = 0,
                        ExtraInfo = IntPtr.Zero
                    }
                }
            };
            return key;
        }

        private INPUT GetReleasedInputFromKeyCode(int keyCode)
        {
            var key = new INPUT
            {
                Type = (UInt32)WindowsInputType.Keyboard,
                Data = new MOUSEKEYBDHARDWAREINPUT
                {
                    Keyboard = new KEYBDINPUT
                    {
                        KeyCode = (UInt16)keyCode,
                        Scan = 0,
                        Flags = (UInt32)(IsExtendedKey(keyCode) ? WindowsKeyboardFlag.KeyUp | WindowsKeyboardFlag.ExtendedKey : WindowsKeyboardFlag.KeyUp),
                        Time = 0,
                        ExtraInfo = IntPtr.Zero
                    }
                }
            };
            return key;
        }
    }
}