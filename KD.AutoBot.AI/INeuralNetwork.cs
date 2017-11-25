using System.Collections.Generic;

namespace KD.AutoBot.AI
{
    /// <summary>
    /// Describes the core of the Neural Network.
    /// Network is learnable just to start the learning process.
    /// </summary>
    public interface INeuralNetwork<TNeuronDataType> : ILearnable<INeuralNetwork<TNeuronDataType>>
    {
        /// <summary>
        /// Represents an input layer into current network.
        /// </summary>
        INeuralLayer<TNeuronDataType> Input { get; }
        /// <summary>
        /// Represents a collection of hidden layers.
        /// </summary>
        ICollection<INeuralLayer<TNeuronDataType>> HiddenLayers { get; }
        /// <summary>
        /// REpresents an output layer from current network.
        /// </summary>
        INeuralLayer<TNeuronDataType> Output { get; }
    }
}