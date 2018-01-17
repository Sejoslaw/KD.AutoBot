using KD.AutoBot.AI;
using KD.AutoBot.Connection.Extensions;
using KD.AutoBot.Connection.Windows.Native;
using KD.AutoBot.Connection.Windows.Extensions;
using KD.AutoBot.Game.TicTacToe.Settings;
using System.Linq;
using System;

namespace KD.AutoBot.Game.TicTacToe.GeneticSharp.States
{
    public abstract class AbstractTicTacToeState : AbstractState
    {
        protected string TttChar { get; set; }

        public AbstractTicTacToeState(ILearningModule learningModule) :
            base(learningModule)
        {
            object genericChar = this.LearningModule.Bot[TttSettings.TTT_CHAR];
            if (genericChar == null)
            {
                throw new NullReferenceException("Unknown AutoBot's char.");
            }

            this.TttChar = genericChar.ToString();
            if (this.TttChar == null)
            {
                throw new IndexOutOfRangeException($"Player char should be stored in AutoBot with key equals. \"{ TttSettings.TTT_CHAR }\"");
            }
        }

        protected bool CanMakeMove()
        {
            IWindowControl mainControl = this.LearningModule.Bot.ConnectionHandler.ConnectedProcesses.ElementAt(0).WindowHandle.ToWindowControl();
            IWindowControl playerCharGroupBox = NativeMethodsHelper.GetWindowControlByText(mainControl, TttSettings.CURRENT_PLAYER_TURN);
            IWindowControl charControl = playerCharGroupBox.GetChildControls().FirstOrDefault();
            string tttChar = charControl.GetControlValue().ToString();

            return this.TttChar.Equals(tttChar);
        }
    }
}