using KD.AutoBot.Connection.Windows;
using KD.AutoBot.Connection.Windows.Native;
using System;
using System.Diagnostics;

namespace Test_Game_TicTacToe_ConnectToGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IntPtr windowPtr = NativeMethodsHelper.GetWindowByTitle("TicTacToe");
            Process windowProcess = NativeMethodsHelper.GetProcessByWindowHandler(windowPtr);

            WindowsConnectionHandler connectionHandler = new WindowsConnectionHandler(null);
            connectionHandler.AttachToProcess(windowProcess);

            Console.ReadKey();
        }
    }
}
