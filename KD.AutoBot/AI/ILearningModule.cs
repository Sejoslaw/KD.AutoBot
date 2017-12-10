﻿using System;

namespace KD.AutoBot.AI
{
    /// <summary>
    /// Main module which is responsible for Bot learning.
    /// </summary>
    public interface ILearningModule : IModule
    {
        /// <summary>
        /// Next <see cref="Action"/> which Bot will make.
        /// </summary>
        Action NextAction { get; }
        /// <summary>
        /// Integer is used for more possibilities than enum.
        /// 1 - Won
        /// 0 - Working
        /// -1 - Lose
        /// When "Lose", restart Bot and start from beginning, also set state to "0".
        /// </summary>
        int State { get; }

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