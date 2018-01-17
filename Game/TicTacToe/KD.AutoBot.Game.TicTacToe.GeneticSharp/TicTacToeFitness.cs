using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using KD.AutoBot.Game.TicTacToe.GeneticSharp.Utilities;
using KD.AutoBot.Game.TicTacToe.Settings;
using System;
using static KD.AutoBot.Game.TicTacToe.GeneticSharp.Utilities.Vector<double>;

namespace KD.AutoBot.Game.TicTacToe.GeneticSharp
{
    /// <summary>
    /// Used to calculate fitness - place on the board where to place char.
    /// Everything is counted for board with size (N x N).
    /// </summary>
    internal class TicTacToeFitness : IFitness
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
            double positionValue = 0;

            double[][] board = chromosome.Board;
            // In game board
            Point randomEmptySpace = this.CalculateNextEmptySpace(board);
            // Connect empty space with chromosome
            this.SetEmptySpaceForChromosome(chromosome, randomEmptySpace);
            // Valculate value for specified position
            positionValue = this.CalculatePositionValue(board, randomEmptySpace);

            return positionValue;
        }

        private double CalculatePositionValue(double[][] board, Point point)
        {
            Vector<double> vector = null;
            // Up - Down
            vector = Vector<double>.FromDirectionPair(board, point, 0, 1);
            if (vector.NumberOfContainedValues(TttSettings.ENEMY_CHAR_VALUE) == this.Minimum - 1)
            {
                return this.CalculateValueTotalWeight(vector, TttSettings.ENEMY_CHAR_VALUE);
            }

            // Up-Right - Left-Down
            vector = Vector<double>.FromDirectionPair(board, point, 1, 1);
            if (vector.NumberOfContainedValues(TttSettings.ENEMY_CHAR_VALUE) == this.Minimum - 1)
            {
                return this.CalculateValueTotalWeight(vector, TttSettings.ENEMY_CHAR_VALUE);
            }

            // Right - Left
            vector = Vector<double>.FromDirectionPair(board, point, 1, 0);
            if (vector.NumberOfContainedValues(TttSettings.ENEMY_CHAR_VALUE) == this.Minimum - 1)
            {
                return this.CalculateValueTotalWeight(vector, TttSettings.ENEMY_CHAR_VALUE);
            }

            // Right-Down - Left-Up
            vector = Vector<double>.FromDirectionPair(board, point, 1, -1);
            if (vector.NumberOfContainedValues(TttSettings.ENEMY_CHAR_VALUE) == this.Minimum - 1)
            {
                return this.CalculateValueTotalWeight(vector, TttSettings.ENEMY_CHAR_VALUE);
            }

            return 0;
        }

        private double CalculateValueTotalWeight(Vector<double> vector, double value)
        {
            double sum = 0;
            for (int i = 0; i < vector.Length; ++i)
            {
                VectorElement element = vector[i];
                if (element.Value == value)
                {
                    sum += (1 / (element.Value * element.Weight));
                }
            }
            return sum;
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