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

        public abstract bool PerformNextAction(ILearningModule learningModule);
        public abstract void PrepareNextAction(ILearningModule learningModule);
    }
}