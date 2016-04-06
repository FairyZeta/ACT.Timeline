using System.Windows;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Behavior
{
    public class WindowStateChangeAttachedBehavior
    {
        public static WindowState GetIsStateChange(DependencyObject obj)
        {
            return (WindowState)obj.GetValue(IsStateChangeProperty);
        }
        public static void SetIsStateChange(DependencyObject obj, WindowState value)
        {
            obj.SetValue(IsStateChangeProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsFullScreen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsStateChangeProperty =
            DependencyProperty.RegisterAttached("IsStateChange", typeof(WindowState), typeof(WindowStateChangeAttachedBehavior), new PropertyMetadata(WindowState.Normal, OnIsStateChanged));

        private static void OnIsStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Command添付プロパティに変更が加わったら、マウス左クリック時のイベントを登録する。
            var win = d as Window;
            if (win == null)
            {
                // 要素の親のWindowを取得
                win = Window.GetWindow(d);
            }

            var newValue = (WindowState)e.NewValue;
            switch (newValue)
            {
                case WindowState.Normal:
                    win.WindowState = WindowState.Normal;
                    break;
                case WindowState.Maximized:
                    win.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Minimized:
                    win.WindowState = WindowState.Minimized;
                    break;
                default:
                    break;
            }
        }
    }
}
