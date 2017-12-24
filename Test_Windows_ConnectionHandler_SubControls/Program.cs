using KD.AutoBot.Connection.Windows.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Test_Windows_ConnectionHandler_SubControls
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = GetProcess();

            /*
             * Test sub-controls of a window.
             */
            IWindowsControlHandler windowsControlHandler = new WindowsControlHandler(null);
            IWindowsControl window = windowsControlHandler.GetWindowsControl(process.MainWindowHandle);
            IEnumerable<IWindowsControl> childs = window.GetChildControls();

            object windowTitle = window.GetControlValue();
            Console.WriteLine($"Window title: { windowTitle }");

            Console.WriteLine($"Child controls values:");
            for (int i = 0; i < childs.Count(); ++i)
            {
                object childControlValue = childs.ElementAt(i).GetControlValue();
                Console.WriteLine($"{ i } - { childControlValue }");
            }

            for (int i = 0; i < childs.Count(); ++i)
            {
                IEnumerable<IWindowsControl> childChilds = childs.ElementAt(i).GetChildControls();
                Console.WriteLine("");
            }
        }

        private static Process GetProcess()
        {
            Process p = Process.Start("notepad");
            return p;
        }
    }
}