namespace KD.AutoBot.AI
{
    /// <summary>
    /// Describes object as a learnable.
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