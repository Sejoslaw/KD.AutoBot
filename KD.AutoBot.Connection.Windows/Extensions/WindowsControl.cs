using KD.AutoBot.Connection.Windows.Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace KD.AutoBot.Connection.Windows.Extensions
{
    /// <summary>
    /// Implementation of <see cref="IWindowsControl"/>.
    /// </summary>
    public class WindowsControl : AbstractWindowsControl
    {
        public WindowsControl(IntPtr controlHandler, IWindowsControl parentControl) :
            base(controlHandler, parentControl)
        {
        }

        public override IEnumerable<IWindowsControl> GetChildControls()
        {
            ISet<IntPtr> childs = new HashSet<IntPtr>();

            GCHandle handleList = GCHandle.Alloc(childs);
            IntPtr pointerHandleList = GCHandle.ToIntPtr(handleList);

            try
            {
                NativeMethods.EnumWindowsProc childProc = new NativeMethods.EnumWindowsProc(this.EnumChild);
                NativeMethods.EnumChildWindows(this.ControlHandler, childProc, pointerHandleList);
            }
            finally
            {
                handleList.Free();
            }

            ISet<IWindowsControl> childWindows = new HashSet<IWindowsControl>();
            foreach (IntPtr child in childs)
            {
                IWindowsControl windowsControl = new WindowsControl(child, this);
                childWindows.Add(windowsControl);
            }

            return childWindows;
        }

        public override object GetControlValue()
        {
            string controlText = NativeMethodsHelper.GetControlText(this.ControlHandler);
            return controlText;
        }

        private bool EnumChild(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle handleList = GCHandle.FromIntPtr(lParam);

            if (handleList.Target == null)
            {
                return false;
            }

            ISet<IntPtr> childHandles = handleList.Target as ISet<IntPtr>;
            childHandles.Add(hWnd);

            return true;
        }
    }
}