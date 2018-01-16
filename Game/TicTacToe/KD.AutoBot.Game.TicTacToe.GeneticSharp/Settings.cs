using System.Configuration;

namespace KD.AutoBot.Game.TicTacToe.GeneticSharp
{
    /// <summary>
    /// Used for storing configuration manager.
    /// </summary>
    public static class Settings
    {
        public static int BoardSize
        {
            get
            {
                string boardSize = ConfigurationManager.AppSettings["board_size"] ?? "3";
                int boardSizeValue = int.Parse(boardSize);
                return boardSizeValue;
            }
        }
    }
}