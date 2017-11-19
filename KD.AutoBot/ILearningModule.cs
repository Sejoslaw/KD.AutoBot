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
        /// Next move which Bot will make.
        /// </summary>
        Action NextMove { get; }
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
        /// Prepares Bot's next move.
        /// </summary>
        void PrepareNextMove();
        /// <summary>
        /// Allowing Bot's to do perform next move.
        /// </summary>
        void MakeNextMove();
    }
}