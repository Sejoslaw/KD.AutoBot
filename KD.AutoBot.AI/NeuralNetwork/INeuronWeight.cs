namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Holds weight of the input signal into Neuron.
    /// </summary>
    public interface INeuronWeight<TNeuronDataType>
    {
        /// <summary>
        /// Value of the applying adjustement.
        /// </summary>
        TNeuronDataType Delta { get; }
        /// <summary>
        /// Weight of the input signal.
        /// </summary>
        TNeuronDataType Weight { get; }

        /// <summary>
        /// This method should be called when current weight should be modified by given delta.
        /// </summary>
        void ModifyWeight(TNeuronDataType delta);
    }
}