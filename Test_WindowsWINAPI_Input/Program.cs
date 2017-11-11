using KD.AutoBot.Input.Windows;
using KD.AutoBot.Input.Windows.Native;
using System;
using System.Diagnostics;
using System.Threading;

namespace Test_WindowsWINAPI_Input
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use Win32 API

            var notepadProcess = StartNotepad();

            // Sleep to let Notepad start
            Thread.Sleep(100);

            // Test Keyboard Win32 API
            var windowsPlatformInputTools = new WindowsPlatformInputTools(null);

            windowsPlatformInputTools.SendKeyPressed(notepadProcess.MainWindowHandle, (int)WindowsKeyCodes.VK_A);
            windowsPlatformInputTools.SendKeyPressed(notepadProcess.MainWindowHandle, (int)WindowsKeyCodes.VK_U);
            windowsPlatformInputTools.SendKeyPressed(notepadProcess.MainWindowHandle, (int)WindowsKeyCodes.VK_T);
            windowsPlatformInputTools.SendKeyPressed(notepadProcess.MainWindowHandle, (int)WindowsKeyCodes.VK_O);
            windowsPlatformInputTools.SendKeyPressed(notepadProcess.MainWindowHandle, (int)WindowsKeyCodes.VK_B);
            windowsPlatformInputTools.SendKeyPressed(notepadProcess.MainWindowHandle, (int)WindowsKeyCodes.VK_O);
            windowsPlatformInputTools.SendKeyPressed(notepadProcess.MainWindowHandle, (int)WindowsKeyCodes.VK_T);

            // Sleep
            Thread.Sleep(100);

            // Test Mouse Win32 API
            var windowsMouseHandler = new WindowsMouseHandler(null);

            windowsMouseHandler.Move(notepadProcess.MainWindowHandle, 10, 10);
            windowsMouseHandler.Move(notepadProcess.MainWindowHandle, 10, 10);
            windowsMouseHandler.Move(notepadProcess.MainWindowHandle, 10, 10);
            windowsMouseHandler.Move(notepadProcess.MainWindowHandle, 10, 10);
            windowsMouseHandler.Move(notepadProcess.MainWindowHandle, 10, 10);
            windowsMouseHandler.Move(notepadProcess.MainWindowHandle, 10, 10);

            // Mouse left-button click

            windowsMouseHandler.ClickButton(notepadProcess.MainWindowHandle, (uint)WindowsMouseEvent.LeftDown);
            windowsMouseHandler.ClickButton(notepadProcess.MainWindowHandle, (uint)WindowsMouseEvent.LeftUp);
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
            //process.WaitForExit();
            return process;
        }
    }
}