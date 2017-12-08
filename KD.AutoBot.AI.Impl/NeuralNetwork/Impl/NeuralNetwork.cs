namespace KD.AutoBot.AI.NeuralNetwork.Impl
{
    /// <summary>
    /// Implementation of <see cref="INeuralNetwork{TNeuronDataType}"/> based on <see cref="double"/> values.
    /// </summary>
    public class NeuralNetwork : AbstractNeuralNetwork<double>
    {
        public override void ApplyLearning(object source)
        {
            lock (this)
            {
                foreach (INeuralLayer<double> layer in this.HiddenLayers)
                {
                    layer.ApplyLearning(this);
                }
                this.Output.ApplyLearning(this);
            }
        }

        public override void Pulse(object source)
        {
            lock (this)
            {
                foreach (INeuralLayer<double> layer in this.HiddenLayers)
                {
                    layer.Pulse(this);
                }
                this.Output.Pulse(this);
            }
        }
    }
}