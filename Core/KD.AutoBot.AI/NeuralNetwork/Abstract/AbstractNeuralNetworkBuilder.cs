using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuralNetworkBuilder{TNeuronDataType}"/>.
    /// </summary>
    public abstract class AbstractNeuralNetworkBuilder<TNeuronDataType> : INeuralNetworkBuilder<TNeuronDataType>
    {
        protected INeuralLayer<TNeuronDataType> InputLayer { get; set; }
        protected ICollection<INeuralLayer<TNeuronDataType>> HiddenLayers { get; set; }
        protected INeuralLayer<TNeuronDataType> OutputLayer { get; set; }

        public abstract void BuildNetwork(object[] args);
        public abstract void BuildNetwork(int inputNeurons, ICollection<int> hiddenLayersNeurons, int outputNeurons);
        public abstract INeuralNetwork<TNeuronDataType> InitializeNeuralNetworkWithData(TNeuronDataType[] inputLayerValues, TNeuronDataType[][] hiddenLayersValues, TNeuronDataType[] outputLayerValues);
    }
}