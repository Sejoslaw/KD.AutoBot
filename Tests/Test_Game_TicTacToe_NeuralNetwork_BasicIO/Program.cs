using KD.AutoBot.AI.NeuralNetwork;
using KD.AutoBot.AI.NeuralNetwork.Impl.Builders;
using KD.AutoBot.AI.NeuralNetwork.Impl.Networks;
using System;

namespace Test_Game_TicTacToe_NeuralNetwork_BasicIO
{
    class Program
    {
        static void Main(string[] args)
        {
            INeuralNetworkBuilder<double> builder = new SigmoidNeuralNetworkBuilder<GeneticTrainingNeuralNetwork>();
            builder.BuildNetwork(9, null, 1); // no hidden layers
            INeuralNetwork<double> network = builder.InitializeNeuralNetworkWithData(new double[]
            {
                2, 0, 1,
                0, 1, 0,
                2, 0, 0
            }, null, null);
            network.LearningRate = 0.1;

            for (int i = 0; i < 10000; ++i)
            {
                // Calculates Sigmoid Neurons value.
                network.Pulse(null);
                // Function prepared for Genetic Training of Feed Forward Network
                network.ApplyLearning(null);
            }
        }
    }
}