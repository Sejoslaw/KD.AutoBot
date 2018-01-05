using System;
using System.Collections.Generic;
using System.Linq;

namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Abstract implementation of <see cref="INeuron{TNeuronDataType}" />
    /// </summary>
    public abstract class AbstractNeuron<TNeuronDataType> : AbstractLearnable<INeuralLayer<TNeuronDataType>>, INeuron<TNeuronDataType>
    {
        public IDendrite<TNeuronDataType> Bias { get; set; }
        public TNeuronDataType Error { get; set; }
        public Func<INeuron<TNeuronDataType>, TNeuronDataType> ActivationFunction { get; set; }
        public TNeuronDataType ThresholdValue { get; set; }
        public ICollection<IDendrite<TNeuronDataType>> Inputs { get; set; }
        public TNeuronDataType Value { get; set; }

        public IDendrite<TNeuronDataType> this[int index]
        {
            get
            {
                return this.Inputs.ElementAt(index);
            }
        }
    }
}