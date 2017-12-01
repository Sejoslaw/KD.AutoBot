namespace KD.AutoBot.AI
{
    /// <summary>
    /// <see cref="ILearningModule"/> which uses <see cref="INeuralNetwork{TNeuronDataType}"/> as a base of learning.
    /// </summary>
    public interface INeuralNetworkLearningModule<TNeuronDataType> : ILearningModule
    {
        /// <summary>
        /// Neural Network connected with this module.
        /// </summary>
        INeuralNetwork<TNeuronDataType> NeuralNetwork { get; }
    }
}