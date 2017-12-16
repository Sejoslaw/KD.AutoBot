namespace KD.AutoBot.Connection
{
    /// <summary>
    /// Abstract implementation of <see cref="IPlatformConnectionExtension"/>.
    /// </summary>
    public abstract class AbstractPlatformConnectionExtension : BasicDataHolder, IPlatformConnectionExtension
    {
        public IPlatformConnectionTools PlatformConnectionTools { get; set; }

        public AbstractPlatformConnectionExtension(IPlatformConnectionTools platformConnectionTools)
        {
            this.PlatformConnectionTools = platformConnectionTools;
        }
    }
}