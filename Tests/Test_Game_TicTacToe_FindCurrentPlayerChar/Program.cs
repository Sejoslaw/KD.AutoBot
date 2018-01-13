using KD.AutoBot.Connection.Extensions;
using KD.AutoBot.Connection.Windows.Extensions;
using KD.AutoBot.Connection.Windows.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Game_TicTacToe_FindCurrentPlayerChar
{
    class Program
    {
        static void Main(string[] args)
        {
            IntPtr windowPtr = NativeMethodsHelper.GetWindowByTitle("TicTacToe");

            // Find TextBox with current player char
            IWindowControl windowControl = new WindowControl(windowPtr, null);
            IEnumerable<IWindowControl> groupBoxes = windowControl.GetChildControls();
            PrintTexts(groupBoxes, 1);
            IWindowControl control = NativeMethodsHelper.GetWindowControlByText(windowControl, "Current Player Turn");
            string text = control.GetControlValue().ToString();
            Console.WriteLine(text);

            // Check current player char
            IWindowControl charControl = control.GetChildControls().FirstOrDefault();
            string tttChar = charControl.GetControlValue().ToString();
            Console.WriteLine(tttChar);

            Console.ReadKey();
        }

        static void PrintTexts(IEnumerable<IWindowControl> controls, int level)
        {
            for (int i = 0; i < controls.Count(); ++i)
            {
                IWindowControl groupBox = controls.ElementAt(i);
                object groupBoxValue = groupBox.GetControlValue();
                string groupBoxText = groupBoxValue.ToString();

                StringBuilder builder = new StringBuilder();
                for (int j = 0; j < level; ++j)
                {
                    builder.Append("-");
                }

                Console.WriteLine($"{ i }. { builder.ToString() } { groupBoxText }");
                PrintTexts(groupBox.GetChildControls(), level + 1);
            }
        }
    }
}
