using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Views
{
    /// <summary> ColorDialogView
    /// </summary>
    public partial class ColorEditView : UserControl
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public static readonly DependencyProperty EditColorProperty =
                    DependencyProperty.Register("EditColor", typeof(Color), typeof(ColorEditView), new FrameworkPropertyMetadata(default(Color), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public Color EditColor
        {
            get { return (Color)GetValue(EditColorProperty); }
            set { SetValue(EditColorProperty, value); }
        }

        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        public ColorEditView()
        {
            this.InitializeComponent();

            RootGrid.DataContext = this;

            this.PredefinedColors = EnumlatePredefinedColors();
            this.EditColor = Colors.White;

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
        /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        private static Color OnColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            // オブジェクトを取得して処理する
            //DependencyPropertyTestControl ctrl = obj as DependencyPropertyTestControl;
            //if (ctrl != null)
            //{
            //    ctrl.TitleTextBlock.Text = ctrl.Title;
            //}

            return (Color)e.NewValue;
        }

        private void ColorDialogContent_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (PredefinedColor predefinedColor in this.PredefinedColorsListBox.Items)
            {
                if (predefinedColor.Color == this.EditColor)
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

            this.EditColor = color;
        }

        /// <summary> リストボックスアイテム変更時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PredefinedColorsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.PredefinedColorsListBox.SelectedItem != null)
            {
                var color = ((PredefinedColor)this.PredefinedColorsListBox.SelectedItem).Color;

                this.RTextBox.Text = color.R.ToString();
                this.GTextBox.Text = color.G.ToString();
                this.BTextBox.Text = color.B.ToString();
                this.ATextBox.Text = color.A.ToString();

                SetValue(EditColorProperty, color);
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


        #region #- [Property] PredefinedColor[].PredefinedColors - ＜カラーリスト一覧＞ -----
        
        /// <summary> カラーリスト一覧 </summary>    
        public PredefinedColor[] PredefinedColors { get; set; }
        #endregion

        private PredefinedColor[] EnumlatePredefinedColors()
        {
            var colors = typeof(Colors).GetProperties();

            var list = new List<PredefinedColor>();
            foreach (var color in colors)
            {
                try
                {
                    list.Add(new PredefinedColor()
                    {
                        Name = color.Name,
                        Color = (Color)ColorConverter.ConvertFromString(color.Name)
                    });
                }
                catch
                {
                }
            }

            return list.OrderBy(x => x.Color.ToString()).ToArray();
        }
    }
}
