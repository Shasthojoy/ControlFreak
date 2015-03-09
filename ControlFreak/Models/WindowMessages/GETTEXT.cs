namespace ControlFreak.Models.WindowMessages
{
    using System;
    using System.Text;
    using Lakhs;

    class GETTEXT : WindowMessage
    {
        public override string WParamFormat
        {
            get
            {
                return "length";
            }
        }

        public override Result<string> SendMessage(IntPtr targetHandle, string wParam, string lParam)
        {
            int length = 0;

            if (!int.TryParse(wParam, out length))
                return Result.Failed("wParam の入力書式が異常です。");

            var buffer = Result.Try(() => new StringBuilder(length + 1));
            if (!buffer)
                return Result.Failed(buffer.Exception);

            var result = NativeMethods.SendMessage(targetHandle, NativeMethods.WM_GETTEXT, (IntPtr)buffer.Value.Capacity, buffer.Value);
            return Result.Succeeded(buffer.Value.ToString());
        }

        public override string ToString()
        {
            return "WM_GETTEXT";
        }
    }
}
