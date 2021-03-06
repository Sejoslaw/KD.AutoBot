﻿using System.Drawing;

namespace Game_TicTacToe
{
    /// <summary>
    /// Describes single TicTacToe player.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Char used by the player. [X, O]
        /// </summary>
        public string UsedChar { get; }
        /// <summary>
        /// Color connected with this player.
        /// Color used for coloring the button.
        /// </summary>
        public Color Color { get; }
        /// <summary>
        /// Player's points.
        /// </summary>
        public int Points { get; set; }

        public Player(string usedChar, Color color)
        {
            this.UsedChar = usedChar;
            this.Color = color;
            this.Points = 0;
        }
    }
}