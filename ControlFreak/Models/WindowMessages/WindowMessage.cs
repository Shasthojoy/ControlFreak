namespace ControlFreak.Models.WindowMessages
{
    using System;
    using Lakhs;

    /// <summary>
    /// WindowsMessage を処理する機能を提供します。
    /// </summary>
    public abstract class WindowMessage
    {
        /// <summary>
        /// wParam の入力A書式(ヒント)を取得します。
        /// </summary>
        public virtual string WParamFormat
        {
            get { return "使用しません"; }
        }

        /// <summary>
        /// lParam の入力書式(ヒント)を取得します。
        /// </summary>
        public virtual string LParamFormat
        {
            get { return "使用しません"; }
        }

        /// <summary>
        /// メッセージを送信します。
        /// </summary>
        /// <param name="targetHandle">送信対象のハンドル。</param>
        /// <param name="wParam">wParam を表す文字列。</param>
        /// <param name="lParam">lParam を表す文字列。</param>
        public virtual Result<string> SendMessage(IntPtr targetHandle, string wParam, string lParam)
        {
            return Result.Succeeded();
        }

        /// <summary>
        /// 現在の ControlFreak.Models.WindowMessages.WindowMessage を表す文字列を返します。
        /// </summary>
        /// <returns>現在の ControlFreak.Models.WindowMessages.WindowMessage を表す文字列。</returns>
        public override string ToString()
        {
            return string.Format("{{ wParamFormat={0}, lParamFormat={1} }}", this.WParamFormat, this.LParamFormat);
        }
    }
}
