using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using FairyZeta.Framework.Controls;

namespace FairyZeta.Framework.Test.Pages
{
    /// <summary>
    /// GeneralPage.xaml の相互作用ロジック
    /// </summary>
    public partial class GeneralPage : UserControl
    {
        public GeneralPage()
        {
            this.InitializeComponent();

            this.OpenFontDialogButton.Click += this.OpenFontDialogButton_Click;
            this.OpenColorDialogButton.Click += this.OpenColorDialogButton_Click;
        }

        private void OpenFontDialogButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FontDialog()
            {
                Font = this.SampleTextBlock.GetFontInfo()
            };

            if (dialog.ShowDialog(Window.GetWindow(this)).Value)
            {
                var fi = dialog.Font;

                this.SampleTextBlock.SetFontInfo(fi);
                this.SampleTextBlock.Text =
                    fi.FamilyName + ", " +
                    fi.Size.ToString("N1") + "pt, " +
                    fi.StyleString + "-" + fi.WeightString + "-" + fi.StretchString + Environment.NewLine +
                    "本日は晴天なり。サンプルテキスト 0123456789";
            }
        }

        private void OpenColorDialogButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ColorDialog();

            var brush = this.SampleColorRectangle.Fill as SolidColorBrush;
            if (brush != null)
            {
                dialog.Color = brush.Color;
            }

            if (dialog.ShowDialog(Window.GetWindow(this)).Value)
            {
                this.SampleColorRectangle.Fill = new SolidColorBrush(dialog.Color);
            }
        }
    }
}
