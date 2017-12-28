using KD.AutoBot.Connection.Extensions;
using KD.AutoBot.Connection.Windows.Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace KD.AutoBot.Connection.Windows.Extensions
{
    /// <summary>
    /// Windows specific implementation of <see cref="IWindowControl"/>.
    /// </summary>
    public class WindowControl : AbstractWindowControl
    {
        public WindowControl(IntPtr controlHandler, IWindowControl parentControl) :
            base(controlHandler, parentControl)
        {
        }

        public override IEnumerable<IWindowControl> GetChildControls()
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

            ISet<IWindowControl> childWindows = new HashSet<IWindowControl>();
            foreach (IntPtr child in childs)
            {
                IWindowControl windowsControl = new WindowControl(child, this);
                childWindows.Add(windowsControl);
            }

            return childWindows;
        }

        public override object GetControlValue()
        {
            string controlText = NativeMethodsHelper.GetControlText(this.ControlHandler);
            return controlText;
        }

        public override object Click()
        {
            // Click Button
            int returned = NativeMethods.SendMessage(this.ControlHandler, NativeConstants.BN_CLICKED, 0, IntPtr.Zero);
            return returned;
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