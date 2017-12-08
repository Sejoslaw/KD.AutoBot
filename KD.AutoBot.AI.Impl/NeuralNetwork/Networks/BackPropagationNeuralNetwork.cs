using System;
using System.Collections.Generic;
using System.Linq;

namespace KD.AutoBot.AI.NeuralNetwork.Networks
{
    /// <summary>
    /// Implementation of <see cref="INeuralNetwork{TNeuronDataType}"/> based on <see cref="double"/> values.
    /// </summary>
    public class BackPropagationNeuralNetwork : AbstractNeuralNetwork<double>
    {
        public override void ApplyLearning(object source)
        {
            lock (this)
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
            lock (this)
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
        }

        public override void Train(double[] input, double[] wantedResults)
        {
            int i;

            if (input.Length != this.Input.Count)
            {
                throw new ArgumentException($"Current Network requires { this.Input.Count } inputs.");
            }

            // Initialize data
            for (i = 0; i < this.Input.Count; ++i)
            {
                INeuron<double> neuron = this.Input[i];

                if (neuron != null)
                {
                    neuron.Value = input[i];
                }
            }

            this.Pulse(null);
            this.BackPropagation(wantedResults);
        }

        private void BackPropagation(double[] wantedResults)
        {
            int i, j;
            double currentValue, error;

            INeuron<double> outputNeuron, inputNeuron, hiddenNeuron, neuron;

            // Calculate output error values
            for (i = 0; i < this.Output.Neurons.Count; ++i)
            {
                INeuron<double> localNeuron = this.Output[i];
                currentValue = localNeuron.Value;
                localNeuron.Error = (wantedResults[i] - currentValue) * currentValue * (1.0F - currentValue);
            }

            // Calculate hidden layers error values
            foreach (INeuralLayer<double> layer in this.HiddenLayers)
            {
                for (i = 0; i < layer.Count; ++i)
                {
                    neuron = layer[i];
                    error = 0;

                    for (j = 0; j < this.Output.Count; ++i)
                    {
                        outputNeuron = this.Output[j];
                        error += outputNeuron.Error * outputNeuron[i /*neuron*/].DendriteWeight.Weight * neuron.Value * (1.0 - neuron.Value);
                    }

                    neuron.Error = error;
                }
                error = 0;
            }

            // Adjust output layer weight change
            foreach (INeuralLayer<double> layer in this.HiddenLayers)
            {
                for (i = 0; i < layer.Count; ++i)
                {
                    neuron = layer[i];

                    for (j = 0; j < this.Output.Count; ++j)
                    {
                        outputNeuron = this.Output[j /*neuron*/];
                        outputNeuron[i].DendriteWeight.Weight += this.LearningRate * this.Output[j].Error * neuron.Value;
                        outputNeuron.Bias.DendriteWeight.Delta += this.LearningRate * this.Output[j].Error * outputNeuron.Bias.DendriteWeight.Weight;
                    }
                }
            }

            // Adjust first hidden layer weight change
            if (this.HiddenLayers.Count > 0)
            {
                INeuralLayer<double> hiddenLayer = this.HiddenLayers.ElementAt(0);

                for (i = 0; i < this.Input.Count; ++i)
                {
                    inputNeuron = this.Input[i];

                    for (j = 0; j < hiddenLayer.Count; ++j)
                    {
                        hiddenNeuron = hiddenLayer[j];
                        hiddenNeuron[i /*inputNeuron*/].DendriteWeight.Weight += this.LearningRate * hiddenNeuron.Error * inputNeuron.Value;
                        hiddenNeuron.Bias.DendriteWeight.Delta += this.LearningRate * hiddenNeuron.Error * inputNeuron.Bias.DendriteWeight.Weight;
                    }
                }
            }
        }
    }
}