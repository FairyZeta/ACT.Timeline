using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using FairyZeta.Framework.ObjectModel;

namespace FairyZeta.Framework.Test.Pages
{
    /// <summary>
    /// GeneralPage.xaml の相互作用ロジック
    /// </summary>
    public partial class GeneralPage : UserControl
    {
        DialogManageObjectModel dialog = new DialogManageObjectModel();

        public GeneralPage()
        {
            this.InitializeComponent();

            this.OpenFontDialogButton.Click += this.OpenFontDialogButton_Click;
            this.OpenColorDialogButton.Click += this.OpenColorDialogButton_Click;

        }

        private void OpenFontDialogButton_Click(object sender, RoutedEventArgs e)
        {
            dialog.Font = this.SampleTextBlock.GetFontInfo();

            if (dialog.ShowFontDialog(Window.GetWindow(this)).Value)
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
            var brush = this.SampleColorRectangle.Fill as SolidColorBrush;
            if (brush != null)
            {
                dialog.Color = brush.Color;
            }

            if (dialog.ShowColorDialog(Window.GetWindow(this)).Value)
            {
                this.SampleColorRectangle.Fill = new SolidColorBrush(dialog.Color);
            }
        }
    }
}
