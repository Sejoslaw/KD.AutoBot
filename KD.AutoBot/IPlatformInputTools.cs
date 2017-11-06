namespace KD.AutoBot
{
    /// <summary>
    /// Describes tools used to do input operations on single platform.
    /// </summary>
    public interface IPlatformInputTools : IPlatformTools
    {
        /// <summary>
        /// Handler connected with this platform tools.
        /// </summary>
        IInputHandler InputHandler { get; }

        /// <summary>
        /// Sends key input to current platform.
        /// </summary>
        void SendKey(int keyCode);
    }
}