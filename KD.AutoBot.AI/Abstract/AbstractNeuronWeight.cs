namespace KD.AutoBot.AI.Abstract
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuronWeight{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuronWeight<TNeuronDataType> : INeuronWeight<TNeuronDataType>
    {
        public TNeuronDataType Delta { get; set; }
        public TNeuronDataType Weight { get; set; }

        protected AbstractNeuronWeight(TNeuronDataType startDelta, TNeuronDataType weight)
        {
            this.Delta = startDelta;
            this.Weight = weight;
        }

        public abstract void ModifyWeight(TNeuronDataType delta);
    }
}