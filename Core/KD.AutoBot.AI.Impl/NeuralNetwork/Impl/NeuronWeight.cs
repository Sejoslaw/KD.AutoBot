namespace KD.AutoBot.AI.NeuralNetwork.Impl
{
    /// <summary>
    /// Implementation of <see cref="INeuronWeight{TNeuronDataType}"/> based on <see cref="double"/> values.
    /// </summary>
    public class NeuronWeight : AbstractNeuronWeight<double>
    {
        public NeuronWeight()
        {
            // Set random default values.
            this.Delta = 0;
            this.Weight = 0.1;
        }
    }
}