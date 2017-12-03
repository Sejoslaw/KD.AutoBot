namespace KD.AutoBot.AI.Abstract
{
    /// <summary>
    /// Abstract <see cref="ILearningModule" /> implemented using <see cref="INeuralNetwork{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuralNetworkLearningModule<TNeuronDataType> : AbstractLearningModule, INeuralNetworkLearningModule<TNeuronDataType>
    {
        public INeuralNetwork<TNeuronDataType> NeuralNetwork { get; protected set; }

        public AbstractNeuralNetworkLearningModule(IAutoBot bot) : 
            base(bot)
        {
        }
    }
}