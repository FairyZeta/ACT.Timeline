using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FairyZeta.Framework.WPF.Controls
{
    public class NumericTextBox : TextBox
    {
        static NumericTextBox()
        {
            // IMEを無効化。
            InputMethod.IsInputMethodEnabledProperty.OverrideMetadata(typeof(NumericTextBox), new FrameworkPropertyMetadata(false));
        }

        public NumericTextBox()
        {
            // ペーストのキーボードショートカットを無効化。
            this.InputBindings.Add(new KeyBinding(ApplicationCommands.NotACommand, Key.V, ModifierKeys.Control));
            this.InputBindings.Add(new KeyBinding(ApplicationCommands.NotACommand, Key.Insert, ModifierKeys.Shift));
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            // 数値以外、または数値の入力に関係しないキーが押された場合、イベントを処理済みに。
            if (!((Key.D0 <= e.Key && e.Key <= Key.D9) ||
                  (Key.NumPad0 <= e.Key && e.Key <= Key.NumPad9) ||
                  Key.Back == e.Key ||
                  Key.Delete == e.Key ||
                  Key.Tab == e.Key) ||
                (Keyboard.Modifiers & ModifierKeys.Shift) > 0)
            {
                e.Handled = true;
            }

            base.OnKeyDown(e);
        }

        // 右クリックを無効化。
        protected override void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }
}
