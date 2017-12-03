namespace KD.AutoBot.AI.Abstract
{
    /// <summary>
    /// Abstract implementation of <see cref="IDendrite{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractDendrite<TNeuronDataType> : IDendrite<TNeuronDataType>
    {
        public INeuronSignal<TNeuronDataType> Input { get; protected set; }
        public INeuronWeight<TNeuronDataType> DendriteWeight { get; protected set; }

        public AbstractDendrite(INeuronSignal<TNeuronDataType> input, INeuronWeight<TNeuronDataType> dendriteWeight)
        {
            this.Input = input;
            this.DendriteWeight = dendriteWeight;
        }
    }
}