using KD.AutoBot.Connection.Windows.Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

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
            List<IntPtr> childs = new List<IntPtr>();

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

            List<IWindowsControl> childWindows = new List<IWindowsControl>();
            foreach (IntPtr child in childs)
            {
                IWindowsControl windowsControl = new WindowsControl(child, this);
                childWindows.Add(windowsControl);
            }

            return childWindows;
        }

        public override object GetControlValue()
        {
            IntPtr hDlg = IntPtr.Zero;
            int nIDDlgItem = -1;
            StringBuilder buffer = new StringBuilder();

            if (this.ParentControl == null) // For main window try to return window title
            {
                NativeMethods.GetWindowText(this.ControlHandler, buffer, int.MaxValue);
                string value = buffer.ToString();
                return value;
            }
            else // For child window / control
            {
                hDlg = this.ParentControl.ControlHandler;
                nIDDlgItem = NativeMethods.GetDlgCtrlID(this.ControlHandler);

                int controlId = NativeMethods.GetDlgItem(hDlg, nIDDlgItem);
                IntPtr controlPtr = new IntPtr(controlId);
                NativeMethods.GetWindowText(controlPtr, buffer, int.MaxValue);
                string text = buffer.ToString();
                return text;
            }
        }

        private bool EnumChild(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle handleList = GCHandle.FromIntPtr(lParam);

            if (handleList.Target == null)
            {
                return false;
            }

            List<IntPtr> childHandles = handleList.Target as List<IntPtr>;
            childHandles.Add(hWnd);

            return true;
        }
    }
}