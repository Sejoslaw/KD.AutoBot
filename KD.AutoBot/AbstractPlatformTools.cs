namespace KD.AutoBot
{
    /// <summary>
    /// Abstract implementation of <see cref="IPlatformTools"/>.
    /// </summary>
    public class AbstractPlatformTools : BasicDataHolder, IPlatformTools
    {
        public string PlatformName { get; }

        public AbstractPlatformTools(string platformName)
        {
            this.PlatformName = platformName;
        }
    }
}