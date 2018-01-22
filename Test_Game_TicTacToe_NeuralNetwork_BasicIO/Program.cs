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
            INeuralNetworkBuilder<double> builder = new SigmoidNeuralNetworkBuilder<BackPropagationNeuralNetwork>();
            builder.BuildNetwork(9, new int[] { 9 }, 9); // no hidden layers
            INeuralNetwork<double> network = builder.InitializeNeuralNetworkWithData(new double[] 
            {
                2, 0, 1,
                0, 1, 0,
                2, 0, 0
            }, null, null);
            
            for (int i = 0; i < 2; ++i)
            {
                network.Pulse(null);
            }
            ;
        }
    }
}