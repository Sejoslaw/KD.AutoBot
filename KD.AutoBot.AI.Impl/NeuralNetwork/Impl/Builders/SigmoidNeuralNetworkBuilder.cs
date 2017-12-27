﻿using KD.AutoBot.AI.NeuralNetwork.Impl.Neurons;
using System.Collections.Generic;

namespace KD.AutoBot.AI.NeuralNetwork.Impl.Builders
{
    /// <summary>
    /// Implementation of <see cref="INeuralNetworkBuilder{TNeuronDataType}"/> based on <see cref="double"/> values.
    /// </summary>
    public class SigmoidNeuralNetworkBuilder<TNeuralNetworkType> : SpecificNeuronNeuralNetworkBuilder<TNeuralNetworkType>
        where TNeuralNetworkType : INeuralNetwork<double>, new()
    {
        protected override INeuron<double> GetSpecificNeuron()
        {
            return new SigmoidNeuron(new List<IDendrite<double>>());
        }
    }
}