using System;

namespace KD.AutoBot
{
    /// <summary>
    /// Abstract implementation of <see cref="ILearningModule"/>.
    /// </summary>
    public abstract class AbstractLearningModule : BasicDataHolder, ILearningModule
    {
        public IAutoBot Bot { get; set; }

        public Action NextAction { get; set; }

        public int State { get; set; }

        public AbstractLearningModule(IAutoBot bot)
        {
            this.Bot = bot;
            this.NextAction = null;
            this.State = 0;
        }

        public abstract void LearnFromSource(object source);

        public abstract bool MakeNextAction();

        public abstract void PrepareNextAction();
    }
}