namespace KD.AutoBot
{
    /// <summary>
    /// Tools for specified platform.
    /// </summary>
    public interface IPlatformTools : IDataHolder
    {
        /// <summary>
        /// Name of the platform for which this tools should be used.
        /// </summary>
        string PlatformName { get; }
    }
}