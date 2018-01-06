using KD.AutoBot.AI;
using KD.AutoBot.Game.TicTacToe.GeneticSharp.States;
using System.Linq;

namespace KD.AutoBot.Game.TicTacToe.GeneticSharp
{
    public class TicTacToeLearningModule : AbstractLearningModule
    {
        public TicTacToeLearningModule(IAutoBot bot) :
            base(bot)
        {
            this.States.Add(new WaitingState());
            this.States.Add(new MakingMoveState());

            this.CurrentState = this.States.ElementAt(0);
        }
    }
}