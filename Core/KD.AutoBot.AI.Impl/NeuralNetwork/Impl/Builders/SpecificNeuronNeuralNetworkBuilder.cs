using System;
using System.Collections.Generic;
using System.Linq;

namespace KD.AutoBot.AI.NeuralNetwork.Impl.Builders
{
    /// <summary>
    /// Builder for specified Neuron type.
    /// </summary>
    public abstract class SpecificNeuronNeuralNetworkBuilder<TNeuralNetworkType> : AbstractNeuralNetworkBuilder<double>
        where TNeuralNetworkType : INeuralNetwork<double>, new()
    {
        public override void BuildNetwork(object[] args)
        {
            this.BuildNetwork((int)args[0], (ICollection<int>)args[1], (int)args[2]);
        }

        public override void BuildNetwork(int inputNeurons, ICollection<int> hiddenLayersNeurons, int outputNeurons)
        {
            // Prepare Input
            this.InputLayer = this.BuildLayer(inputNeurons);

            // Prepare Hidden Layers
            this.HiddenLayers = new List<INeuralLayer<double>>();
            foreach (int neuronsInLayer in hiddenLayersNeurons)
            {
                INeuralLayer<double> hiddenLayer = this.BuildLayer(neuronsInLayer);
                this.HiddenLayers.Add(hiddenLayer);
            }

            // Prepare Output
            this.OutputLayer = this.BuildLayer(outputNeurons);
        }

        public override INeuralNetwork<double> InitializeNeuralNetworkWithData(double[] inputLayerValues, double[][] hiddenLayersValues, double[] outputLayerValues)
        {
            // Initialize Input Layer values
            this.InitializeData(this.InputLayer, inputLayerValues);

            // Initialize Hidden Layers values
            for (int i = 0; i < this.HiddenLayers.Count; ++i)
            {
                INeuralLayer<double> layer = this.HiddenLayers.ElementAt(i);
                try
                {
                    this.InitializeData(layer, hiddenLayersValues[i]);
                }
                catch (NullReferenceException)
                {
                    this.InitializeData(layer, null);
                }
            }

            // Initialize Output Layer values
            this.InitializeData(this.OutputLayer, outputLayerValues);

            //Initialize and return Neural Network
            INeuralNetwork<double> network = new TNeuralNetworkType();
            network.Initialize(this.InputLayer, this.HiddenLayers, this.OutputLayer);
            return network;
        }

        protected virtual void InitializeData(INeuralLayer<double> layer, double[] values)
        {
            if (values == null)
            {
                for (int i = 0; i < layer.Count; ++i)
                {
                    layer[i].Value = 0;
                }
            }
            else
            {
                for (int i = 0; i < layer.Count; ++i)
                {
                    layer[i].Value = values[i];
                }
            }
        }

        protected virtual INeuralLayer<double> BuildLayer(int neuronsInLayer)
        {
            IList<INeuron<double>> neurons = new List<INeuron<double>>();

            for (int i = 0; i < neuronsInLayer; ++i)
            {
                INeuron<double> neuron = this.GetSpecificNeuron();
                neurons.Add(neuron);
            }

            INeuralLayer<double> layer = new NeuralLayer(neurons);
            return layer;
        }

        protected abstract INeuron<double> GetSpecificNeuron();
    }
}