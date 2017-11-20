using System;
using System.IO;

namespace KD.AutoBot
{
    /// <summary>
    /// Main module which is responsible for Bot learning.
    /// </summary>
    public interface ILearningModule : IDataHolder
    {
        /// <summary>
        /// Bot connected with this Module.
        /// </summary>
        IAutoBot Bot { get; }
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
        /// Starts learning process from given file.
        /// </summary>
        void LearnFromFile(FileInfo file);
        /// <summary>
        /// Prepares Bot's next <see cref="Action"/>.
        /// </summary>
        void PrepareNextAction();
        /// <summary>
        /// Allows Bot's to perform next <see cref="Action"/>.
        /// Returns true if the <see cref="Action"/> has been made; otherwise false.
        /// </summary>
        bool MakeNextAction();
    }
}