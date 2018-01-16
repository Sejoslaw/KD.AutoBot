using KD.AutoBot.Connection.Extensions;
using KD.AutoBot.Connection.Windows;
using KD.AutoBot.Connection.Windows.Extensions;
using KD.AutoBot.Connection.Windows.Native;
using KD.AutoBot.Game.TicTacToe.GeneticSharp;
using KD.AutoBot.Game.TicTacToe.Settings;
using KD.AutoBot.Input.Windows;
using System;
using System.Diagnostics;
using System.Linq;

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
                return (IntPtr)this[TttSettings.WINDOW_PTR];
            }
            set
            {
                this[TttSettings.WINDOW_PTR] = value;
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
                return this[TttSettings.TTT_CHAR].ToString();
            }
            set
            {
                this[TttSettings.TTT_CHAR] = value;
            }
        }

        public TicTacToeAutoBot()
        {
            this.ConnectionHandler = new WindowsConnectionHandler(this);
            this.InputHandler = new WindowsInputHandler(this, null, new WindowsMouseHandler(this.InputHandler), null);
            this.Storage = null; // Currently nothing is saved anywhere.

            this.ConnectAutoBotToProcess();
            this.SetCurrentPlayerChar();

            this.LearningModule = new TicTacToeLearningModule(this);
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

        private void ConnectAutoBotToProcess()
        {
            Tuple<IntPtr, Process> process = NativeMethodsHelper.ConnectAutoBotToProcess(this, TttSettings.TIC_TAC_TOE);
            this.WindowPtr = process.Item1;
        }

        private void SetCurrentPlayerChar()
        {
            if (this.IsBotConnectedToGame())
            {
                this.TttChar = this.FindCurrentPlayerChar();
            }
        }

        private bool IsBotConnectedToGame()
        {
            return this.ConnectionHandler.ConnectedProcesses.
                Where(connectedProcess => connectedProcess.Process.ProcessName.Contains(TttSettings.TIC_TAC_TOE)).Count() > 0;
        }

        private string FindCurrentPlayerChar()
        {
            IWindowControl mainControl = new WindowControl(this.WindowPtr, null);
            IWindowControl playerCharGroupBox = NativeMethodsHelper.GetWindowControlByText(mainControl, "Current Player Turn");
            IWindowControl charControl = playerCharGroupBox.GetChildControls().FirstOrDefault();
            string tttChar = charControl.GetControlValue().ToString();
            return tttChar;
        }
    }
}