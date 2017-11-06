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