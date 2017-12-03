namespace KD.AutoBot.AI.Abstract
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuronWeight{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuronWeight<TNeuronDataType> : INeuronWeight<TNeuronDataType>
    {
        public TNeuronDataType Delta { get; protected set; }
        public TNeuronDataType Weight { get; protected set; }

        public abstract void ModifyWeight(TNeuronDataType delta);
    }
}