using KD.AutoBot.Connection;
using KD.AutoBot.Connection.Extensions;
using KD.AutoBot.Connection.Windows;
using KD.AutoBot.Connection.Windows.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Test_Windows_ConnectionHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            Process notepadProcess1 = StartNotepad();
            Process notepadProcess2 = StartNotepad();

            // Create connection handler and connection tools for Windows with double-side binding.
            var connectionHandler = new WindowsConnectionHandler(null);

            connectionHandler.AttachToProcess(notepadProcess1);
            connectionHandler.AttachToProcess(notepadProcess2);

            // Print all connected processes
            for (int i = 0; i < connectionHandler.ConnectedProcesses.Count; ++i)
            {
                IConnectedProcess connectedProcess = connectionHandler.ConnectedProcesses.ElementAt(i);
                Process process = connectedProcess.Process;
                Console.WriteLine($"{ i }. { process.ProcessName }, ProcessId: { process.Id }");
            }
            Console.WriteLine();

            //
            // Test - Return value from specified control. Use only in-AutoBot relations.
            //
            IWindowControlHandler windowsControlHandler = new WindowControlHandler(connectionHandler.PlatformConnectionTools);
            IConnectedProcess notepad1 = windowsControlHandler.PlatformConnectionTools.ConnectionHandler.ConnectedProcesses.ElementAt(0);
            IWindowControl windowsControl = windowsControlHandler.GetWindowsControl(notepad1.Process.MainWindowHandle);
            IEnumerable<IWindowControl> childs = windowsControl.GetChildControls();

            object controlValue = windowsControl.GetControlValue();
            Console.WriteLine($"Control value: { controlValue }");

            Console.WriteLine($"Child controls values:");
            for (int i = 0; i < childs.Count(); ++i)
            {
                Console.WriteLine($"{ i } - { childs.ElementAt(i).GetControlValue() }");
            }

            Console.ReadKey();
        }

        static Process StartNotepad()
        {
            Console.WriteLine("Starting new process...");
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "notepad.exe"
                }
            };
            process.Start();
            // Sleep to let Notepad start
            Thread.Sleep(100);
            //process.WaitForExit();
            return process;
        }
    }
}