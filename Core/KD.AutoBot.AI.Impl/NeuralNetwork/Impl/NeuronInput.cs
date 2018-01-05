using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork.Impl
{
    /// <summary>
    /// Implementation of <see cref="INeuronInput{TNeuronDataType}"/> based on <see cref="double"/> values.
    /// </summary>
    public class NeuronInput : AbstractNeuronInput<double>
    {
        public NeuronInput(ICollection<IDendrite<double>> inputs) :
            base(inputs)
        {
        }
    }
}