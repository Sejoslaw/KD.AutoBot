using System.Collections.Generic;

namespace KD.AutoBot.AI
{
    /// <summary>
    /// Main module which is responsible for Bot learning.
    /// </summary>
    public interface ILearningModule : IModule
    {
        /// <summary>
        /// Bots current state.
        /// </summary>
        IState CurrentState { get; }
        /// <summary>
        /// All states in which Bot can be.
        /// </summary>
        ICollection<IState> States { get; }

        /// <summary>
        /// Starts learning process from given source.
        /// </summary>
        void LearnFromSource(object source);
        /// <summary>
        /// Prepares Bot's next <see cref="Action"/>.
        /// </summary>
        void PrepareNextAction();
        /// <summary>
        /// Allows Bot's to perform next <see cref="Action"/>.
        /// Returns true if the <see cref="Action"/> has been made; otherwise false.
        /// </summary>
        bool PerformNextAction();
    }
}