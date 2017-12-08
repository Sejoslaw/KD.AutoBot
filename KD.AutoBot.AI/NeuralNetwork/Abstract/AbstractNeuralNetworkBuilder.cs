using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuralNetworkBuilder{TNeuronDataType}"/>.
    /// </summary>
    public abstract class AbstractNeuralNetworkBuilder<TNeuronDataType> : INeuralNetworkBuilder<TNeuronDataType>
    {
        public abstract INeuralNetwork<TNeuronDataType> BuildNetwork(object[] args);
        public abstract INeuralNetwork<TNeuronDataType> BuildNetwork(int inputNeurons, ICollection<int> hiddenLayersNeurons, int outputNeurons);
    }
}