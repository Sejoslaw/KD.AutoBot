using System.Collections.Generic;
using System.Linq;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuralLayer{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuralLayer<TNeuronDataType> : AbstractLearnable<INeuralNetwork<TNeuronDataType>>, INeuralLayer<TNeuronDataType>
    {
        public ICollection<INeuron<TNeuronDataType>> Neurons { get; set; }
        public int Count
        {
            get
            {
                return this.Neurons.Count;
            }
        }

        public INeuron<TNeuronDataType> this[int index]
        {
            get
            {
                return this.Neurons.ElementAt(index);
            }
        }

        protected AbstractNeuralLayer(ICollection<INeuron<TNeuronDataType>> neurons)
        {
            this.Neurons = neurons;
        }
    }
}