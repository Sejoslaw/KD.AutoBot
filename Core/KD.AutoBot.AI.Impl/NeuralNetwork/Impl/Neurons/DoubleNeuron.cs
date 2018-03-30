using System;
using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork.Impl.Neurons
{
    /// <summary>
    /// Neuron which can output <see cref="double"/> value.
    /// </summary>
    public class DoubleNeuron : AbstractNeuron<double>
    {
        private object key = new object();

        public DoubleNeuron(ICollection<IDendrite<double>> inputs)
        {
            this.Inputs = inputs;
            this.Bias = new Dendrite(new NeuronSignal { Value = 1 }, new NeuronWeight() { Weight = new Random().NextDouble() });
        }

        public override void ApplyLearning(INeuralLayer<double> source)
        {
            // Nothing here
        }

        public override void Pulse(INeuralLayer<double> source)
        {
            lock (key)
            {
                double newValue = 0;

                foreach (IDendrite<double> dendrite in this.Inputs)
                {
                    newValue += dendrite.Output.Value * dendrite.DendriteWeight.Weight;
                }

                newValue += this.Bias.Output.Value * this.Bias.DendriteWeight.Weight;

                // Run Event before setting new value
                this.OnNeuronValueChange?.Invoke(this, new NNEventArgs(null, source, this, null, newValue));
                this.Value = newValue;
            }
        }
    }
}