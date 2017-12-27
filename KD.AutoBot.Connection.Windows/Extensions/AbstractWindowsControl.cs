using System;
using System.Collections.Generic;

namespace KD.AutoBot.Connection.Windows.Extensions
{
    /// <summary>
    /// Abstract implementation of <see cref="IWindowsControl"/>.
    /// </summary>
    public abstract class AbstractWindowsControl : IWindowsControl
    {
        public IntPtr ControlHandler { get; }
        public IWindowsControl ParentControl { get; }

        public AbstractWindowsControl(IntPtr controlHandler, IWindowsControl parentControl)
        {
            this.ControlHandler = controlHandler;
            this.ParentControl = parentControl;
        }

        public abstract IEnumerable<IWindowsControl> GetChildControls();
        public abstract object GetControlValue();
    }
}