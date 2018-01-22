using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using KD.AutoBot.Game.TicTacToe.GeneticSharp;
using System;

namespace Test_Game_TicTacToe_FitnessFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * Example board.
             * 
             * Where:
             * X - -1
             * O - 1
             * Empty - 0 (zero)
             */
            //double[][] board = new double[3][];
            //board[0] = new double[] { 0, 0, 0 };
            //board[1] = new double[] { 0, 0, 0 };
            //board[2] = new double[] { 0, 0, 0 };

            //var chromosome = new TicTacToeChromosome(board);
            //var population = new Population(50, 100, chromosome);
            //var fitness = new TicTacToeFitness()
            //{
            //    Minimum = 3
            //};
            //var selection = new EliteSelection();
            //var crossover = new UniformCrossover(0.5f);
            //var mutation = new UniformMutation();
            //var termination = new OrTermination(new ITermination[]
            //{
            //    new FitnessStagnationTermination(1000),
            //    new FitnessThresholdTermination(4),
            //    new FitnessThresholdTermination(3),
            //    new FitnessThresholdTermination(2)
            //});

            //var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
            //{
            //    Termination = termination
            //};

            //Console.WriteLine("Generation: Position (x, y) = move value");

            //ga.GenerationRan += (sender, e) =>
            //{
            //    var bestChromosome = ga.BestChromosome as TicTacToeChromosome;
            //    var bestFitness = bestChromosome.Fitness;
            //    Console.WriteLine($"Generation { ga.GenerationsNumber }: Position ({ bestChromosome.Position.X }, { bestChromosome.Position.Y }) = { bestFitness }");
            //};

            //ga.Start();

            //Console.WriteLine("Finished.");
            //Console.ReadKey();
        }
    }
}