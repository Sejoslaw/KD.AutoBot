using KD.AutoBot.Connection;
using KD.AutoBot.Connection.Windows;
using System;
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
            var windowsConnectionTools = new WindowsPlatformConnectionTools(null);
            var connectionHandler = new WindowsConnectionHandler(null, windowsConnectionTools);
            windowsConnectionTools.ConnectionHandler = connectionHandler;

            connectionHandler.AttachToProcess(notepadProcess1);
            connectionHandler.AttachToProcess(notepadProcess2);

            // Print all connected processes
            for (int i = 0; i < connectionHandler.ConnectedProcesses.Count; ++i)
            {
                IConnectedProcess connectedProcess = connectionHandler.ConnectedProcesses.ElementAt(i);
                Process process = connectedProcess.Process;
                Console.WriteLine($"{ i }. { process.ProcessName }, ProcessId: { process.Id }");
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
