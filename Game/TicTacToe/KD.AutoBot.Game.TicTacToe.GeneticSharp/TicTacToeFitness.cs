using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using System;

namespace KD.AutoBot.Game.TicTacToe.GeneticSharp
{
    /// <summary>
    /// Used to calculate fitness - place on the board where to place char.
    /// </summary>
    public class TicTacToeFitness : IFitness
    {
        /// <summary>
        /// Number of minimum same chars in single row or column.
        /// </summary>
        public int Minimum { get; set; }

        public double Evaluate(IChromosome chromosome)
        {
            if (!(chromosome is TicTacToeChromosome))
            {
                throw new ArgumentException("Specififed chromosome must be a derivative of TicTacToeChromosome.", "chromosome");
            }

            double value = this.CalculateNextMove(chromosome as TicTacToeChromosome);
            return value;
        }

        /// <summary>
        /// Returns the value of possible next move.
        /// Next position should be set inside chromosome.
        /// </summary>
        private double CalculateNextMove(TicTacToeChromosome chromosome)
        {
            double[][] board = chromosome.Board;
            // In game board
            Point randomEmptySpace = this.CalculateNextEmptySpace(board);
            // Connect empty space with chromosome
            this.SetEmptySpaceForChromosome(chromosome, randomEmptySpace);
            // Valculate value for specified position
            double positionValue = this.CalculatePositionValue(board, randomEmptySpace);

            return positionValue;
        }

        /// <summary>
        /// Calculates the value of given position in given board.
        /// Return value is a sum of cells around specified point.
        /// </summary>
        private double CalculatePositionValue(double[][] board, Point point)
        {
            double sum = 0;

            // Each possible direction
            for (int x = -1; x < 2; ++x)
            {
                for (int y = -1; y < 2; ++y)
                {
                    if ((x != 0) && (y != 0)) // Prevent from infinite loop
                    {
                        sum += this.CalculateVectorValue(board, point, x, y);
                    }
                }
            }

            return sum;
        }

        private double CalculateVectorValue(double[][] board, Point point, int x, int y)
        {
            int vectorX = point.X, vectorY = point.Y;
            int addedTimes = 0;
            double value = 0;
            bool canGoForward = true;

            while (canGoForward)
            {
                vectorX += x;
                vectorY += y;

                if ((vectorX < 0) || (vectorX >= board.Length))
                {
                    canGoForward = false;
                }
                else if ((vectorY < 0) || (vectorY >= board[0].Length))
                {
                    canGoForward = false;
                }
                else
                {
                    value += board[vectorX][vectorY];
                    addedTimes++;

                    if (addedTimes >= this.Minimum)
                    {
                        canGoForward = false;
                    }
                }
            }

            return value;
        }

        private double GetValueFromPosition(double[][] board, int x, int y)
        {
            if ((x < 0) || (x >= board.Length)) return 0;
            if ((y < 0) || (y >= board[0].Length)) return 0;
            return board[x][y];
        }

        private void SetEmptySpaceForChromosome(TicTacToeChromosome chromosome, Point point)
        {
            chromosome.Position.X = point.X;
            chromosome.Position.Y = point.Y;
        }

        private Point CalculateNextEmptySpace(double[][] board)
        {
            Random rand = new Random();
            Point point = new Point();
            bool isEmptySpace = false;

            while (!isEmptySpace)
            {
                point.X = rand.Next(board.Length);
                point.Y = rand.Next(board[0].Length);

                if (board[point.X][point.Y] == 0)
                {
                    isEmptySpace = true;
                }
            }

            return point;
        }
    }
}