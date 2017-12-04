namespace KD.AutoBot
{
    /// <summary>
    /// Abstract implementation of <see cref="IModule"/>.
    /// </summary>
    public abstract class AbstractModule : BasicDataHolder, IModule
    {
        public IAutoBot Bot { get; }

        public AbstractModule(IAutoBot bot)
        {
            this.Bot = bot;
        }

        public abstract void Initialize();
    }
}