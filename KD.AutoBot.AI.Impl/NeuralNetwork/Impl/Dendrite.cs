namespace KD.AutoBot.AI.NeuralNetwork.Impl
{
    /// <summary>
    /// Implementation of <see cref="IDendrite{TNeuronDataType}"/> based on <see cref="double"/> values.
    /// </summary>
    public class Dendrite : AbstractDendrite<double>
    {
        public Dendrite() :
            this(new NeuronSignal(), new NeuronWeight())
        {
        }

        public Dendrite(INeuronSignal<double> input, INeuronWeight<double> weight) :
            base(input, weight)
        {
        }
    }
}