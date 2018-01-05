using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Represents input to Neuron.
    /// Holds data about all dendrites.
    /// </summary>
    public interface INeuronInput<TNeuronDataType>
    {
        /// <summary>
        /// Represents a collection of dendrites.
        /// </summary>
        ICollection<IDendrite<TNeuronDataType>> Inputs { get; }
    }
}