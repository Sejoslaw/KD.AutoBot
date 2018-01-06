namespace KD.AutoBot.Game.TicTacToe.GeneticSharp
{
    /// <summary>
    /// Represents 2D point.
    /// </summary>
    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {
            this.X = 0;
            this.Y = 0;
        }
    }
}