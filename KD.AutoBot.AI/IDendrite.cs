namespace KD.AutoBot.AI
{
    /// <summary>
    /// Represents single dendrite (single input into Neuron).
    /// </summary>
    public interface IDendrite<TNeuronDataType>
    {
        /// <summary>
        /// Represents a value which is send into Neuron on current dendrite.
        /// </summary>
        INeuronSignal<TNeuronDataType> Input { get; }
        /// <summary>
        /// Represents a weight of current dendrite.
        /// </summary>
        INeuronWeight<TNeuronDataType> DendriteWeight { get; }
    }
}