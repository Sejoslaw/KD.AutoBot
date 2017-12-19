using System;

namespace KD.AutoBot.AI
{
    /// <summary>
    /// Describes single state in which Bot can be.
    /// 
    /// By default states are understand as below:
    /// 1 - Won
    /// 0 - Working
    /// -1 - Lose
    /// When "Lose", restart Bot and start from beginning, also set state to "0".
    /// </summary>
    public interface IState : IDataHolder
    {
        /// <summary>
        /// Next <see cref="Action"/> which Bot will make.
        /// </summary>
        Action NextAction { get; }
        /// <summary>
        /// Value of current state.
        /// </summary>
        object Value { get; }

        /// <summary>
        /// Prepares Bot's next <see cref="Action"/>.
        /// </summary>
        void PrepareNextAction(ILearningModule learningModule);
        /// <summary>
        /// Allows Bot's to perform next <see cref="Action"/>.
        /// Returns true if the <see cref="Action"/> has been made; otherwise false.
        /// </summary>
        bool PerformNextAction(ILearningModule learningModule);
    }
}