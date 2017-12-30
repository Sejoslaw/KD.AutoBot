using System;
using System.Drawing;

namespace Game_TicTacToe
{
    /// <summary>
    /// Holds TicTacToe game logic.
    /// </summary>
    public class TicTacToeGame
    {
        /// <summary>
        /// Default color of the buttons.
        /// </summary>
        public Color DefaultButtonsColor { get; }
        /// <summary>
        /// Players.
        /// </summary>
        public Player[] Players { get; }
        /// <summary>
        /// Currently playing Player.
        /// </summary>
        public Player CurrentPlayer { get; private set; }

        public TicTacToeGame(Color defaultButtonsColor)
        {
            this.DefaultButtonsColor = defaultButtonsColor;

            this.Players = new Player[2];
            this.Players[0] = new Player("X", Color.Red);
            this.Players[1] = new Player("O", Color.Green);

            this.NewGame();
        }

        /// <summary>
        /// Used to restart game without points dropping.
        /// </summary>
        public void RestartGame()
        {
            this.CurrentPlayer = this.Players[new Random().Next(2)];
        }

        /// <summary>
        /// Starts new game - restart everything.
        /// </summary>
        public void NewGame()
        {
            foreach (Player player in this.Players)
            {
                player.Points = 0;
            }
        }

        /// <summary>
        /// Starts new turn - switch current player.
        /// </summary>
        public void NextTurn()
        {
            if (this.CurrentPlayer == null)
            {
                this.CurrentPlayer = this.Players[0];
            }
            else if (this.CurrentPlayer == this.Players[0])
            {
                this.CurrentPlayer = this.Players[1];
            }
            else if (this.CurrentPlayer == this.Players[1])
            {
                this.CurrentPlayer = this.Players[0];
            }
        }

        /// <summary>
        /// Returns true if the current player, after his move, won the game; otherwise false.
        /// </summary>
        public bool CheckWinCondition(string[][] gameGrid)
        {
            // Check by Row
            foreach (string[] row in gameGrid)
            {
                if (this.CheckRow(row))
                {
                    return true;
                }
            }

            // Check by Column
            for (int i = 0; i < gameGrid.Length; ++i)
            {
                if (this.CheckColumn(gameGrid, i))
                {
                    return true;
                }
            }

            // Check cross
            if (this.CheckCross(gameGrid))
            {
                return true;
            }

            return false;
        }

        private bool CheckCross(string[][] gameGrid)
        {
            // First cross - \
            if (this.CheckCrossTopLeft(gameGrid))
            {
                return true;
            }

            // Second cross - /
            if (this.CheckCrossTopRight(gameGrid))
            {
                return true;
            }

            return false;
        }

        private bool CheckCrossTopRight(string[][] gameGrid)
        {
            string model = gameGrid[0][gameGrid.Length - 1];
            int size = gameGrid.Length;

            if (model.Equals(""))
            {
                return false;
            }

            for (int i = 0; i < size; ++i)
            {
                int j = Math.Abs((size - i) - 1);
                if (!model.Equals(gameGrid[i][j]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckCrossTopLeft(string[][] gameGrid)
        {
            string model = gameGrid[0][0];

            if (model.Equals(""))
            {
                return false;
            }

            for (int i = 1; i < gameGrid.Length; ++i)
            {
                if (!model.Equals(gameGrid[i][i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckColumn(string[][] gameGrid, int index)
        {
            string model = gameGrid[0][index];

            if (model.Equals(""))
            {
                return false;
            }

            for (int i = 0; i < gameGrid[0].Length; ++i)
            {
                if (!model.Equals(gameGrid[i][index]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckRow(string[] row)
        {
            string model = row[0];

            if (model.Equals(""))
            {
                return false;
            }

            for (int i = 1; i < row.Length; ++i)
            {
                if (!model.Equals(row[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}