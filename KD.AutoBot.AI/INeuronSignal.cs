namespace KD.AutoBot.AI
{
    /// <summary>
    /// Represents a single signal send from / to Neuron.
    /// </summary>
    public interface INeuronSignal<TNeuronDataType>
    {
        /// <summary>
        /// Value which will be send from / to Neuron.
        /// </summary>
        TNeuronDataType Value { get; set; }
    }
}