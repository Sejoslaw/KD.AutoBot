using KD.AutoBot;
using KD.AutoBot.Game.TicTacToe;
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
            autoBot.StartBot();
        }
    }
}