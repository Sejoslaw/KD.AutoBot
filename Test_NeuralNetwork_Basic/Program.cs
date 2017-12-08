using KD.AutoBot.AI.NeuralNetwork;
using KD.AutoBot.AI.NeuralNetwork.Impl;
using System;

namespace Test_NeuralNetwork_Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Test Neural Network to understand XOR Logic Gate
             * 
             * Input 1  | Input 2   | XOR Output
             * 0        | 0         | 0
             * 0        | 1         | 1
             * 1        | 0         | 1
             * 1        | 1         | 0
             * 
             */

            INeuralNetworkBuilder<double> builder = new NeuralNetworkBuilder();
            INeuralNetwork<double> network = builder.BuildNetwork(2, new int[] { 2 }, 1);

            // Signal values
            double low = 0.1, mid = 0.5, high = 0.9;

            double[][] input = new double[4][];
            input[0] = new double[] { high, high };
            input[1] = new double[] { low, high };
            input[2] = new double[] { high, low };
            input[3] = new double[] { low, low };

            double[][] output = new double[4][];
            output[0] = new double[] { low };
            output[1] = new double[] { high };
            output[2] = new double[] { high };
            output[3] = new double[] { low };

            double ll, lh, hl, hh;
            int count, trainingsPerIteration = 100;

            count = 0;

            do
            {
                count++;

                for (int i = 0; i < trainingsPerIteration; i++)
                {
                    network.Train(input, output);
                }

                network.ApplyLearning(null);

                network.Input[0].Value = low;
                network.Input[1].Value = low;

                network.Pulse(null);

                ll = network.Output[0].Value;

                network.Input[0].Value = high;
                network.Input[1].Value = low;

                network.Pulse(null);

                hl = network.Output[0].Value;

                network.Input[0].Value = low;
                network.Input[1].Value = high;

                network.Pulse(null);

                lh = network.Output[0].Value;

                network.Input[0].Value = high;
                network.Input[1].Value = high;

                network.Pulse(null);

                hh = network.Output[0].Value;

                IterationResult(count, ll, lh, hl, hh);
            }
            while (hh > mid || lh < mid || hl < mid || ll > mid);

            Console.WriteLine($"Iterations required for training: { trainingsPerIteration }");
            Console.ReadKey();
        }

        static void IterationResult(int iteration, double ll, double lh, double hl, double hh)
        {
            Console.WriteLine($"Iteration: { iteration }");
            Console.WriteLine($"Result for Low Low: { ll }");
            Console.WriteLine($"Result for Low High: { lh }");
            Console.WriteLine($"Result for High Low: { hl }");
            Console.WriteLine($"Result for High High: { hh }");
            Console.WriteLine("======================================");
        }
    }
}