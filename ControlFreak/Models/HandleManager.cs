namespace ControlFreak.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using ControlFreak.Models.WindowMessages;
    using Lakhs;

    static class HandleManager
    {
        static HandleManager()
        {
            _buffer = new StringBuilder(256);
            _getText = new GETTEXT_AUTO();
        }

        public static HandleObject GetAllHandleObject()
        {
            var desktop = CreateHandleObject(NativeMethods.GetDesktopWindow());
            desktop.WindowCaption = "Desktop";
            new Helper(desktop, desktop).Get();

            return desktop;
        }

        private static HandleObject CreateHandleObject(IntPtr handle)
        {
            var obj = new HandleObject(handle);
            NativeMethods.GetClassName(handle, _buffer, _buffer.Capacity);
            obj.ClassName = _buffer.ToString();
            obj.WindowCaption = "???";

            _getText.SendMessage(handle, null, null)
                    .IfSuccess(x => obj.WindowCaption = x);

            return obj;
        }

        private class Helper
        {
            public Helper(HandleObject parent, HandleObject root)
            {
                this._parent = parent;
                this._root = root;
            }

            public void Get()
            {
                NativeMethods.EnumChildWindows(this._parent.Handle, EnumWindowProc, IntPtr.Zero);
            }

            private bool EnumWindowProc(IntPtr handle, IntPtr lParam)
            {
                if (this._root.GetDescendant(handle) != null)
                    return true;

                var newObj = HandleManager.CreateHandleObject(handle);
                newObj.Parent = this._parent;
                this._parent.Children.Add(newObj);
                new Helper(newObj, this._root).Get();

                return true;
            }

            private HandleObject _parent;
            private HandleObject _root;
        }

        private static StringBuilder _buffer;
        private static GETTEXT_AUTO _getText;
    }
}
