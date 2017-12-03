using System.Collections.Generic;

namespace KD.AutoBot.AI.Abstract
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuralNetwork{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuralNetwork<TNeuronDataType> : AbstractLearnable<object>, INeuralNetwork<TNeuronDataType>
    {
        public INeuralLayer<TNeuronDataType> Input { get; set; }
        public ICollection<INeuralLayer<TNeuronDataType>> HiddenLayers { get; set; }
        public INeuralLayer<TNeuronDataType> Output { get; set; }
    }
}