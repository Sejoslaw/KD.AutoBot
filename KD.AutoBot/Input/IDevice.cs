namespace KD.AutoBot.Input
{
    /// <summary>
    /// Describes single I/O computer device.
    /// </summary>
    public interface IDevice : IDataHolder
    {
        /// <summary>
        /// Input Handler connected with current device.
        /// </summary>
        IInputHandler InputHandler { get; }

        /// <summary>
        /// Initialize the device.
        /// This method is fired when Input Handler object is created.
        /// </summary>
        void Initialize();
    }
}