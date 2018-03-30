using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork.Impl.Neurons
{
    /// <summary>
    /// <see cref="INeuron{TNeuronDataType}"/> implemented using Sigmoid function.
    /// 
    /// In the <see cref="SigmoidNeuron"/> the new value in "OnNeuronValueChange" is fired before the sigmoid function is used.
    /// If You want to check what will be the new value after the sigmoid function, just use <see cref="AiMath.Sigmoid(double)"/> and as an argument pass the new value.
    /// </summary>
    public class SigmoidNeuron : DoubleNeuron
    {
        private object key = new object();

        public SigmoidNeuron(ICollection<IDendrite<double>> inputs) :
            base(inputs)
        {
        }

        public override void Pulse(INeuralLayer<double> source)
        {
            lock (key)
            {
                base.Pulse(source);
                this.Value = AiMath.Sigmoid(this.Value);
            }
        }
    }
}