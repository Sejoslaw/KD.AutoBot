using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork.Impl.Neurons
{
    /// <summary>
    /// <see cref="INeuron{TNeuronDataType}"/> implemented using Sigmoid function.
    /// </summary>
    public class SigmoidNeuron : DoubleNeuron
    {
        public SigmoidNeuron(ICollection<IDendrite<double>> inputs) :
            base(inputs)
        {
        }

        public override void Pulse(INeuralLayer<double> source)
        {
            lock (this)
            {
                base.Pulse(source);
                this.Value = AiMath.Sigmoid(this.Value);
            }
        }
    }
}