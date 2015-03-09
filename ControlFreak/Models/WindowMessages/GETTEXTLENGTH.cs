namespace ControlFreak.Models.WindowMessages
{
    using System;
    using Lakhs;

    class GETTEXTLENGTH : WindowMessage
    {

        public override Result<string> SendMessage(IntPtr targetHandle, string wParam, string lParam)
        {
            var result = NativeMethods.SendMessage(targetHandle, NativeMethods.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
            return Result.Succeeded(result.ToString());
        }

        public override string ToString()
        {
            return "WM_GETTEXTLENGTH";
        }
    }
}
