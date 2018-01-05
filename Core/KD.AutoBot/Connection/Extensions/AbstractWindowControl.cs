using System;
using System.Collections.Generic;

namespace KD.AutoBot.Connection.Extensions
{
    /// <summary>
    /// Abstract implementation of <see cref="IWindowControl"/>.
    /// </summary>
    public abstract class AbstractWindowControl : IWindowControl
    {
        public IntPtr ControlHandler { get; }
        public IWindowControl ParentControl { get; }

        public AbstractWindowControl(IntPtr controlHandler, IWindowControl parentControl)
        {
            this.ControlHandler = controlHandler;
            this.ParentControl = parentControl;
        }

        public abstract IEnumerable<IWindowControl> GetChildControls();
        public abstract object GetControlValue();
        public abstract object Click();
    }
}