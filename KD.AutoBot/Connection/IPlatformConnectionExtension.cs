namespace KD.AutoBot.Connection
{
    /// <summary>
    /// Single extension which will allow bot to get value from some system object.
    /// </summary>
    public interface IPlatformConnectionExtension
    {
        /// <summary>
        /// Connected <see cref="IPlatformConnectionTools"/>.
        /// </summary>
        IPlatformConnectionTools PlatformConnectionTools { get; }
    }
}