using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Describes the core of the Neural Network.
    /// Network is learnable just to start the learning process.
    /// </summary>
    public interface INeuralNetwork<TNeuronDataType> : ILearnable<object>
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
        /// Represents an output layer from current network.
        /// </summary>
        INeuralLayer<TNeuronDataType> Output { get; }
        /// <summary>
        /// Rate on which Network learns.
        /// </summary>
        TNeuronDataType LearningRate { get; set; }

        /// <summary>
        /// Initializes current Network.
        /// </summary>
        void Initialize(INeuralLayer<TNeuronDataType> input, ICollection<INeuralLayer<TNeuronDataType>> hiddenLayers, INeuralLayer<TNeuronDataType> output);
    }
}