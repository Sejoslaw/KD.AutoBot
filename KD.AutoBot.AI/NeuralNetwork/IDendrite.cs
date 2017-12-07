namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Represents single dendrite (single input into Neuron).
    /// </summary>
    public interface IDendrite<TNeuronDataType>
    {
        /// <summary>
        /// Represents a value which is send into Neuron from current dendrite.
        /// </summary>
        INeuronSignal<TNeuronDataType> Output { get; }
        /// <summary>
        /// Represents a weight of current dendrite.
        /// </summary>
        INeuronWeight<TNeuronDataType> DendriteWeight { get; }
    }
}