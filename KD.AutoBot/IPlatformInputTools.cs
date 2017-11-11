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
        /// Sends key pressed to current platform.
        /// </summary>
        void SendKeyPressed(int keyCode);
        /// <summary>
        /// Sends key released to current platform.
        /// </summary>
        void SendKeyReleased(int keyCode);
    }
}