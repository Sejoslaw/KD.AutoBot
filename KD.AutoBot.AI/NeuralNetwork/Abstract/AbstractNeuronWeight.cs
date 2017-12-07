namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuronWeight{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuronWeight<TNeuronDataType> : INeuronWeight<TNeuronDataType>
    {
        public TNeuronDataType Delta { get; set; }
        public TNeuronDataType Weight { get; set; }
    }
}