using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FairyZeta.Framework.Controls
{
    public partial class FontDialogContent : UserControl
    {
        private FontInfo fontInfo = new FontInfo();

        public FontDialogContent()
        {
            this.InitializeComponent();

            this.Loaded += (s, e) =>
            {
                this.ShowFontInfo();

                // リストボックスにフォーカスを設定する
                ListBox box;

                box = this.FontStyleListBox;
                if (box.SelectedItem != null)
                {
                    var item =
                        box.ItemContainerGenerator.ContainerFromItem(box.SelectedItem)
                        as ListBoxItem;

                    if (item != null)
                    {
                        item.Focus();
                    }
                }

                box = this.FontFamilyListBox;
                if (box.SelectedItem != null)
                {
                    var item =
                        box.ItemContainerGenerator.ContainerFromItem(box.SelectedItem)
                        as ListBoxItem;

                    if (item != null)
                    {
                        item.Focus();
                    }
                }
            };

            this.FontSizeTextBox.PreviewKeyDown += this.FontSizeTextBox_PreviewKeyDown;
            this.FontSizeTextBox.LostFocus += (s, e) =>
            {
                const double MinSize = 5.0;

                var t = (s as TextBox).Text;

                double d;
                if (double.TryParse(t, out d))
                {
                    if (d < MinSize)
                    {
                        d = MinSize;
                    }

                    (s as TextBox).Text = d.ToString("N1");
                }
                else
                {
                    (s as TextBox).Text = MinSize.ToString("N0");
                }
            };

            this.FontFamilyListBox.SelectionChanged += this.FontFamilyListBox_SelectionChanged;
        }

        public FontInfo FontInfo
        {
            get
            {
                return this.fontInfo;
            }
            set
            {
                this.fontInfo = value;
                this.ShowFontInfo();
            }
        }

        private void FontFamilyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.FontStyleListBox.SelectedIndex = 0;
        }

        private void FontSizeTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var t = sender as TextBox;

            decimal d;

            if (e.Key == Key.Up)
            {
                if (decimal.TryParse(t.Text, out d))
                {
                    t.Text = (d + 0.5m).ToString("N1");
                }
            }

            if (e.Key == Key.Down)
            {
                if (decimal.TryParse(t.Text, out d))
                {
                    if ((d - 0.5m) >= 1.0m)
                    {
                        t.Text = (d - 0.5m).ToString("N1");
                    }
                }
            }
        }

        internal void OKBUtton_Click(object sender, RoutedEventArgs e)
        {
            this.fontInfo = this.PreviewTextBlock.GetFontInfo();
        }

        private void ShowFontInfo()
        {
            this.FontSizeTextBox.Text = this.fontInfo.Size.ToString("N1");

            int i = 0;
            foreach (FontFamily item in this.FontFamilyListBox.Items)
            {
                if (this.fontInfo.Family != null)
                {
                    if (item.Source == this.fontInfo.Family.Source ||
                        item.FamilyNames.Any(x => x.Value == this.fontInfo.Family.Source))
                    {
                        break;
                    }
                }

                i++;
            }

            if (i < this.FontFamilyListBox.Items.Count)
            {
                this.FontFamilyListBox.SelectedIndex = i;
                this.FontFamilyListBox.ScrollIntoView(this.FontFamilyListBox.Items[i]);
            }

            this.FontStyleListBox.SelectedItem = this.fontInfo.Typeface;
        }
    }
}
