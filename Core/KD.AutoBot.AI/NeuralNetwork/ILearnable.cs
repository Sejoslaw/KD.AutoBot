namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Describes object which can learn from specified source.
    /// </summary>
    public interface ILearnable<TLearningSource>
    {
        /// <summary>
        /// Sets data required for learning.
        /// </summary>
        void Pulse(TLearningSource source);
        /// <summary>
        /// Learns current object.
        /// </summary>
        void ApplyLearning(TLearningSource source);
    }
}