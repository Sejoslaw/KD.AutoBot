namespace KD.AutoBot
{
    /// <summary>
    /// Input Handler is used to allow Bot to send keys and mouse events to connected <see cref="System.Diagnostics.Process"/> using specified platform.
    /// </summary>
    public interface IInputHandler : IModule
    {
        /// <summary>
        /// Handler for Keyboard events.
        /// </summary>
        IKeyboardHandler Keyboard { get; }
        /// <summary>
        /// Handler for Mouse events.
        /// </summary>
        IMouseHandler Mouse { get; }
    }
}