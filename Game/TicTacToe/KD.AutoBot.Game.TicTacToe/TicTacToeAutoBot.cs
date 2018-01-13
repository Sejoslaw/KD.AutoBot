using KD.AutoBot.Connection.Windows;
using KD.AutoBot.Connection.Windows.Native;
using KD.AutoBot.Game.TicTacToe.GeneticSharp;
using KD.AutoBot.Input.Windows;
using System;
using System.Diagnostics;

namespace KD.AutoBot.Game.TicTacToe
{
    /// <summary>
    /// TicTacToe-specific implementation of <see cref="IAutoBot"/>.
    /// </summary>
    [Serializable]
    internal class TicTacToeAutoBot : AbstractAutoBot
    {
        /// <summary>
        /// Handler for TicTacToe window.
        /// </summary>
        private IntPtr WindowPtr
        {
            get
            {
                return (IntPtr)this["windowPtr"];
            }
            set
            {
                this["windowPtr"] = value;
            }
        }

        /// <summary>
        /// TicTacToe Char used by this AutoBot.
        /// It should be either X or O.
        /// </summary>
        public string TttChar
        {
            get
            {
                return this["tttChar"].ToString();
            }
            set
            {
                this["tttChar"] = value;
            }
        }

        public TicTacToeAutoBot()
        {
            this.ConnectionHandler = new WindowsConnectionHandler(this);
            this.InputHandler = new WindowsInputHandler(this, null, new WindowsMouseHandler(this.InputHandler), null);
            this.LearningModule = new TicTacToeLearningModule(this);
            this.Storage = null; // Currently nothing is saved anywhere.

            this.ConnectToGame();
            this.FindCurrentPlayerChar();
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

        private void ConnectToGame()
        {
            this.WindowPtr = NativeMethodsHelper.GetWindowByTitle("TicTacToe");
            Process windowProcess = NativeMethodsHelper.GetProcessByWindowHandler(this.WindowPtr);
            this.ConnectionHandler.AttachToProcess(windowProcess);
        }

        private void FindCurrentPlayerChar()
        {
            // TODO: Add logic for getting char from window.
            // Check if Bot is connected to game.
            // Find TetBox with current player char and set it.
        }
    }
}