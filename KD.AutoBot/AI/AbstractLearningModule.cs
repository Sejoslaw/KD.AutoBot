using System;

namespace KD.AutoBot.AI
{
    /// <summary>
    /// Abstract implementation of <see cref="ILearningModule"/>.
    /// </summary>
    public abstract class AbstractLearningModule : AbstractModule, ILearningModule
    {
        public Action NextAction { get; set; }
        public int State { get; set; }

        protected AbstractLearningModule(IAutoBot bot) :
            base(bot)
        {
            this.NextAction = null;
            this.State = 0;
        }

        public override void Initialize()
        {
        }

        public abstract void LearnFromSource(object source);

        public abstract bool PerformNextAction();

        public abstract void PrepareNextAction();
    }
}