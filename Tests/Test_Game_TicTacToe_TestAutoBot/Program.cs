using KD.AutoBot;
using KD.AutoBot.Game.TicTacToe;
using KD.AutoBot.Game.TicTacToe.Settings;
using System;

namespace Test_Game_TicTacToe_TestAutoBot
{
    class Program
    {
        static void Main(string[] args)
        {
            IAutoBotBuilder builder = TicTacToeAutoBotBuilder.NewBuilder();
            IAutoBot autoBot = builder.NewBot(null);
            autoBot.OnPreStart += (sender, eventArgs) =>
            {
                Console.WriteLine("AutoBot starting...");
            };
            autoBot.OnPreRestart += (sender, eventArgs) =>
            {
                Console.WriteLine($"Playing as: { autoBot[TttSettings.TTT_CHAR] }");
            };
            autoBot.StartBot();
        }
    }
}