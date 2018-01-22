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
            this.Bias = new Dendrite(new NeuronSignal { Value = 1 }, new NeuronWeight() { Weight = 0.5 });
        }

        public override void ApplyLearning(INeuralLayer<double> source)
        {
            // Nothing here
        }

        public override void Pulse(INeuralLayer<double> source)
        {
            lock (key)
            {
                this.Value = 0;

                foreach (IDendrite<double> dendrite in this.Inputs)
                {
                    this.Value += dendrite.Output.Value * dendrite.DendriteWeight.Weight;
                }

                this.Value += this.Bias.Output.Value * this.Bias.DendriteWeight.Weight;
            }
        }
    }
}