using GeneticSharp.Domain.Chromosomes;
using System;

namespace KD.AutoBot.Game.TicTacToe.GeneticSharp
{
    /// <summary>
    /// Chromosome which holds board data.
    /// This chromosome will be used to calculate new best move.
    /// </summary>
    public class TicTacToeChromosome : ChromosomeBase
    {
        /// <summary>
        /// Values from each cell of game board.
        /// 
        /// Values on these cells are as follow:
        /// X - -1
        /// 0 - 1
        /// Empty - 0 (zero)
        /// </summary>
        public double[][] Board { get; private set; }
        /// <summary>
        /// Calculated position which should be set in next move.
        /// 
        /// For example in standard TicTacToe:
        ///  1 | 2 | 3
        /// ---|---|---
        ///  4 | 5 | 6
        /// ---|---|---
        ///  7 | 8 | 9 
        /// </summary>
        public Point Position { get; }

        public TicTacToeChromosome(double[][] board) :
            base(32)
        {
            this.Board = board;
            this.Position = new Point();

            this.CreateGenes();
        }

        public override IChromosome CreateNew()
        {
            return new TicTacToeChromosome(this.Board);
        }

        public override Gene GenerateGene(int geneIndex)
        {
            return new Gene(this.Position);
        }
    }
}