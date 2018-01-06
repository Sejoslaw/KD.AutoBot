using KD.AutoBot.AI;
using System.Linq;
using System.Threading;

namespace KD.AutoBot.Game.TicTacToe.GeneticSharp.States
{
    /// <summary>
    /// State in which <see cref="IAutoBot"/> is when waiting for opponent's move.
    /// </summary>
    internal class WaitingState : AbstractState
    {
        public override bool PerformNextAction(ILearningModule learningModule)
        {
            return true;
        }

        public override void PrepareNextAction(ILearningModule learningModule)
        {
            Thread.Sleep(2000);
            learningModule.CurrentState = learningModule.States.ElementAt(1);
        }
    }
}