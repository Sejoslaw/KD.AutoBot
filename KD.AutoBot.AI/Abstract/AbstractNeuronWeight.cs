namespace KD.AutoBot.AI.Abstract
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuronWeight{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuronWeight<TNeuronDataType> : INeuronWeight<TNeuronDataType>
    {
        public TNeuronDataType Delta { get; set; }
        public TNeuronDataType Weight { get; set; }

        public abstract void ModifyWeight(TNeuronDataType delta);
    }
}