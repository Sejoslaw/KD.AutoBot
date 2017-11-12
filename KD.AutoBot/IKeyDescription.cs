namespace KD.AutoBot
{
    /// <summary>
    /// Describes single key available for Bot to press.
    /// </summary>
    public interface IKeyDescription : IDataHolder
    {
        /// <summary>
        /// Connected Keyboard Handler.
        /// </summary>
        IKeyboardHandler Keyboard { get; }
        /// <summary>
        /// Code of the key.
        /// </summary>
        int KeyCode { get; }
        /// <summary>
        /// Indicates if this button is pressed or released.
        /// </summary>
        bool IsKeyPressed { get; }

        /// <summary>
        /// Describes what should happen when the specified key was pressed.
        /// </summary>
        void OnKeyPress();
        /// <summary>
        /// Describes what should happen when the specified key was released.
        /// </summary>
        void OnKeyRelease();
    }
}