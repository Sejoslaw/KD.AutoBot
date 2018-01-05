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
        /// For most controls it will return the text value of that control.
        /// </summary>
        object GetControlValue();
        /// <summary>
        /// Simulates clicking current control.
        /// </summary>
        object Click();
    }
}