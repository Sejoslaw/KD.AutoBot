using System;
using System.Collections.Generic;
using System.Linq;

namespace KD.AutoBot.AI.NeuralNetwork.Impl.Networks
{
    /// <summary>
    /// Abstract layer of Neural Network which operates on <see cref="double"/> values.
    /// </summary>
    public abstract class AbstractDoubleNeuralNetwork : AbstractNeuralNetwork<double>
    {
        private object key = new object();

        public override void ApplyLearning(object source)
        {
            lock (key)
            {
                foreach (INeuralLayer<double> layer in this.HiddenLayers)
                {
                    layer.ApplyLearning(this);
                }
                this.Output.ApplyLearning(this);
            }
        }

        public override void Pulse(object source)
        {
            lock (key)
            {
                foreach (INeuralLayer<double> layer in this.HiddenLayers)
                {
                    layer.Pulse(this);
                }
                this.Output.Pulse(this);
            }
        }

        public override void Initialize(INeuralLayer<double> input, ICollection<INeuralLayer<double>> hiddenLayers, INeuralLayer<double> output)
        {
            this.Input = input;
            this.HiddenLayers = hiddenLayers;
            this.Output = output;

            // Connect layers
            if (this.HiddenLayers != null && this.HiddenLayers.Count > 0) // There is at least one hidden layer
            {
                this.ConnectLayers(this.Input, this.HiddenLayers.ElementAt(0));

                for (int i = 1; i < this.HiddenLayers.Count; ++i)
                {
                    var layerInput = this.HiddenLayers.ElementAt(i - 1);
                    var layerOutput = this.HiddenLayers.ElementAt(i);
                    this.ConnectLayers(layerInput, layerOutput);
                }

                // Connect last hidden with output
                this.ConnectLayers(this.HiddenLayers.ElementAt(this.HiddenLayers.Count - 1), this.Output);
            }
            else
            {
                this.ConnectLayers(this.Input, this.Output);
            }
        }

        private void ConnectLayers(INeuralLayer<double> input, INeuralLayer<double> output)
        {
            Random rand = new Random();
            double dendriteWeight = 0.1;
            double numberOfDendrites = 1;
            double normalizedWeight = 0.1;

            foreach (INeuron<double> outputNeuron in output.Neurons)
            {
                foreach (INeuron<double> inputNeuron in input.Neurons)
                {
                    dendriteWeight = rand.NextDouble();
                    outputNeuron.Inputs.Add(new Dendrite(inputNeuron, new NeuronWeight() { Weight = dendriteWeight }));
                }

                // Normalize actual input neuron weight.
                numberOfDendrites = input.Neurons.Count + 1; // One more for Bias
                normalizedWeight = (1 / numberOfDendrites);

                foreach (IDendrite<double> dendrite in outputNeuron.Inputs)
                {
                    dendrite.DendriteWeight.Weight = normalizedWeight;
                }
                outputNeuron.Bias.DendriteWeight.Weight = normalizedWeight;
            }
        }
    }
}