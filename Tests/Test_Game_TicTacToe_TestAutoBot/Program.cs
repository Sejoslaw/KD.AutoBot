using KD.AutoBot;
using KD.AutoBot.Game.TicTacToe;

namespace Test_Game_TicTacToe_TestAutoBot
{
    class Program
    {
        static void Main(string[] args)
        {
            IAutoBotBuilder builder = TicTacToeAutoBotBuilder.NewBuilder();
            IAutoBot autoBot = builder.NewBot(null);
            autoBot.StartBot();
        }
    }
}