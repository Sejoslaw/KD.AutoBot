namespace KD.AutoBot
{
    /// <summary>
    /// Abstract implementation of <see cref="IAutoBotBuilder"/>.
    /// </summary>
    public abstract class AbstractAutoBotBuilder : IAutoBotBuilder
    {
        public abstract IAutoBot NewBot(object[] args);
    }
}