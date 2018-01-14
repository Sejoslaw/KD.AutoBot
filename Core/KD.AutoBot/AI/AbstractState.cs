using System;

namespace KD.AutoBot.AI
{
    /// <summary>
    /// Abstract implementation of <see cref="IState"/>.
    /// </summary>
    public abstract class AbstractState : BasicDataHolder, IState
    {
        public Action NextAction { get; set; }
        public object Value { get; set; }
        public ILearningModule LearningModule { get; private set; }

        public AbstractState(ILearningModule learningModule)
        {
            this.LearningModule = learningModule;
        }

        public abstract bool PerformNextAction();
        public abstract void PrepareNextAction();
    }
}