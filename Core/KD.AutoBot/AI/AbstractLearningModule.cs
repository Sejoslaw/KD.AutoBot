using System.Collections.Generic;

namespace KD.AutoBot.AI
{
    /// <summary>
    /// Abstract implementation of <see cref="ILearningModule"/>.
    /// </summary>
    public abstract class AbstractLearningModule : AbstractModule, ILearningModule
    {
        public IState CurrentState { get; set; }
        public ICollection<IState> States { get; set; }

        protected AbstractLearningModule(IAutoBot bot) :
            base(bot)
        {
        }

        public override void Initialize()
        {
        }

        public virtual void PrepareNextAction()
        {
            this.CurrentState.PrepareNextAction(this);
        }

        public virtual bool PerformNextAction()
        {
            bool actionResult = this.CurrentState.PerformNextAction(this);
            return actionResult;
        }

        public virtual void LearnFromSource(object source)
        {
        }
    }
}