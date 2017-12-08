using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuralNetwork{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuralNetwork<TNeuronDataType> : AbstractLearnable<object>, INeuralNetwork<TNeuronDataType>
    {
        public INeuralLayer<TNeuronDataType> Input { get; set; }
        public ICollection<INeuralLayer<TNeuronDataType>> HiddenLayers { get; set; }
        public INeuralLayer<TNeuronDataType> Output { get; set; }
        public TNeuronDataType LearningRate { get; set; }

        public abstract void Initialize(INeuralLayer<TNeuronDataType> input, ICollection<INeuralLayer<TNeuronDataType>> hiddenLayers, INeuralLayer<TNeuronDataType> output);
        public abstract void Train(TNeuronDataType[] input, TNeuronDataType[] wantedResults);
        public abstract void Train(TNeuronDataType[][] input, TNeuronDataType[][] wantedResults);
    }
}