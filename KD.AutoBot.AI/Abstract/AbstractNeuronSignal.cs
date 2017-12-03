namespace KD.AutoBot.AI.Abstract
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuronSignal{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuronSignal<TNeuronDataType> : INeuronSignal<TNeuronDataType>
    {
        public TNeuronDataType Value { get; set; }
    }
}