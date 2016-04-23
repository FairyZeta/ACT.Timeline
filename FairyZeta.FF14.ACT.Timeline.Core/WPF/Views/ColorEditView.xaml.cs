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
                    DependencyProperty.Register("EditColor", typeof(Color), typeof(ColorEditView), new FrameworkPropertyMetadata(default(Color), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnColorChanged));

        /// <summary> (Dependency) 変更対象カラー </summary>
        public Color EditColor
        {
            get { return (Color)GetValue(EditColorProperty); }
            set { SetValue(EditColorProperty, value); }
        }

        /// <summary> カラーリスト一覧 </summary>    
        public PredefinedColor[] PredefinedColors { get; set; }

        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> カラーエディットビュー／コンストラクタ
        /// </summary>
        public ColorEditView()
        {
            this.InitializeComponent();

            RootGrid.DataContext = this;

            this.PredefinedColors = EnumlatePredefinedColors();
            this.EditColor = Colors.White;

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

                this.trySetColor();
                //this.ToPreview();
            };
        }
        /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> EditColor変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ColorEditView ctrl = obj as ColorEditView;
            if (ctrl != null)
            {
                ctrl.ToHex((Color)e.NewValue);
                ctrl.setPredefinedColorsListBox((Color)e.NewValue);
            }
        }

        /// <summary> カラーリストボックスから色を選択
        /// </summary>
        /// <param name="pNewColor"> 対象の色 </param>
        private void setPredefinedColorsListBox(Color pNewColor)
        {
            foreach (PredefinedColor predefinedColor in this.PredefinedColorsListBox.Items)
            {
                if (predefinedColor.Color == pNewColor)
                {
                    this.PredefinedColorsListBox.SelectedItem = predefinedColor;

                    var item = this.PredefinedColorsListBox.ItemContainerGenerator.ContainerFromItem(predefinedColor) as ListBoxItem;

                    if (item != null)
                        item.Focus();
                    
                }
            }

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

            this.trySetColor();
            //this.ToPreview();
        }

        private void ToHex(Color pColor)
        {
            this.RTextBox.Text = pColor.R.ToString();
            this.GTextBox.Text = pColor.G.ToString();
            this.BTextBox.Text = pColor.B.ToString();
            this.ATextBox.Text = pColor.A.ToString();

            this.HexTextBox.Text = pColor.ToString();

            this.trySetColor();
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


        private void trySetColor()
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

        /// <summary> リストボックスの配色一覧を生成します。
        /// </summary>
        /// <returns> 生成した配色一覧 </returns>
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
