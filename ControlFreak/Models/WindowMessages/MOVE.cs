namespace ControlFreak.Models.WindowMessages
{
    using System;
    using Lakhs;

    class MOVE : WindowMessage
    {
        public override string LParamFormat
        {
            get { return "X,Y"; }
        }

        public override Result<string> SendMessage(IntPtr targetHandle, string wParam, string lParam)
        {
            var splited = lParam.Split(',');
            if (splited.Length != 2)
                return Result.Failed("lParam の入力書式が異常です。");

            int x = 0;
            int y = 0;

            if (!int.TryParse(splited[0].Trim(), out x) || !int.TryParse(splited[1].Trim(), out y))
                return Result.Failed("lParam の入力書式が異常です。");

            var result = NativeMethods.SetWindowPos(targetHandle, NativeMethods.HWND_NOTOPMOST, x, y, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_NOZORDER);
            NativeMethods.UpdateWindow(targetHandle);

            return Result.Succeeded(result.ToString());
        }

        public override string ToString()
        {
            return "WM_MOVE";
        }
    }
}
