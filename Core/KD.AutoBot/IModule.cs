namespace KD.AutoBot
{
    /// <summary>
    /// Describes single module for <see cref="IAutoBot"/>.
    /// </summary>
    public interface IModule : IDataHolder, IInitializationEventHandler
    {
        /// <summary>
        /// AutoBot with which this module is connected.
        /// </summary>
        IAutoBot Bot { get; }

        /// <summary>
        /// Initializes the module.
        /// This method is called when AutoBot object is created.
        /// </summary>
        void Initialize();
    }
}