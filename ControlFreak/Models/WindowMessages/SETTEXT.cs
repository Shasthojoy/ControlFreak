namespace ControlFreak.Models.WindowMessages
{
    using System;
    using Lakhs;

    class SETTEXT : WindowMessage
    {
        public override string LParamFormat
        {
            get { return "Text"; }
        }

        public override Result<string> SendMessage(IntPtr targetHandle, string wParam, string lParam)
        {
            var result = NativeMethods.SendMessage(targetHandle, NativeMethods.WM_SETTEXT, IntPtr.Zero, lParam);
            //NativeMethods.SetWindowText(targetHandle, lParam);
            NativeMethods.UpdateWindow(targetHandle);

            return Result.Succeeded(result.ToString());
        }

        public override string ToString()
        {
            return "WM_SETTEXT";
        }
    }
}
