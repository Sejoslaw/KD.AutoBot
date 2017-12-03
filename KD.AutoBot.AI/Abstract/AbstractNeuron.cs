using System;
using System.Collections.Generic;

namespace KD.AutoBot.AI.Abstract
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuron{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuron<TNeuronDataType> : AbstractLearnable<INeuralLayer<TNeuronDataType>>, INeuron<TNeuronDataType>
    {
        public IDendrite<TNeuronDataType> Bias { get; protected set; }
        public TNeuronDataType Error { get; protected set; }
        public Func<INeuron<TNeuronDataType>, TNeuronDataType> ActivationFunction { get; protected set; }
        public TNeuronDataType ThresholdValue { get; protected set; }
        public ICollection<IDendrite<TNeuronDataType>> Inputs { get; protected set; }
        public TNeuronDataType Value { get; set; }
    }
}