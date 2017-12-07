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

            if (input.Length != this.Input.Neurons.Count)
            {
                throw new ArgumentException($"Current Network requires { this.Input.Neurons.Count } inputs.");
            }

            // Initialize data
            for (i = 0; i < this.Input.Neurons.Count; ++i)
            {
                INeuron<double> neuron = this.Input.Neurons.ElementAt(i);

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
            double temp, error;

            INeuron<double> outputNeuron, inputNeuron, hiddenNeuron, neuron, neuron2;

            // Calculate output error values
            for (i = 0; i < this.Output.Neurons.Count; ++i)
            {
                INeuron<double> localNeuron = this.Output.Neurons.ElementAt(i);
                temp = localNeuron.Value;
                localNeuron.Error = (wantedResults[i] - temp) * temp * (1.0F - temp);
            }

            // Calculate hidden layers error values
            foreach (INeuralLayer<double> layer in this.HiddenLayers)
            {
                ICollection<INeuron<double>> neurons = layer.Neurons;
                for (i = 0; i < neurons.Count; ++i)
                {
                    neuron = neurons.ElementAt(i);
                    error = 0;

                    for (j = 0; j < this.Output.Neurons.Count; ++i)
                    {
                        outputNeuron = this.Output.Neurons.ElementAt(j);
                        error += outputNeuron.Error * outputNeuron.Inputs.ElementAt(i /*neuron*/).DendriteWeight.Weight * neuron.Value * (1.0 - neuron.Value);
                    }

                    neuron.Error = error;
                }
                error = 0;
            }

            // Adjust output layer weight change
            foreach (INeuralLayer<double> layer in this.HiddenLayers)
            {
                for (i = 0; i < layer.Neurons.Count; ++i)
                {
                    neuron = layer.Neurons.ElementAt(i);

                    for (j = 0; j < this.Output.Neurons.Count; ++j)
                    {
                        outputNeuron = this.Output.Neurons.ElementAt(j /*neuron*/);
                        outputNeuron.Inputs.ElementAt(i).DendriteWeight.Weight += this.LearningRate * this.Output.Neurons.ElementAt(j).Error * neuron.Value;
                        outputNeuron.Bias.DendriteWeight.Delta += this.LearningRate * this.Output.Neurons.ElementAt(j).Error * outputNeuron.Bias.DendriteWeight.Weight;
                    }
                }
            }

            // Adjust first hidden layer weight change
            if (this.HiddenLayers.Count > 0)
            {
                INeuralLayer<double> hiddenLayer = this.HiddenLayers.ElementAt(0);

                for (i = 0; i < this.Input.Neurons.Count; ++i)
                {
                    inputNeuron = this.Input.Neurons.ElementAt(i);

                    for (j = 0; j < hiddenLayer.Neurons.Count; ++j)
                    {
                        hiddenNeuron = hiddenLayer.Neurons.ElementAt(j);
                        hiddenNeuron.Inputs.ElementAt(i /*inputNeuron*/).DendriteWeight.Weight += this.LearningRate * hiddenNeuron.Error * inputNeuron.Value;
                        hiddenNeuron.Bias.DendriteWeight.Delta += this.LearningRate * hiddenNeuron.Error * inputNeuron.Bias.DendriteWeight.Weight;
                    }
                }
            }
        }
    }
}