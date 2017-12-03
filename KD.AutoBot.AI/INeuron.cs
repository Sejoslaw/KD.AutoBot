using System;

namespace KD.AutoBot.AI
{
    /// <summary>
    /// Represents single Neuron.
    /// </summary>
    public interface INeuron<TNeuronDataType> : INeuronInput<TNeuronDataType>, INeuronSignal<TNeuronDataType>, ILearnable<INeuralLayer<TNeuronDataType>>
    {
        /// <summary>
        /// Represents a Bias input.
        /// Where Bias is an input value which always hold value +1 and it's weight can be modified.
        /// </summary>
        IDendrite<TNeuronDataType> Bias { get; }
        /// <summary>
        /// Represents a learning error.
        /// </summary>
        TNeuronDataType Error { get; set; }
        /// <summary>
        /// Defines the Neuron output based on inputs.
        /// </summary>
        Func<INeuron<TNeuronDataType>, TNeuronDataType> ActivationFunction { get; }
        /// <summary>
        /// Optional-minimum value which is required to activate a Neuron.
        /// </summary>
        TNeuronDataType ThresholdValue { get; set; }
    }
}