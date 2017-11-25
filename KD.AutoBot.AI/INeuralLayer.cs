using System.Collections.Generic;

namespace KD.AutoBot.AI
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
    }
}