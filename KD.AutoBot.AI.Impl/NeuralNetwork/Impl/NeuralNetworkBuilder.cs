using KD.AutoBot.AI.NeuralNetwork.Impl.Networks;
using KD.AutoBot.AI.NeuralNetwork.Impl.Neurons;
using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork.Impl
{
    /// <summary>
    /// Implementation of <see cref="INeuralNetworkBuilder{TNeuronDataType}"/> based on <see cref="double"/> values.
    /// </summary>
    public class NeuralNetworkBuilder : AbstractNeuralNetworkBuilder<double>
    {
        public override INeuralNetwork<double> BuildNetwork(object[] args)
        {
            return this.BuildNetwork((int)args[0], (ICollection<int>)args[1], (int)args[2]);
        }

        public override INeuralNetwork<double> BuildNetwork(int inputNeurons, ICollection<int> hiddenLayersNeurons, int outputNeurons)
        {
            // Prepare Network
            INeuralNetwork<double> network = new BackPropagationNeuralNetwork();

            // Prepare Input
            INeuralLayer<double> input = this.BuildLayer(inputNeurons);

            // Prepare Hidden Layers
            ICollection<INeuralLayer<double>> hiddenLayers = new List<INeuralLayer<double>>();
            foreach (int neuronsInLayer in hiddenLayersNeurons)
            {
                INeuralLayer<double> hiddenLayer = this.BuildLayer(neuronsInLayer);
                hiddenLayers.Add(hiddenLayer);
            }

            // Prepare Output
            INeuralLayer<double> output = this.BuildLayer(outputNeurons);

            // Initialize Network
            network.Initialize(input, hiddenLayers, output);

            return network;
        }

        private INeuralLayer<double> BuildLayer(int neuronsInLayer)
        {
            IList<INeuron<double>> neurons = new List<INeuron<double>>();

            for (int i = 0; i < neuronsInLayer; ++i)
            {
                neurons.Add(new SigmoidNeuron(new List<IDendrite<double>>()));
            }

            INeuralLayer<double> layer = new NeuralLayer(neurons);
            return layer;
        }
    }
}