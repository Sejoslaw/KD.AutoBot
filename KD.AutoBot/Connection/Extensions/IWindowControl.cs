using System;
using System.Collections.Generic;

namespace KD.AutoBot.Connection.Extensions
{
    /// <summary>
    /// Describes single window control.
    /// </summary>
    public interface IWindowControl
    {
        /// <summary>
        /// Current control handler.
        /// This a process pointer, it still needs to be parsed to control id.
        /// </summary>
        IntPtr ControlHandler { get; }
        /// <summary>
        /// Parent control of this window.
        /// Null if the window has no parent.
        /// </summary>
        IWindowControl ParentControl { get; }

        /// <summary>
        /// Returns a collection of child controls.
        /// </summary>
        IEnumerable<IWindowControl> GetChildControls();
        /// <summary>
        /// Returns value of current control.
        /// For window it will return the title of the window.
        /// </summary>
        object GetControlValue();
    }
}