namespace KD.AutoBot
{
    /// <summary>
    /// Builder use to create new <see cref="IAutoBot"/>.
    /// </summary>
    public interface IAutoBotBuilder
    {
        /// <summary>
        /// Returns new <see cref="IAutoBot"/>.
        /// </summary>
        IAutoBot NewBot(object[] args);
    }
}