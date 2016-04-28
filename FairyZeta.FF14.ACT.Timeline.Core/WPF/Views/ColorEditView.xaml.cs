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
    public partial class ColorEditView : UserControl, IDisposable
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
            this.RSlider.ValueChanged += (s, e) => this.ToHex();
            this.GSlider.ValueChanged += (s, e) => this.ToHex();
            this.BSlider.ValueChanged += (s, e) => this.ToHex();
            this.ASlider.ValueChanged += (s, e) => this.ToHex();
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

                this.RTextBox.ChangedValue = Convert.ToInt32(color.R);
                this.GTextBox.ChangedValue = Convert.ToInt32(color.G);
                this.BTextBox.ChangedValue = Convert.ToInt32(color.B);
                this.ATextBox.ChangedValue = Convert.ToInt32(color.A);

                this.trySetColor();
                //this.ToPreview();
            };
        }
        /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> デストラクタ
        /// </summary>
        ~ColorEditView()
        {
            this.OnDispose(false);
            return;
        }

        /// <summary>
        /// 開放処理されたかどうかを取得|設定します。
        /// </summary>
        public bool IsDisposed
        {
            get; protected set;
        }

        /// <summary>
        /// 内部リソース解放処理を行います。<br/>
        /// 参照系の内部変数をnullに初期化したり、
        /// イベントからハンドラメソッドを削除します。
        /// </summary>
        public void Dispose()
        {
            try
            {
                this.OnDispose(true);
            }
            catch (Exception)
            {
            }

            return;
        }

        /// <summary>
        /// 内部リソース解放処理を行います。<br/>
        /// </summary>
        /// <param name="disposing">false:アンマネージドリソースのみ解放する</param>
        protected virtual void OnDispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            this.IsDisposed = true;

            this.PredefinedColors = null;

            this.PredefinedColorsListBox.SelectionChanged -= this.PredefinedColorsListBox_SelectionChanged;
            this.RSlider.ValueChanged -= (s, e) => this.ToHex();
            this.GSlider.ValueChanged -= (s, e) => this.ToHex();
            this.BSlider.ValueChanged -= (s, e) => this.ToHex();
            this.ASlider.ValueChanged -= (s, e) => this.ToHex();

            if (disposing)
            {
            }
        }
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
                    this.PredefinedColorsListBox.ScrollIntoView(this.PredefinedColorsListBox.SelectedItem);

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

                this.RTextBox.ChangedValue = Convert.ToInt32(color.R);
                this.GTextBox.ChangedValue = Convert.ToInt32(color.G);
                this.BTextBox.ChangedValue = Convert.ToInt32(color.B);
                this.ATextBox.ChangedValue = Convert.ToInt32(color.A);

                SetValue(EditColorProperty, color);
            }
        }

        private void ToHex()
        {
            byte a, r, g, b;
            byte.TryParse(this.ATextBox.ChangedValue.ToString(), out a);
            byte.TryParse(this.RTextBox.ChangedValue.ToString(), out r);
            byte.TryParse(this.GTextBox.ChangedValue.ToString(), out g);
            byte.TryParse(this.BTextBox.ChangedValue.ToString(), out b);

            var color = Color.FromArgb(a, r, g, b);

            this.HexTextBox.Text = color.ToString();

            this.trySetColor();
            //this.ToPreview();
        }

        private void ToHex(Color pColor)
        {
            this.RTextBox.ChangedValue = Convert.ToInt32(pColor.R);
            this.GTextBox.ChangedValue = Convert.ToInt32(pColor.G);
            this.BTextBox.ChangedValue = Convert.ToInt32(pColor.B);
            this.ATextBox.ChangedValue = Convert.ToInt32(pColor.A);

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
