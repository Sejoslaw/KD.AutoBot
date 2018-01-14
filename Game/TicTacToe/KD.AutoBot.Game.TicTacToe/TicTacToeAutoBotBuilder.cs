namespace KD.AutoBot.Game.TicTacToe
{
    /// <summary>
    /// TicTacToe-specific implementation of <see cref="IAutoBotBuilder"/>.
    /// </summary>
    public class TicTacToeAutoBotBuilder : IAutoBotBuilder
    {
        /// <summary>
        /// Private constructor to force on user to use static method to create new <see cref="IAutoBotBuilder"/>.
        /// </summary>
        private TicTacToeAutoBotBuilder() { }

        public IAutoBot NewBot(object[] args)
        {
            return new TicTacToeAutoBot();
        }

        /// <summary>
        /// Create new Builder used to make new <see cref="IAutoBot"/>.
        /// </summary>
        public static IAutoBotBuilder NewBuilder()
        {
            return new TicTacToeAutoBotBuilder();
        }
    }
}