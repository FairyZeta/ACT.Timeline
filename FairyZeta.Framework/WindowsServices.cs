using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace FairyZeta.Framework
{
    /// <summary> FZ／ウィンドウサービス
    /// </summary>
    public static class WindowsServices
    {
        const int WS_EX_TRANSPARENT = 0x00000020;
        const int GWL_EXSTYLE = (-20);


        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hwnd, int index);
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        const UInt32 WM_CLOSE = 0x0010;

        [Flags]
        public enum ExtendedWindowStyles
        {
            WS_EX_TOOLWINDOW = 0x00000080
            //WS_EX_TOOLWINDOW = 0x80
        }

        public enum GetWindowLongFields
        {
            GWL_EXSTYLE = (-20)
            //GWL_EXSTYLE = -20
        }

        /// <summary> パラメータ値のIntPtrのプロセスIDを取得し、outします。
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpdwProcessId"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        /// <summary> 現在のウィンドウのIntPtrを取得します。
        /// </summary>
        /// <returns> 取得したIntPtr </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary> ウィンドウのクリックスルーを設定します。
        /// </summary>
        /// <param name="hwnd"> ウィンドウのIntPrt </param>
        public static void SetWindowExTransparent(IntPtr hwnd)
        {
            var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
        }
        /// <summary> ウィンドウのクリックスルーを解除します。
        /// </summary>
        /// <param name="hwnd"> ウィンドウのIntPrt </param>
        public static void InitWindowExTransparent(IntPtr hwnd)
        {
            int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle & ~WS_EX_TRANSPARENT);
        }

        /// <summary> 画面を閉じるメッセージを送信します。
        /// </summary>
        /// <param name="pIntPtr"> 閉じる画面のIntPtr </param>
        public static void WindowCloseSendMessage(IntPtr pIntPtr)
        {
            SendMessage(pIntPtr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }


    }
}
