using KD.AutoBot.AI.NeuralNetwork;
using KD.AutoBot.AI.NeuralNetwork.Impl.Builders;
using KD.AutoBot.AI.NeuralNetwork.Impl.Networks;
using System;

namespace Test_NeuralNetwork_BasicNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prepare Neural Network
            double[] input = new double[]
            {
                2, 1, 2,
                1, 0, 0,
                0, 2, 0
            };
            INeuralNetworkBuilder<double> builder = new DoubleNeuralNetworkBuilder<BackPropagationNeuralNetwork>();
            builder.BuildNetwork(9, null, 1); // no hidden layers
            INeuralNetwork<double> network = builder.InitializeNeuralNetworkWithData(input, null, new double[] { 0 });

            // Test output value

            // Single pulse of network
            //network.Pulse(null);
            // Test back propagation
            (network as BackPropagationNeuralNetwork).Train(input, new double[] { new Random().Next(1, 9) });
            ;
        }
    }
}
