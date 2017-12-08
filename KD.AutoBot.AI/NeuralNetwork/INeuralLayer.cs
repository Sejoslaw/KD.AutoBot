using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Represents a layer of Neurons.
    /// </summary>
    public interface INeuralLayer<TNeuronDataType> : ILearnable<INeuralNetwork<TNeuronDataType>>
    {
        /// <summary>
        /// Represents all Neurons in current layer.
        /// </summary>
        ICollection<INeuron<TNeuronDataType>> Neurons { get; }

        /// <summary>
        /// Returns the number of Neurons in current layer.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Returns <see cref="INeuron{TNeuronDataType}"/> at specified index in current layer.
        /// </summary>
        INeuron<TNeuronDataType> this[int index] { get; }
    }
}