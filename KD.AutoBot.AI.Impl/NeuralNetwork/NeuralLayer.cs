using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Implementation of <see cref="INeuralLayer{TNeuronDataType}"/> based on <see cref="double"/> values.
    /// </summary>
    public class NeuralLayer : AbstractNeuralLayer<double>
    {
        public NeuralLayer(ICollection<INeuron<double>> neurons) :
            base(neurons)
        {
        }

        public override void ApplyLearning(INeuralNetwork<double> source)
        {
            foreach (INeuron<double> neuron in this.Neurons)
            {
                neuron.ApplyLearning(this);
            }
        }

        public override void Pulse(INeuralNetwork<double> source)
        {
            foreach (INeuron<double> neuron in this.Neurons)
            {
                neuron.Pulse(this);
            }
        }
    }
}