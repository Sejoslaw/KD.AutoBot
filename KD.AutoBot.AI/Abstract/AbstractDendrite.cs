namespace KD.AutoBot.AI.Abstract
{
    /// <summary>
    /// Abstract implementation of <see cref="IDendrite{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractDendrite<TNeuronDataType> : IDendrite<TNeuronDataType>
    {
        public INeuronSignal<TNeuronDataType> Input { get; set; }
        public INeuronWeight<TNeuronDataType> DendriteWeight { get; set; }

        protected AbstractDendrite(INeuronSignal<TNeuronDataType> input, INeuronWeight<TNeuronDataType> weight)
        {
            this.Input = input;
            this.DendriteWeight = weight;
        }
    }
}