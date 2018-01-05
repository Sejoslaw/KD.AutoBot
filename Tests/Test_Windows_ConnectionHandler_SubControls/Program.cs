using KD.AutoBot.Connection.Extensions;
using KD.AutoBot.Connection.Windows.Extensions;
using KD.AutoBot.Connection.Windows.Native;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_Windows_ConnectionHandler_SubControls
{
    class Program
    {
        static void Main(string[] args)
        {
            IntPtr windowHandle = NativeMethodsHelper.GetWindowByTitle("Test Form");

            /*
             * Test sub-controls of a window.
             */
            IWindowControlHandler windowsControlHandler = new WindowControlHandler(null);
            IWindowControl window = windowsControlHandler.GetWindowControl(windowHandle);
            IEnumerable<IWindowControl> childs = window.GetChildControls();

            object windowTitle = window.GetControlValue();
            Console.WriteLine($"Window title: { windowTitle }");

            Console.WriteLine($"Child controls values:");
            for (int i = 0; i < childs.Count(); ++i)
            {
                IWindowControl child = childs.ElementAt(i);
                object childControlValue = child.GetControlValue();
                Console.WriteLine($"{ i } - { childControlValue }");

                // Test button clicking.
                if (childControlValue.Equals("Test Button Text"))
                {
                    child.Click();
                }
            }

            for (int i = 0; i < childs.Count(); ++i)
            {
                IEnumerable<IWindowControl> childChilds = childs.ElementAt(i).GetChildControls();
                Console.WriteLine("");
            }
        }
    }
}