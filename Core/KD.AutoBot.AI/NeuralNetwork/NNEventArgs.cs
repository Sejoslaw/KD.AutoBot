using System;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// NNEventArgs with default generic types.
    /// </summary>
    public class NNEventArgs : NNEventArgs<INeuralNetwork<double>, INeuralLayer<double>, INeuron<double>, IDendrite<double>, double>
    {
        public NNEventArgs(INeuralNetwork<double> network, INeuralLayer<double> layer, INeuron<double> neuron, IDendrite<double> dendrite, double value) : 
            base(network, layer, neuron, dendrite, value)
        {
        }
    }

    /// <summary>
    /// EventArgs passed to Neural Network EventHandlers.
    /// </summary>
    /// <typeparam name="TNeuralNetworkType"></typeparam>
    /// <typeparam name="TNeuralLayerType"></typeparam>
    /// <typeparam name="TNeuronType"></typeparam>
    /// <typeparam name="TDendriteType"></typeparam>
    /// <typeparam name="TNeuronDataType"></typeparam>
    public class NNEventArgs<TNeuralNetworkType, TNeuralLayerType, TNeuronType, TDendriteType, TNeuronDataType> : EventArgs
        where TNeuralNetworkType : INeuralNetwork<TNeuronDataType>
        where TNeuralLayerType : INeuralLayer<TNeuronDataType>
        where TNeuronType : INeuron<TNeuronDataType>
        where TDendriteType : IDendrite<TNeuronDataType>
    {
        /// <summary>
        /// Network in which Event accurred. Nullable.
        /// </summary>
        public TNeuralNetworkType Network { get; }
        /// <summary> 
        /// Layer in which Event occurred. Nullable.
        /// </summary>
        public TNeuralLayerType Layer { get; }
        /// <summary>
        /// Neuron in which Event occurred. Nullable.
        /// </summary>
        public TNeuronType Neuron { get; }
        /// <summary>
        /// Dendrite in which Event occurred. Nullable.
        /// </summary>
        public TDendriteType Dendrite { get; }
        /// <summary>
        /// Value which will be set. Nullable.
        /// (Depends on Event type).
        /// </summary>
        public TNeuronDataType Value { get; }

        public NNEventArgs(TNeuralNetworkType network, TNeuralLayerType layer, TNeuronType neuron, TDendriteType dendrite, TNeuronDataType value)
        {
            this.Network = network;
            this.Layer = layer;
            this.Neuron = neuron;
            this.Dendrite = dendrite;
            this.Value = value;
        }
    }
}