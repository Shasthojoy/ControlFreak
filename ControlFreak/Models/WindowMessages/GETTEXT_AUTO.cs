namespace ControlFreak.Models.WindowMessages
{
    using System;
    using System.Text;
    using Lakhs;

    class GETTEXT_AUTO : WindowMessage
    {
        public override Result<string> SendMessage(IntPtr targetHandle, string wParam, string lParam)
        {
            var length = NativeMethods.SendMessage(targetHandle, NativeMethods.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
            var buffer = Result.Try(() => new StringBuilder(length.ToInt32() + 1));
            if (!buffer)
                return Result.Failed(buffer.Exception);

            var result = NativeMethods.SendMessage(targetHandle, NativeMethods.WM_GETTEXT, (IntPtr)buffer.Value.Capacity, buffer.Value);
            return Result.Succeeded(buffer.Value.ToString());
        }

        public override string ToString()
        {
            return "WM_GETTEXT(Auto)";
        }
    }
}
