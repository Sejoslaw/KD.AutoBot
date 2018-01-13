using KD.AutoBot.Connection.Windows.Native;
using System;
using System.Diagnostics;

namespace Test_Game_TicTacToe_ConnectToGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<IntPtr, Process> gameProcess = NativeMethodsHelper.ConnectAutoBotToProcess(null, "TicTacToe");

            Console.WriteLine($"Native Process Id = { gameProcess.Item1.ToInt32() }");
            Console.WriteLine($"Process Id = { gameProcess.Item2.Id }");
            Console.WriteLine($"Process Name = { gameProcess.Item2.ProcessName }");

            Console.ReadKey();
        }
    }
}
