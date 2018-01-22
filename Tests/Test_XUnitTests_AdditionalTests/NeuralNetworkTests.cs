using KD.AutoBot.AI.NeuralNetwork;
using KD.AutoBot.AI.NeuralNetwork.Impl.Builders;
using KD.AutoBot.AI.NeuralNetwork.Impl.Networks;
using System.Linq;
using Xunit;

namespace Test_XUnitTests_AdditionalTests
{
    public class NeuralNetworkTests
    {
        /// <summary>
        /// Exmaple taken from:
        /// https://stevenmiller888.github.io/mind-how-to-build-a-neural-network/
        /// </summary>
        [Fact]
        public void Test_NeuralNetworkLogic()
        {
            INeuralNetworkBuilder<double> builder = new SigmoidNeuralNetworkBuilder<GeneticTrainingNeuralNetwork>();
            builder.BuildNetwork(2, new int[] { 3 }, 1);
            INeuralNetwork<double> network = builder.InitializeNeuralNetworkWithData(
                new double[] { 1, 1 },
                null,
                null);
            // First Hidden Layer
            network.HiddenLayers.ElementAt(0)[0].Inputs.ElementAt(0).DendriteWeight.Weight = 0.8;
            network.HiddenLayers.ElementAt(0)[0].Inputs.ElementAt(1).DendriteWeight.Weight = 0.2;
            network.HiddenLayers.ElementAt(0)[1].Inputs.ElementAt(0).DendriteWeight.Weight = 0.4;
            network.HiddenLayers.ElementAt(0)[1].Inputs.ElementAt(1).DendriteWeight.Weight = 0.9;
            network.HiddenLayers.ElementAt(0)[2].Inputs.ElementAt(0).DendriteWeight.Weight = 0.3;
            network.HiddenLayers.ElementAt(0)[2].Inputs.ElementAt(1).DendriteWeight.Weight = 0.5;
            // Output Nueron
            network.Output.Neurons.ElementAt(0)[0].DendriteWeight.Weight = 0.3;
            network.Output.Neurons.ElementAt(0)[0].DendriteWeight.Weight = 0.5;
            network.Output.Neurons.ElementAt(0)[0].DendriteWeight.Weight = 0.9;
            // Run sigmoid function
            network.Pulse(null);
            ;
        }
    }
}