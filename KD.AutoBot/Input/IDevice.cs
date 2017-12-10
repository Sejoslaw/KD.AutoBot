namespace KD.AutoBot.Input
{
    /// <summary>
    /// Describes single I/O device.
    /// By "Device" we can understand any Keyboard, Mouse, Joystick, Controller, etc.
    /// But also it can be a Device that can take data from for example: window controls.
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
