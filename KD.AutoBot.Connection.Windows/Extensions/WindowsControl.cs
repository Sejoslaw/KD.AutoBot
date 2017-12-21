using KD.AutoBot.Connection.Windows.Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static KD.AutoBot.Connection.Windows.Native.NativeMethods;

namespace KD.AutoBot.Connection.Windows.Extensions
{
    /// <summary>
    /// Implementation of <see cref="IWindowsControl"/>.
    /// </summary>
    public class WindowsControl : IWindowsControl
    {
        public IntPtr ControlHandler { get; }
        public IWindowsControl ParentControl { get; }

        public WindowsControl(IntPtr controlHandler, IWindowsControl parentControl)
        {
            this.ControlHandler = controlHandler;
            this.ParentControl = parentControl;
        }

        public IEnumerable<IWindowsControl> GetChildControls()
        {
            List<IntPtr> childs = new List<IntPtr>();

            GCHandle handleList = GCHandle.Alloc(childs);
            IntPtr pointerHandleList = GCHandle.ToIntPtr(handleList);

            try
            {
                EnumWindowsProc childProc = new EnumWindowsProc(this.EnumChild);
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

        public object GetControlValue()
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
            else // For child window
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