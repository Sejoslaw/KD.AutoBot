using System;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Represents single Neuron.
    /// 
    /// Events generic arguments description:
    /// 1. Network in which the change WILL occurre.
    /// 2. Layer in which the change WILL occure.
    /// 3. Neuron in which the change WILL occurre.
    /// 4. Dendrite in which the change WILL occurre.
    /// 5. New value which will be connected - this should be clear from the Event name. For example: "OnDendriteWeightChange" - this value will be a new value which will be set as a specified dendrite weight.
    /// 
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
        /// Somethimes called Delta.
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

        /// <summary>
        /// Event which is fired when weight of specified dendrite change.
        /// </summary>
        EventHandler<NNEventArgs<INeuralNetwork<TNeuronDataType>, INeuralLayer<TNeuronDataType>, INeuron<TNeuronDataType>, IDendrite<TNeuronDataType>, TNeuronDataType>> OnDendriteWeightChange { get; set; }
        /// <summary>
        /// Event which is fire BEFORE the value of this Neuron change.
        /// </summary>
        EventHandler<NNEventArgs<INeuralNetwork<TNeuronDataType>, INeuralLayer<TNeuronDataType>, INeuron<TNeuronDataType>, IDendrite<TNeuronDataType>, TNeuronDataType>> OnNeuronValueChange { get; set; }

        /// <summary>
        /// Returns input <see cref="IDendrite{TNeuronDataType}"/> of this Neuron.
        /// </summary>
        IDendrite<TNeuronDataType> this[int index] { get; }
    }
}