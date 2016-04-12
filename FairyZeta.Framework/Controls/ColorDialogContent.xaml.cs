using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FairyZeta.Framework.Controls
{
    public partial class ColorDialogContent : UserControl
    {
        public ColorDialogContent()
        {
            this.InitializeComponent();

            this.Color = Colors.White;

            this.Loaded += this.ColorDialogContent_Loaded;
            this.PredefinedColorsListBox.SelectionChanged += this.PredefinedColorsListBox_SelectionChanged;
            this.RTextBox.TextChanged += (s, e) => this.ToHex();
            this.GTextBox.TextChanged += (s, e) => this.ToHex();
            this.BTextBox.TextChanged += (s, e) => this.ToHex();
            this.ATextBox.TextChanged += (s, e) => this.ToHex();
            this.HexTextBox.LostFocus += (s, e) =>
            {
                var color = Colors.White;

                try
                {
                    color = (Color)ColorConverter.ConvertFromString(this.HexTextBox.Text);
                }
                catch
                {
                }

                this.RTextBox.Text = color.R.ToString();
                this.GTextBox.Text = color.G.ToString();
                this.BTextBox.Text = color.B.ToString();
                this.ATextBox.Text = color.A.ToString();

                this.ToPreview();
            };
        }

        private void ColorDialogContent_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (PredefinedColor predefinedColor in this.PredefinedColorsListBox.Items)
            {
                if (predefinedColor.Color == this.Color)
                {
                    this.PredefinedColorsListBox.SelectedItem = predefinedColor;

                    var item =
                        this.PredefinedColorsListBox.ItemContainerGenerator.ContainerFromItem(predefinedColor)
                        as ListBoxItem;

                    if (item != null)
                    {
                        item.Focus();
                    }
                }
            }
        }

        public Color Color { get; set; }

        public void Apply()
        {
            var color = Colors.White;

            try
            {
                color = (Color)ColorConverter.ConvertFromString(this.HexTextBox.Text);
            }
            catch
            {
            }

            this.Color = color;
        }

        private void PredefinedColorsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.PredefinedColorsListBox.SelectedItem != null)
            {
                var color = ((PredefinedColor)this.PredefinedColorsListBox.SelectedItem).Color;

                this.RTextBox.Text = color.R.ToString();
                this.GTextBox.Text = color.G.ToString();
                this.BTextBox.Text = color.B.ToString();
                this.ATextBox.Text = color.A.ToString();
            }
        }

        private void ToHex()
        {
            byte a, r, g, b;
            byte.TryParse(this.ATextBox.Text, out a);
            byte.TryParse(this.RTextBox.Text, out r);
            byte.TryParse(this.GTextBox.Text, out g);
            byte.TryParse(this.BTextBox.Text, out b);

            var color = Color.FromArgb(a, r, g, b);

            this.HexTextBox.Text = color.ToString();

            this.ToPreview();
        }

        private void ToPreview()
        {
            var color = Colors.White;

            try
            {
                color = (Color)ColorConverter.ConvertFromString(this.HexTextBox.Text);
            }
            catch
            {
            }

            this.PreviewRectangle.Fill = new SolidColorBrush(color);
        }
    }
}
