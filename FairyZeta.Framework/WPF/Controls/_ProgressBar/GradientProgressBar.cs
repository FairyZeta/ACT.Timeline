using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace FairyZeta.Framework.WPF.Controls
{
    /// <summary> FZ／グラデーションプログレスバー
    /// </summary>
    public class GradientProgressBar : ProgressBar
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public static readonly DependencyProperty GradientColor1Property =
                    DependencyProperty.Register("GradientColor1", typeof(Color), typeof(GradientProgressBar), new FrameworkPropertyMetadata(default(Color), OnColorChanged));
        public static readonly DependencyProperty GradientColor2Property =
                    DependencyProperty.Register("GradientColor2", typeof(Color), typeof(GradientProgressBar), new FrameworkPropertyMetadata(default(Color), OnColorChanged));
        public static readonly DependencyProperty GradientColor3Property =
                    DependencyProperty.Register("GradientColor3", typeof(Color), typeof(GradientProgressBar), new FrameworkPropertyMetadata(default(Color), OnColorChanged));

        public static readonly DependencyProperty GradientStop1StartValueProperty =
                    DependencyProperty.Register("GradientStop1StartValue", typeof(double), typeof(GradientProgressBar), new FrameworkPropertyMetadata(70d, OnGradientStopValueChanged));
        public static readonly DependencyProperty GradientStop1EndValueProperty =
                    DependencyProperty.Register("GradientStop1EndValue", typeof(double), typeof(GradientProgressBar), new FrameworkPropertyMetadata(60d, OnGradientStopValueChanged));
        public static readonly DependencyProperty GradientStop2StartValueProperty =
                    DependencyProperty.Register("GradientStop2StartValue", typeof(double), typeof(GradientProgressBar), new FrameworkPropertyMetadata(40d, OnGradientStopValueChanged));
        public static readonly DependencyProperty GradientStop2EndValueProperty =
                    DependencyProperty.Register("GradientStop2EndValue", typeof(double), typeof(GradientProgressBar), new FrameworkPropertyMetadata(30d, OnGradientStopValueChanged));

        public static readonly DependencyProperty AutoHideProperty =
                    DependencyProperty.Register("AutoHide", typeof(bool), typeof(GradientProgressBar), new FrameworkPropertyMetadata(false, OnHidePropertyChanged));
        public static readonly DependencyProperty HideTypeProperty =
                    DependencyProperty.Register("HideType", typeof(Visibility), typeof(GradientProgressBar), new FrameworkPropertyMetadata(Visibility.Collapsed, OnHidePropertyChanged));


        /// <summary> (Dependency) グラデーションカラー1 </summary>
        public Color GradientColor1
        {
            get { return (Color)GetValue(GradientColor1Property); }
            set { SetValue(GradientColor1Property, value); }
        }
        /// <summary> (Dependency) グラデーションカラー2 </summary>
        public Color GradientColor2
        {
            get { return (Color)GetValue(GradientColor2Property); }
            set { SetValue(GradientColor2Property, value); }
        }
        /// <summary> (Dependency) グラデーションカラー3 </summary>
        public Color GradientColor3
        {
            get { return (Color)GetValue(GradientColor3Property); }
            set { SetValue(GradientColor3Property, value); }
        }

        /// <summary> (Dependency) Color1~2へのグラデーション開始値 </summary>
        public double GradientStop1StartValue
        {
            get { return (double)GetValue(GradientStop1StartValueProperty); }
            set { SetValue(GradientStop1StartValueProperty, value); }
        }
        /// <summary> (Dependency) Color1~2へのグラデーション終了値 </summary>
        public double GradientStop1EndValue
        {
            get { return (double)GetValue(GradientStop1EndValueProperty); }
            set { SetValue(GradientStop1EndValueProperty, value); }
        }
        /// <summary> (Dependency) Color2~3へのグラデーション開始値 </summary>
        public double GradientStop2StartValue
        {
            get { return (double)GetValue(GradientStop2StartValueProperty); }
            set { SetValue(GradientStop2StartValueProperty, value); }
        }
        /// <summary> (Dependency) Color2~3へのグラデーション終了値 </summary>
        public double GradientStop2EndValue
        {
            get { return (double)GetValue(GradientStop2EndValueProperty); }
            set { SetValue(GradientStop2EndValueProperty, value); }
        }

        /// <summary> (Dependency) 進捗100%時に自動で非表示にするか </summary>
        public bool AutoHide
        {
            get { return (bool)GetValue(AutoHideProperty); }
            set { SetValue(AutoHideProperty, value); }
        }
        /// <summary> (Dependency) 自動非表示にする場合の非表示タイプ( not "Visible" ) </summary>
        public Visibility HideType
        {
            get { return (Visibility)GetValue(HideTypeProperty); }
            set { SetValue(HideTypeProperty, value); }
        }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> FZ／グラデーションプログレスバー／コンストラクタ
        /// </summary>
        public GradientProgressBar()
            : base()
        {
            base.Loaded += GradientProgressBar_Loaded;
            base.ValueChanged += GradientProgressBar_ValueChanged;
        }


      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> [EVENT] プログレスバーロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GradientProgressBar_Loaded(object sender, RoutedEventArgs e)
        {
            this.CalculateNewGradient();
        }

        /// <summary> [EVENT] プログレスバー値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GradientProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.CalculateNewGradient();
        }

        /// <summary> GradientColor変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            GradientProgressBar ctrl = obj as GradientProgressBar;
            if (ctrl != null)
            {
                ctrl.CalculateNewGradient();
            }
        }

        /// <summary> GradientStopValue変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnGradientStopValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            GradientProgressBar ctrl = obj as GradientProgressBar;
            if (ctrl != null)
            {
                ctrl.CalculateNewGradient();
            }
        }

        /// <summary> Hide関連変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnHidePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            GradientProgressBar ctrl = obj as GradientProgressBar;
            if (ctrl != null)
            {
                ctrl.CalculateNewGradient();
            }
        }
        /// <summary> 新しいグラデーションブラシを生成します。
        /// </summary>
        protected void CalculateNewGradient()
        {
            var brush = new LinearGradientBrush();
            brush.StartPoint = new Point(1.0, 0.5);
            brush.EndPoint = new Point(0.0, 0.5);

            double progress = base.Maximum - base.Value;

            if (progress <= 0)
            {
                if (this.AutoHide)
                {
                    base.Visibility = this.HideType;
                    return;
                }
            }
            else if (progress < this.GradientStop2StartValue)
            {
                var newGradientStop2 = new GradientStop(this.GradientColor3, this.GradientStop2EndValue - progress);
                var newGradientStop1 = new GradientStop(this.GradientColor2, this.GradientStop2StartValue - progress);
                brush.GradientStops.Add(newGradientStop2);
                brush.GradientStops.Add(newGradientStop1);
            }
            else if (progress < this.GradientStop1StartValue)
            {
                var newGradientStop2 = new GradientStop(this.GradientColor2, this.GradientStop1EndValue - progress);
                var newGradientStop1 = new GradientStop(this.GradientColor1, this.GradientStop1StartValue - progress);
                brush.GradientStops.Add(newGradientStop2);
                brush.GradientStops.Add(newGradientStop1);
            }
            else
            {
                var newGradientStop = new GradientStop(this.GradientColor1, 0);
                brush.GradientStops.Add(newGradientStop);
            }


            if (this.AutoHide)
            {
                base.Visibility = Visibility.Visible;
            }

            base.Foreground = brush;
        }
    }
}
