using KD.AutoBot.Connection.Windows;
using KD.AutoBot.Game.TicTacToe.GeneticSharp;
using KD.AutoBot.Input.Windows;
using System;

namespace KD.AutoBot.TicTacToe
{
    /// <summary>
    /// TicTacToe-specific implementation of <see cref="IAutoBot"/>.
    /// </summary>
    [Serializable]
    internal class TicTacToeAutoBot : AbstractAutoBot
    {
        public TicTacToeAutoBot()
        {
            this.ConnectionHandler = new WindowsConnectionHandler(this);
            this.InputHandler = new WindowsInputHandler(this, null, new WindowsMouseHandler(this.InputHandler), null);
            this.LearningModule = new TicTacToeLearningModule(this);
            this.Storage = null; // Currently nothing is saved anywhere.
        }

        public override void PauseBot()
        {
            this.IsPaused = true;
        }

        public override void StopBot()
        {
            this.IsStopped = true;
        }

        public override void StartBot()
        {
            this.IsPaused = false;
            this.IsStopped = false;
            this.RestartBot();
        }

        public override void RestartBot()
        {
            while (!this.IsStopped)
            {
                while (!this.IsPaused)
                {
                    this.LearningModule.PrepareNextAction();
                    this.LearningModule.PerformNextAction();
                }
            }
        }
    }
}