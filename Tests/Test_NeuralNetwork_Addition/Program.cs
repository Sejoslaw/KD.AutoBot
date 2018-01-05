using KD.AutoBot.AI.NeuralNetwork;
using KD.AutoBot.AI.NeuralNetwork.Impl.Builders;
using KD.AutoBot.AI.NeuralNetwork.Impl.Networks;
using System;

namespace Test_NeuralNetwork_Addition
{
    class Program
    {
        static void Main(string[] args)
        {
            INeuralNetworkBuilder<double> builder = new DoubleNeuralNetworkBuilder<BackPropagationNeuralNetwork>();
            builder.BuildNetwork(2, new int[] { 10, 20 }, 1); // no hidden layers
            INeuralNetwork<double> network = InitializeNeuralNetworkStartingValues(builder);

            int iterations = 100;
            double[][] input = GetInput(iterations);
            double[][] output = GetAdditionOutput(input);

            bool countedRight = false;
            Random rand = new Random();
            int iteration = 1;
            while (!countedRight)
            {
                Console.WriteLine($"Iteration: { iteration }");
                for (int i = 0; i < iterations; ++i)
                {
                    network.Train(input, output);
                }

                int value1 = rand.Next(10); Console.WriteLine($"Value1 = { value1 }");
                int value2 = rand.Next(10); Console.WriteLine($"Value2 = { value2 }");
                int sum = value1 + value2; Console.WriteLine($"Sum = { sum }");

                network.ApplyLearning(null);
                network.Input[0].Value = value1;
                network.Input[1].Value = value2;
                network.Pulse(null);
                double networkOutput = network.Output[0].Value; Console.WriteLine($"Neural Network output value = { networkOutput }");

                Console.WriteLine($"End of iteration { iteration }");
                Console.WriteLine("============================================================================");
                iteration++;

                if (sum == networkOutput)
                {
                    countedRight = true;
                }
            }

            Console.ReadKey();
        }

        private static INeuralNetwork<double> InitializeNeuralNetworkStartingValues(INeuralNetworkBuilder<double> builder)
        {
            double[][] hiddenLayerValues = new double[2][];
            hiddenLayerValues[0] = new double[10];
            hiddenLayerValues[1] = new double[20];
            for (int i = 0; i < 10; ++i)
            {
                hiddenLayerValues[0][i] = i;
            }
            for (int i = 0; i < 20; ++i)
            {
                hiddenLayerValues[1][i] = i;
            }

            INeuralNetwork<double> network = builder.InitializeNeuralNetworkWithData(null, hiddenLayerValues, null);
            network.LearningRate = 1;

            return network;
        }

        private static double[][] GetAdditionOutput(double[][] input)
        {
            double[][] output = new double[input.Length][];
            for (int i = 0; i < input.Length; ++i)
            {
                double sum = input[i][0] + input[i][1];
                output[i] = new double[] { sum };
            }
            return output;
        }

        private static double[][] GetInput(int tests)
        {
            double[][] input = new double[tests][];
            double operationsInLoop = Math.Sqrt(input.Length);
            int row = 0;
            for (int i = 0; i < operationsInLoop; ++i)
            {
                for (int j = 0; j < operationsInLoop; ++j)
                {
                    input[row] = new double[] { i, j };
                    row++;
                }
            }
            return input;
        }
    }
}