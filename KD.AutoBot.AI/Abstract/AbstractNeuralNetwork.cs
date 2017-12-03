using System.Collections.Generic;

namespace KD.AutoBot.AI.Abstract
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuralNetwork{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuralNetwork<TNeuronDataType> : AbstractLearnable<object>, INeuralNetwork<TNeuronDataType>
    {
        public INeuralLayer<TNeuronDataType> Input { get; protected set; }
        public ICollection<INeuralLayer<TNeuronDataType>> HiddenLayers { get; protected set; }
        public INeuralLayer<TNeuronDataType> Output { get; protected set; }
    }
}