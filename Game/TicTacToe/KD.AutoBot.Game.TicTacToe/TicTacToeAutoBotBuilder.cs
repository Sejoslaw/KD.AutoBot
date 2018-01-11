namespace KD.AutoBot.Game.TicTacToe
{
    /// <summary>
    /// TicTacToe-specific implementation of <see cref="IAutoBotBuilder"/>.
    /// </summary>
    public class TicTacToeAutoBotBuilder : IAutoBotBuilder
    {
        public IAutoBot NewBot(object[] args)
        {
            return new TicTacToeAutoBot();
        }
    }
}