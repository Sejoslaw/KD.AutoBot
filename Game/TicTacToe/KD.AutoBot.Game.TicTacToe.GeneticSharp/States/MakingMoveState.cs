using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
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
        public const string TTT_CHAR = "tttChar";
        public const string TICTACTOE = "TicTacToe";
        public static readonly int BOARD_SIZE = Settings.BoardSize;

        private string TttChar { get; set; }

        public MakingMoveState(ILearningModule learningModule) :
            base(learningModule)
        {
            object genericChar = this.LearningModule.Bot[TTT_CHAR];
            if (genericChar == null)
            {
                throw new NullReferenceException("Unknown AutoBot's char.");
            }

            this.TttChar = genericChar.ToString();
            if (this.TttChar == null)
            {
                throw new IndexOutOfRangeException($"Player char should be stored in AutoBot with key equals. \"{ TTT_CHAR }\"");
            }
        }

        public override bool PerformNextAction()
        {
            this.LearningModule.CurrentState = this.LearningModule.States.ElementAt(0);

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
            if (!this.CanMakeMove())
            {
                return;
            }

            if (this.IsBotConnectedToGame())
            {
                string[][] board = this.BuildBoardMatrix();
                GeneticAlgorithm geneticAlgorithm = this.PrepareGeneticAlgorithm(board);
                // Start genetic algorithm ale let it find best solution.
                geneticAlgorithm.Start();

                TicTacToeChromosome chromosome = geneticAlgorithm.BestChromosome as TicTacToeChromosome;
                Point boardCell = chromosome.Position;
                IEnumerable<IWindowControl> buttons = this.FindButtons();
                this.PressButton(buttons, boardCell);
            }
            else
            {
                throw new IndexOutOfRangeException("Bot is not connected to any running process.");
            }
        }

        private bool CanMakeMove()
        {
            IWindowControl mainControl = this.LearningModule.Bot.ConnectionHandler.ConnectedProcesses.ElementAt(0).WindowHandle.ToWindowControl();
            IWindowControl playerCharGroupBox = NativeMethodsHelper.GetWindowControlByText(mainControl, "Current Player Turn");
            IWindowControl charControl = playerCharGroupBox.GetChildControls().FirstOrDefault();
            string tttChar = charControl.GetControlValue().ToString();

            return this.TttChar.Equals(tttChar);
        }

        private void PressButton(IEnumerable<IWindowControl> buttons, Point boardCell)
        {
            IWindowControl button = buttons.ElementAt(boardCell.X * BOARD_SIZE + boardCell.Y);
            this.NextAction = () => button.Click();
        }

        private GeneticAlgorithm PrepareGeneticAlgorithm(string[][] board)
        {
            double[][] parsedBoard = this.ParseBoardToDouble(board);

            var chromosome = new TicTacToeChromosome(parsedBoard);
            var population = new Population(50, 100, chromosome);
            var fitness = new TicTacToeFitness
            {
                Minimum = BOARD_SIZE
            };
            var selection = new EliteSelection();
            var crossover = new UniformCrossover(0.5f);
            var mutation = new UniformMutation();
            var termination = new OrTermination(new ITermination[]
            {
                new FitnessStagnationTermination(1000),
                new FitnessThresholdTermination(4),
                new FitnessThresholdTermination(3),
                new FitnessThresholdTermination(2)
            });

            var geneticAlgorithm = new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
            {
                Termination = termination
            };

            return geneticAlgorithm;
        }

        private double[][] ParseBoardToDouble(string[][] board)
        {
            double[][] parsed = new double[board.Length][];

            for (int i = 0; i < board.Length; ++i)
            {
                parsed[i] = new double[board[i].Length];
            }

            for (int i = 0; i < board.Length; ++i)
            {
                string[] line = board[i];
                for (int j = 0; j < line.Length; ++j)
                {
                    string value = line[j];
                    double parsedValue;
                    if (value.Equals(""))
                    {
                        parsedValue = 0;
                    }
                    else
                    {
                        parsedValue = this.ParseBoardChar(value);
                    }
                    parsed[i][j] = parsedValue;
                }
            }

            return parsed;
        }

        private double ParseBoardChar(string value)
        {
            if (value.Equals(this.TttChar))
            {
                return 1;
            }
            return -1;
        }

        private IConnectedProcess GetGameProcess()
        {
            return this.LearningModule.Bot.ConnectionHandler.ConnectedProcesses.
                Where(process => process.Process.MainWindowTitle.Equals(TICTACTOE)).FirstOrDefault();
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
            IWindowControl buttonsGroupBox = NativeMethodsHelper.GetWindowControlByText(mainWindowControl, "Buttons");
            IEnumerable<IWindowControl> buttons = buttonsGroupBox.GetChildControls();

            return buttons;
        }
    }
}