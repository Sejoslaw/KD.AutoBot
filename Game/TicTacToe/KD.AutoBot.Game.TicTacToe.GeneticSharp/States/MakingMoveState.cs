using KD.AutoBot.AI;
using System.Linq;

namespace KD.AutoBot.Game.TicTacToe.GeneticSharp.States
{
    internal class MakingMoveState : AbstractState
    {
        public override bool PerformNextAction(ILearningModule learningModule)
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
        public override void PrepareNextAction(ILearningModule learningModule)
        {
            // TODO: Add logic

            // At the end set waiting module as current.
            learningModule.CurrentState = learningModule.States.ElementAt(0);
        }
    }
}