using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork.Impl.Neurons
{
    /// <summary>
    /// <see cref="INeuron{TNeuronDataType}"/> implemented using Sigmoid function.
    /// </summary>
    public class SigmoidNeuron : AbstractNeuron<double>
    {
        public SigmoidNeuron(ICollection<IDendrite<double>> inputs)
        {
            this.Inputs = inputs;
            this.Bias = new Dendrite(new NeuronSignal { Value = 1 }, new NeuronWeight());
        }

        public override void ApplyLearning(INeuralLayer<double> source)
        {
            // Nothing here
        }

        public override void Pulse(INeuralLayer<double> source)
        {
            lock (this)
            {
                this.Value = 0;

                foreach (IDendrite<double> dendrite in this.Inputs)
                {
                    this.Value += dendrite.Output.Value * dendrite.DendriteWeight.Weight;
                }

                this.Value += this.Bias.Output.Value * this.Bias.DendriteWeight.Weight;
                this.Value = AiMath.Sigmoid(this.Value);
            }
        }
    }
}