using System;

namespace KD.AutoBot
{
    /// <summary>
    /// Event Handler which contains data about <see cref="event"/>s connected with <see cref="IAutoBot"/>.
    /// </summary>
    public interface IAutoBotEventHandler : IInitializationEventHandler
    {
        /// <summary>
        /// Event which is fired when <see cref="IAutoBot.StartBot"/> method is starting.
        /// </summary>
        event EventHandler OnPreStart;
        /// <summary>
        /// Event which is fired when <see cref="IAutoBot.StartBot"/> method is finishing.
        /// </summary>
        event EventHandler OnPostStart;
        /// <summary>
        /// Event which is fired when <see cref="IAutoBot.PauseBot"/> method is starting.
        /// </summary>
        event EventHandler OnPrePause;
        /// <summary>
        /// Event which is fired when <see cref="IAutoBot.PauseBot"/> method is finishing.
        /// </summary>
        event EventHandler OnPostPause;
        /// <summary>
        /// Event which is fired when <see cref="IAutoBot.StopBot"/> method is starting.
        /// </summary>
        event EventHandler OnPreStop;
        /// <summary>
        /// Event which is fired when <see cref="IAutoBot.StopBot"/> method is finishing.
        /// </summary>
        event EventHandler OnPostStop;
        /// <summary>
        /// Event which is fired when <see cref="IAutoBot.RestartBot"/> method is starting.
        /// </summary>
        event EventHandler OnPreRestart;
        /// <summary>
        /// Event which is fired when <see cref="IAutoBot.RestartBot"/> method is finishing.
        /// </summary>
        event EventHandler OnPostRestart;
    }
}