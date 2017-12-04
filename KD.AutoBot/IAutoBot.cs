using System.Collections.Generic;

namespace KD.AutoBot
{
    /// <summary>
    /// AutoBot which can connect to specific <see cref="System.Diagnostics.Process"/> and perform specified operations on it.
    /// Also it learns during working.
    /// </summary>
    public interface IAutoBot : IDataHolder
    {
        /// <summary>
        /// Data Storage in which Bot will store it's data.
        /// </summary>
        IDataStorage Storage { get; }
        /// <summary>
        /// Input Handler which is used by the Bot to send keys and mouse input to connected <see cref="System.Diagnostics.Process"/>.
        /// </summary>
        IInputHandler InputHandler { get; }
        /// <summary>
        /// Connection Handler which specifies how the Bot should connect to <see cref="System.Diagnostics.Process"/>.
        /// Also holds information about connected processes.
        /// </summary>
        IConnectionHandler ConnectionHandler { get; }
        /// <summary>
        /// The most important module, which specifies how the Bot learns.
        /// </summary>
        ILearningModule LearningModule { get; }
        /// <summary>
        /// AutoBot's additional modules.
        /// </summary>
        ICollection<IModule> Modules { get; }

        /// <summary>
        /// Method used to start the Bot.
        /// </summary>
        void StartBot();
        /// <summary>
        /// Method used to pause the Bot and save all current work.
        /// </summary>
        void PauseBot();
        /// <summary>
        /// Method used to end the Bot's work.
        /// </summary>
        void StopBot();
        /// <summary>
        /// Method used to restart Bot's work from beginning but with already learned things.
        /// </summary>
        void RestartBot();
    }
}