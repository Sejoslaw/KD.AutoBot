namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Abstract <see cref="ILearningModule" /> implemented using <see cref="INeuralNetwork{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuralNetworkLearningModule<TNeuronDataType> : AbstractLearningModule, INeuralNetworkLearningModule<TNeuronDataType>
    {
        public INeuralNetwork<TNeuronDataType> NeuralNetwork { get; set; }

        protected AbstractNeuralNetworkLearningModule(IAutoBot bot, INeuralNetwork<TNeuronDataType> neuralNetwork) :
            base(bot)
        {
            this.NeuralNetwork = neuralNetwork;
        }
    }
}