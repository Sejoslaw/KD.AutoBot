using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Used for building <see cref="INeuralNetwork{TNeuronDataType}"/>.
    /// </summary>
    public interface INeuralNetworkBuilder<TNeuronDataType>
    {
        /// <summary>
        /// Returns new <see cref="INeuralNetwork{TNeuronDataType}"/>.
        /// Optional arguments can be passed.
        /// </summary>
        INeuralNetwork<TNeuronDataType> BuildNetwork(object[] args);
        /// <summary>
        /// Returns new <see cref="INeuralNetwork{TNeuronDataType}"/>.
        /// </summary>
        INeuralNetwork<TNeuronDataType> BuildNetwork(int inputNeurons, ICollection<int> hiddenLayersNeurons, int outputNeurons);
    }
}