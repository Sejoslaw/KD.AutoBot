using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuronInput{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuronInput<TNeuronDataType> : INeuronInput<TNeuronDataType>
    {
        public ICollection<IDendrite<TNeuronDataType>> Inputs { get; set; }

        public AbstractNeuronInput(ICollection<IDendrite<TNeuronDataType>> inputs)
        {
            this.Inputs = inputs;
        }
    }
}