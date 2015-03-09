namespace ControlFreak.Models.WindowMessages
{
    using System;
    using Lakhs;

    class ENABLE : WindowMessage
    {
        public override string WParamFormat
        {
            get { return "true|false"; }
        }

        public override Result<string> SendMessage(IntPtr targetHandle, string wParam, string lParam)
        {
            bool enabled = false;

            if(!bool.TryParse(wParam.ToLower(), out enabled))
                return Result.Failed("wParam の入力書式が異常です。");

            //NativeMethods.SendMessage(targetHandle, NativeMethods.WM_ENABLE, ConvertToIntPtr(enabled), IntPtr.Zero);
            var result = NativeMethods.EnableWindow(targetHandle, enabled);
            NativeMethods.UpdateWindow(targetHandle);

            return Result.Succeeded(result.ToString());
        }

        public override string ToString()
        {
            return "WM_ENABLE";
        }
    }
}
