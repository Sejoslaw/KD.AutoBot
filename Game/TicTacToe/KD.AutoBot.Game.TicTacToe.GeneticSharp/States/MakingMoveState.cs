using KD.AutoBot.AI;
using KD.AutoBot.Connection;
using KD.AutoBot.Connection.Extensions;
using KD.AutoBot.Connection.Windows.Extensions;
using KD.AutoBot.Connection.Windows.Native;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KD.AutoBot.Game.TicTacToe.GeneticSharp.States
{
    internal class MakingMoveState : AbstractState
    {
        public const string TICTACTOE = "TicTacToe";
        public const int BOARD_SIZE = 3;

        public MakingMoveState(ILearningModule learningModule) :
            base(learningModule)
        {
        }

        public override bool PerformNextAction()
        {
            if (this.NextAction != null)
            {
                this.NextAction();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Main method which takes all the required data and components and plays TicTacToe.
        /// </summary>
        public override void PrepareNextAction()
        {
            // TODO: Add logic
            // Check if Bot is connected to game.
            // Build board matrix.
            // Run Genetic Alghoritm on Board.
            // When GA decide which button to press, press it.
            if (this.IsBotConnectedToGame())
            {
                string[][] board = this.BuildBoardMatrix();
            }
            else
            {
                throw new IndexOutOfRangeException("Bot is not connected to any running process.");
            }

            // At the end set waiting module as current.
            this.LearningModule.CurrentState = this.LearningModule.States.ElementAt(0);
        }

        private IConnectedProcess GetGameProcess()
        {
            return this.LearningModule.Bot.ConnectionHandler.ConnectedProcesses.
                Where(process => process.Process.ProcessName.Equals(TICTACTOE)).FirstOrDefault();
        }

        private bool IsBotConnectedToGame()
        {
            return this.GetGameProcess() != null;
        }

        private string[][] BuildBoardMatrix()
        {
            // Initialize board
            string[][] board = new string[BOARD_SIZE][];
            for (int i = 0; i < BOARD_SIZE; ++i)
            {
                board[i] = new string[BOARD_SIZE];
            }

            // Get Buttons control
            IEnumerable<IWindowControl> buttons = this.FindButtons();
            string[] buttonValues = this.GetButtonsValues(buttons);

            // Parse values from buttons text to strings
            this.ParseButtonsValues(buttonValues, board);

            return board;
        }

        private string[] GetButtonsValues(IEnumerable<IWindowControl> buttons)
        {
            int numberOfButtons = buttons.Count();
            string[] buttonValues = new string[numberOfButtons];
            int index = 0;
            foreach (IWindowControl button in buttons)
            {
                string buttonValue = button.GetControlValue().ToString();
                buttonValues[index] = buttonValue;
                index++;
            }
            return buttonValues;
        }

        private void ParseButtonsValues(string[] buttonValues, string[][] board)
        {
            for (int i = 0; i < BOARD_SIZE; ++i)
            {
                for (int j = 0; j < BOARD_SIZE; ++j)
                {
                    board[i][j] = buttonValues[i * BOARD_SIZE + j];
                }
            }
        }

        private IEnumerable<IWindowControl> FindButtons()
        {
            IConnectedProcess gameProcess = this.GetGameProcess();
            IntPtr windowHandler = gameProcess.WindowHandle;
            IWindowControl mainWindowControl = windowHandler.ToWindowControl();
            IWindowControl buttonsGroupBox = NativeMethodsHelper.GetWindowControlByText(mainWindowControl, gameProcess.Process.MainWindowTitle);
            IEnumerable<IWindowControl> buttons = buttonsGroupBox.GetChildControls();
            return buttons;
        }
    }
}