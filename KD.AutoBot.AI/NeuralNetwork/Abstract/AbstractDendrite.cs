namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Abstract implementation of <see cref="IDendrite{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractDendrite<TNeuronDataType> : IDendrite<TNeuronDataType>
    {
        public INeuronSignal<TNeuronDataType> Output { get; set; }
        public INeuronWeight<TNeuronDataType> DendriteWeight { get; set; }

        protected AbstractDendrite(INeuronSignal<TNeuronDataType> output, INeuronWeight<TNeuronDataType> weight)
        {
            this.Output = output;
            this.DendriteWeight = weight;
        }
    }
}