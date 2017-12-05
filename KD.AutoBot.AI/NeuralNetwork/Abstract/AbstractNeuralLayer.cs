using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuralLayer{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuralLayer<TNeuronDataType> : AbstractLearnable<INeuralNetwork<TNeuronDataType>>, INeuralLayer<TNeuronDataType>
    {
        public ICollection<INeuron<TNeuronDataType>> Neurons { get; set; }

        public AbstractNeuralLayer(ICollection<INeuron<TNeuronDataType>> neurons)
        {
            this.Neurons = neurons;
        }
    }
}