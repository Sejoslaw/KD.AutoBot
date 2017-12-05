namespace KD.AutoBot.AI.NeuralNetwork
{
    /// <summary>
    /// Abstract implementation of <see cref="ILearnable{TLearningSource}" />
    /// </summary>
    public abstract class AbstractLearnable<TLearningSource> : ILearnable<TLearningSource>
    {
        public abstract void ApplyLearning(TLearningSource source);
        public abstract void Pulse(TLearningSource source);
    }
}