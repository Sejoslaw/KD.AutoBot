using KD.AutoBot.AI;
using System;
using System.Linq;
using System.Threading;

namespace KD.AutoBot.Game.TicTacToe.GeneticSharp.States
{
    /// <summary>
    /// State in which <see cref="IAutoBot"/> is when waiting for opponent's move.
    /// </summary>
    internal class WaitingState : AbstractState
    {
        public WaitingState(ILearningModule learningModule) :
            base(learningModule)
        {
        }

        public override bool PerformNextAction()
        {
            Thread.Sleep(1000);
            this.LearningModule.CurrentState = this.LearningModule.States.ElementAt(1);
            return true;
        }

        public override void PrepareNextAction()
        {
            this.NextAction = new Action(() => { });
        }
    }
}