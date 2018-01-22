using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Used for building <see cref="INeuralNetwork{TNeuronDataType}"/>.
    /// </summary>
    public interface INeuralNetworkBuilder<TNeuronDataType>
    {
        /// <summary>
        /// Builds internal Neural Network.
        /// Optional arguments can be passed.
        /// </summary>
        void BuildNetwork(object[] args);
        /// <summary>
        /// Builds internal Neural Network.
        /// </summary>
        void BuildNetwork(int inputNeurons, IEnumerable<int> hiddenLayersNeurons, int outputNeurons);
        /// <summary>
        /// Initializes Neural Network with given data.
        /// Where on index:
        /// 0 - Input layer values,
        /// 1 - Hidden layers values,
        /// 2 - Output layer values
        /// </summary>
        INeuralNetwork<TNeuronDataType> InitializeNeuralNetworkWithData(
            TNeuronDataType[] inputLayerValues, 
            TNeuronDataType[][] hiddenLayersValues, 
            TNeuronDataType[] outputLayerValues);
    }
}